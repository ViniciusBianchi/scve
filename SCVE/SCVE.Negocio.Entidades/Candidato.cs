using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Negocio.Entidades
{
    public class Candidato
    {
        public virtual int OrdemCadastro { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CodigoAutenticacao { get; set; }
        public virtual string Cpf { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual int? Sexo { get; set; }
        public virtual string Endereco { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cep { get; set; }
        public virtual string TelFixo { get; set; }
        public virtual string TelCelular { get; set; }
        public virtual string Email { get; set; }
        public virtual int Periodo { get; set; }
        public virtual int TurnoDisponibilidade { get; set; }
        public virtual string NomeCurso { get; set; }
        public virtual DateTime DtTerminoCurso { get; set; }
        public virtual int NivelIngles { get; set; }
        public virtual int NivelFrances { get; set; }
        public virtual int NivelEspanhol { get; set; }
        public virtual bool PortadorNecessidadeEspecial { get; set; }
        public virtual bool TermoResponsabilidade { get; set; }
        public virtual DateTime DataCadastro { get; set; }
        public virtual DateTime DataAlteracao { get; set; }
        public virtual IList<NecessidadesEspeciais> NecessidadesEspeciais { get; set; }
        public virtual IList<ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public virtual IList<OutrosCursos> OutrosCursos { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }
        public virtual AreaAtuacao AreaAtuacao { get; set; }
        public virtual Raca Raca { get; set; }
        public virtual int IdRaca { get; set; }
        public virtual Cidade Cidade { get; set; }
        public virtual int IdPais { get; set; }
        public virtual int IdCidade { get; set; }
        public virtual string Uf { get; set; }
    }
}
