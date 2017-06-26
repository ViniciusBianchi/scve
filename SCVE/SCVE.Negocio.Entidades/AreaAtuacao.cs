using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class AreaAtuacao
    {
        public virtual int AreaAtuacaoId { get; set; }
        public virtual string Nome { get; set; }
        public virtual bool Status { get; set; }
    }
}
