using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class ExperienciaProfissional
    {
        public virtual int ExperienciaProfissionalId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public virtual string NomeEmpresa { get; set; }
        public virtual string DescricaoFuncaoExercida { get; set; }
        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime? DataFim { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is ExperienciaProfissional))
                return false;

            ExperienciaProfissional outro = (ExperienciaProfissional)obj;
            return ExperienciaProfissionalId.Equals(outro.ExperienciaProfissionalId);
        }

        public override int GetHashCode()
        {
            return ExperienciaProfissionalId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
