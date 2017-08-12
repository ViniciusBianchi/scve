using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Componente.Seguranca
{
    [Serializable]
    public class UsuarioSistema
    {
        public int CodUsuario { get; set; }
        public string Identificacao { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
