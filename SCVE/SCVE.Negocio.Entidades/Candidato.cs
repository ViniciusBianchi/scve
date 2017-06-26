using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class Candidato
    {
        public virtual int CandidatoId { get; set; }
        public virtual string Nome { get; set; }
        public virtual Guid CodigoAutenticacao { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DataNascimento { get; set; }
        public virtual bool Sexo { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Bairro { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual int CidadeId { get; set; }
        public virtual string Cep { get; set; }
        public virtual string TelFixo { get; set; }
        public virtual string TelCelular { get; set; }
        public virtual string Email { get; set; }
        public virtual int Periodo { get; set; }
        public virtual int TurnoDisponibilidade { get; set; }
        public virtual string NomeCurso { get; set; }
        public virtual DateTime DataTerminoCurso { get; set; }
        public virtual int NivelIngles { get; set; }
        public virtual int NivelFrances { get; set; }
        public virtual int NivelEspanhol { get; set; }
        public virtual bool PortadorNecessidadeEspecial { get; set; }
        public virtual bool TermoResponsabilidade { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual IList<NecessidadeEspecial> NecessidadesEspeciais { get; set; }
        public virtual IList<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public virtual IList<OutroCurso> OutrosCursos { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
        public virtual AreaAtuacao AreaAtuacao { get; set; }
        public virtual Raca Raca { get; set; }
        public virtual int RacaId { get; set; }
        public virtual string Uf { get; set; }

        #region Comparar Membros
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj == this)
                return true;

            if (!(obj is Candidato))
                return false;

            Candidato outro = (Candidato)obj;
            return CandidatoId.Equals(outro.CandidatoId);
        }

        public override int GetHashCode()
        {
            return CandidatoId.GetHashCode();
        }
        #endregion Comparar Membros
    }
}
