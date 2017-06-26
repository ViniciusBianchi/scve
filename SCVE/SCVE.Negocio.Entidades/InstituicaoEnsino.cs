using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class InstituicaoEnsino
    {
        public virtual int InstituicaoEnsinoId { get; set; }
        public virtual string Nome { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is InstituicaoEnsino))
                return false;

            InstituicaoEnsino outro = (InstituicaoEnsino)obj;
            return InstituicaoEnsinoId.Equals(outro.InstituicaoEnsinoId);
        }

        public override int GetHashCode()
        {
            return InstituicaoEnsinoId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
