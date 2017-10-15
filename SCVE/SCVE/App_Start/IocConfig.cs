using Ninject;
using Ninject.Syntax;
using SCVE.Negocio.Aplicacao.Interfaces;
using SCVE.Negocio.Aplicacao.ServicosAplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCVE.App_Start
{
    public class IocConfig
    {
        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            kernel.Bind<ICandidatoAppService>().To<CandidatoAppService>();
            kernel.Bind<ILoginAppService>().To<LoginAppService>();

            //Verifica se Membership provider é do Administrador ou do Candidato           
            //if (Membership.Provider.GetType() == typeof(FabricaMembershipProvider))
            //{
            //    kernel.Bind<IControleAccesso>().To<ControleAcessoFabrica>();
            //}
            //else
            //{
            //    kernel.Bind<IControleAccesso>().To<ControleAcesso>();
            //}


            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}