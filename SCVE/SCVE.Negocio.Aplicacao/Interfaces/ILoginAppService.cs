using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Aplicacao.Interfaces
{
    public interface ILoginAppService
    {
        bool ValidarCandidato(string cpf);
        bool ValidarAdministrador(string login, string senha);
    }
}
