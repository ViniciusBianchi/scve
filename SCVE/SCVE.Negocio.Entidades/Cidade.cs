using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class Cidade
    {
        public virtual int CidadeId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Uf { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is Cidade))
                return false;

            Cidade outro = (Cidade)obj;
            return CidadeId.Equals(outro.CidadeId);
        }

        public override int GetHashCode()
        {
            return CidadeId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
