using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCVE.Persistencia;
using SCVE.Negocio.Aplicacao.Interfaces;
using Newtonsoft.Json;
using System.Web.Security;
using SCVE.Negocio.Componente.Seguranca;
using SCVE.Negocio.Componente.Infraestrutura;
using System.Runtime.Caching;
using SCVE.Negocio.Entidades;
using System.Net;
using SCVE.Negocio.Componente;
using SCVE.Negocio.Componente.Helpers;

namespace SCVE.Controllers
{
    public class LoginController : Controller
    {
        DataContext contexto = new DataContext();

        private readonly ICandidatoAppService _candidatoAppService;
        private readonly IAdministradorAppService _administradorAppService;

        public LoginController(ICandidatoAppService candidatoAppService,
                                IAdministradorAppService administradorAppService)
        {
            _candidatoAppService = candidatoAppService;
            _administradorAppService = administradorAppService;
        }

        public LoginController()
        {

        }

        // GET: Login
        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ValidarLogin(string login, string senha)
        {
            string mensagem = string.Empty;
            bool usuarionaoautorizado = false;

            try
            {
                if (Membership.ValidateUser(login, senha))
                {
                    // Verificar se o usuario é administrador
                    IQueryable<Administrador> adm = from Administradores in contexto.Administradores
                                        where Administradores.Email == login && Administradores.Senha == senha
                                        select Administradores;

                    if (adm.ToList().Count > 0)
                    {
                        UsuarioSistema usuario = new UsuarioSistema();
                        Administrador administrador = adm.Single();
                        usuario.CodUsuario = administrador.AdministradorId;
                        usuario.Identificacao = administrador.Email;
                        usuario.Nome = administrador.Nome;

                        CriarCookie(login, usuario);
                    }
                        
                    else
                    {
                        usuarionaoautorizado = true;
                        mensagem = "Usuário não autorizado";
                        return Json(new { Status = HttpStatusCode.BadRequest, Mensagem = mensagem, usuarioNaoAutorizado = usuarionaoautorizado });
                    }
                        
                }
                return Json(new { Status = HttpStatusCode.OK, Mensagem = mensagem, usuarioNaoAutorizado = usuarionaoautorizado });
            }
            catch (BusinessException ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                return Json(new { Status = HttpStatusCode.BadRequest, Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                return Json(new { Status = HttpStatusCode.InternalServerError, Mensagem = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult ValidarCandidato(string cpf, Guid? codigoAutenticacao)
        {
            string mensagem = string.Empty;
            bool autenticacaoinvalida = false;

            try
            {
                if (!string.IsNullOrEmpty(cpf))
                {
                    if (!ValidationHelper.ValidaCPF(cpf))
                    {
                        mensagem = "CPF Inválido!";
                        return Json(new { Status = HttpStatusCode.BadRequest, Codigo = -1, Mensagem = mensagem });
                    }

                    if (codigoAutenticacao == null)
                    {
                        mensagem = "Por favor, preencha o Código de Autenticação.";
                        return Json(new { Status = HttpStatusCode.BadRequest, Codigo = -1, Mensagem = mensagem });
                    }

                    UsuarioSistema usuario = new UsuarioSistema();
                    Candidato candidato = contexto.BuscarDadosCandidato(cpf);
                    //Candidato candidato = _candidatoAppService.BuscarDadosCandidato(cpf);

                    if (candidato == null)
                    {
                        // Direcionar candidato para tela de cadastrar curriculo
                        return Json(new { Status = HttpStatusCode.OK, Codigo = 1 });
                    }
                    else
                    {
                        if (candidato.CodigoAutenticacao == codigoAutenticacao)
                        {
                            usuario.Identificacao = candidato.Cpf;

                            CriarCookieCandidato(cpf, usuario);
                            return Json(new { Status = HttpStatusCode.OK, Codigo = 1 });
                        }
                        else
                        {
                            mensagem = "Código de Autenticação inválido";
                            autenticacaoinvalida = true;
                            return Json(new { Status = HttpStatusCode.InternalServerError, Mensagem = mensagem, autenticacaoInvalida = autenticacaoinvalida });
                        }
                    }
                }
                else
                {
                    mensagem = "Por favor, preencha o campo Cpf.";
                    return Json(new { Status = HttpStatusCode.BadRequest, Codigo = -1, Mensagem = mensagem });
                }
            }
            catch (BusinessException ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                return Json(new { Status = HttpStatusCode.BadRequest, Mensagem = ex.Message });
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                return Json(new { Status = HttpStatusCode.InternalServerError, Mensagem = ex.Message });
            }
        }

        private void CriarCookie(string login, UsuarioSistema usuario)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuario);
            var usuarioCookie = new HttpCookie("UsuarioSCVE", usuarioJson);
            Response.Cookies.Add(usuarioCookie);
            CreateAuthenticationTicket(usuario);
            FormsAuthentication.GetRedirectUrl(login, false);
        }

        private void CriarCookieCandidato(string cpf, UsuarioSistema usuario)
        {
            var usuarioJson = JsonConvert.SerializeObject(usuario);
            var usuarioCookie = new HttpCookie("UsuarioSCVE", usuarioJson);
            Response.Cookies.Add(usuarioCookie);
            //CreateAuthenticationTicket(candidato);
            FormsAuthentication.GetRedirectUrl(cpf, false);
        }

        public void CreateAuthenticationTicket(UsuarioSistema usuario)
        {
            try
            {
                AdministradorSerializeModel serializeModel = new AdministradorSerializeModel();
                serializeModel.Email = usuario.Identificacao;
                serializeModel.Codigo = usuario.CodUsuario;
                serializeModel.Nome = usuario.Nome;

                string userData = JsonConvert.SerializeObject(serializeModel);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                  1, serializeModel.Email, DateTime.Now, DateTime.Now.AddHours(8), true, userData);
                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType).Error(ex);
                throw ex;
            }
        }

        // Método utilizado para deslogar do sistema e remover o cookie
        public ActionResult Logout()
        {

            Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddYears(-1);
            Response.Cookies[FormsAuthentication.FormsCookieName].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["UsuarioSCVE"].Expires = DateTime.Now.AddYears(-1);
            FormsAuthentication.SignOut();
            Session.Abandon();
            MemoryCache.Default.Dispose();

            return View("Login");
        }
    }
}
