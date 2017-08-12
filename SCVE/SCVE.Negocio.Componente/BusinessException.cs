using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Componente
{
    public class BusinessException : System.Exception
    {
        public BusinessException(string message)
            : base(message)
        {
        }
        public BusinessException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
