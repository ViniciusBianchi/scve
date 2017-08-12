using SCVE.Negocio.Aplicacao.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCVE.Persistencia;

namespace SCVE.Negocio.Aplicacao.ServicosAplicacao
{
    public class LoginAppService : ILoginAppService
    {
        DataContext contexto = new DataContext();

        public bool ValidarCandidato(string cpf)
        {
            if (contexto.Candidatos.Select(p => p.Cpf == cpf).FirstOrDefault())
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool ValidarAdministrador(string login, string senha)
        {
            return true;
        }
    }
}
