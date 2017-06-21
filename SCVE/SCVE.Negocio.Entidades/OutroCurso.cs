using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class OutroCurso
    {
        public virtual int OutroCursoId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual string Nome { get; set; }
        public virtual int? AnoConclusao { get; set; }

        #region Comparar Membros

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is OutroCurso))
                return false;

            OutroCurso outro = (OutroCurso)obj;
            return OutroCursoId.Equals(outro.OutroCursoId);
        }

        public override int GetHashCode()
        {
            return OutroCursoId.GetHashCode();
        }

        #endregion Comparar Membros
    }
}
