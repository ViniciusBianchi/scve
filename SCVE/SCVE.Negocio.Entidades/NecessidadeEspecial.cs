using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class NecessidadeEspecial
    {
        public virtual int NecessidadeEspecialId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual string Descricao { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is NecessidadeEspecial))
                return false;

            NecessidadeEspecial outro = (NecessidadeEspecial)obj;
            return NecessidadeEspecialId.Equals(outro.NecessidadeEspecialId);
        }

        public override int GetHashCode()
        {
            return NecessidadeEspecialId.GetHashCode();
        }


        #endregion Compare Members
    }
}
