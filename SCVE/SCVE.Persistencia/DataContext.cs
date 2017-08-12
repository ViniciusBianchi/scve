using SCVE.Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCVE.Persistencia
{
    public class DataContext : DbContext
    {
        public DataContext()
                : base("SCVE")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<AreaAtuacao> AreasAtuacao { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<ExperienciaProfissional> ExperienciasProfissionais { get; set; }
        public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; }
        public DbSet<NecessidadeEspecial> NecessidadesEspeciais { get; set; }
        public DbSet<OutroCurso> OutrosCursos { get; set; }
        public DbSet<Raca> Racas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                   .Where(p => p.Name == p.ReflectedType.Name + "Id")
                   .Configure(p => p.IsKey());
            //modelBuilder.Properties<string>()
            //       .Configure(p => p.HasColumnType("varchar"));
            //modelBuilder.Properties<string>()
            //      .Configure(p => p.HasMaxLength(100));
            //Mapeamento para a tabela Candidato
            //S1: Chave Primária para a tabela Candidato
            //modelBuilder.Entity<Candidato>().HasKey(c => c.CandidatoId);
            //S2: A chave Identity Key para CandidatoId
            //modelBuilder.Entity<Candidato>().Property(c => c.CandidatoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            // tamanho máximo para as propriedades do tipo String

            #region ModelBuilder Candidato
            modelBuilder.Entity<Candidato>().ToTable("Candidatos");
            modelBuilder.Entity<Candidato>().Property(c => c.Nome).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.CodigoAutenticacao).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Cpf).HasMaxLength(14).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.DataNascimento).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Sexo).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Endereco).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Bairro).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.CidadeId).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Cep).HasMaxLength(10).IsOptional();
            modelBuilder.Entity<Candidato>().Property(c => c.TelFixo).HasMaxLength(14).IsOptional();
            modelBuilder.Entity<Candidato>().Property(c => c.TelCelular).HasMaxLength(14).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Email).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Periodo).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.TurnoDisponibilidade).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.NomeCurso).HasMaxLength(50);
            modelBuilder.Entity<Candidato>().Property(c => c.DataTerminoCurso).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.NivelIngles).IsOptional();
            modelBuilder.Entity<Candidato>().Property(c => c.NivelFrances).IsOptional();
            modelBuilder.Entity<Candidato>().Property(c => c.NivelEspanhol).IsOptional();
            modelBuilder.Entity<Candidato>().Property(c => c.PortadorNecessidadeEspecial).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.TermoResponsabilidade).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.DataCadastro).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.DataAlteracao).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.Uf).HasMaxLength(2).IsRequired();
            modelBuilder.Entity<Candidato>().Property(c => c.RacaId).IsRequired();
            #endregion

            #region ModelBuilder Administrador
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            modelBuilder.Entity<Administrador>().Property(c => c.Email).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Administrador>().Property(c => c.Nome).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Administrador>().Property(c => c.Senha).HasMaxLength(20).IsRequired();
            #endregion

            #region ModelBuilder AreaAtuacao
            modelBuilder.Entity<AreaAtuacao>().ToTable("AreasAtuacao");
            modelBuilder.Entity<AreaAtuacao>().Property(c => c.Nome).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<AreaAtuacao>().Property(c => c.Status).IsRequired();
            #endregion

            #region ModelBuilder Cidade
            modelBuilder.Entity<Cidade>().ToTable("Cidades");
            modelBuilder.Entity<Cidade>().Property(c => c.Nome).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Cidade>().Property(c => c.Uf).HasMaxLength(2).IsRequired();
            #endregion

            #region ModelBuilder ExperienciaProfissional
            modelBuilder.Entity<ExperienciaProfissional>().ToTable("ExperienciasProfissionais");
            modelBuilder.Entity<ExperienciaProfissional>().Property(c => c.NomeEmpresa).HasMaxLength(50).IsOptional();
            modelBuilder.Entity<ExperienciaProfissional>().Property(c => c.DescricaoFuncaoExercida).HasMaxLength(250).IsOptional();
            #endregion

            #region ModelBuilder InstituicaoEnsino
            modelBuilder.Entity<InstituicaoEnsino>().ToTable("InstituicoesEnsino");
            modelBuilder.Entity<InstituicaoEnsino>().Property(c => c.Nome).HasMaxLength(50).IsRequired();
            #endregion

            #region ModelBuilder NecessidadeEspecial
            modelBuilder.Entity<NecessidadeEspecial>().ToTable("NecessidadesEspeciais");
            modelBuilder.Entity<NecessidadeEspecial>().Property(c => c.Descricao).HasMaxLength(50).IsOptional();
            #endregion

            #region ModelBuilder OutroCurso
            modelBuilder.Entity<OutroCurso>().ToTable("OutrosCursos");
            modelBuilder.Entity<OutroCurso>().Property(c => c.Nome).HasMaxLength(50).IsOptional();
            #endregion

            #region ModelBuilder Raca
            modelBuilder.Entity<Raca>().ToTable("Racas");
            modelBuilder.Entity<Raca>().Property(c => c.Descricao).HasMaxLength(50).IsRequired();
            #endregion

            #region Definição de Relacionamentos e Deleção em Cascata
            // A chave estrangeira para a tabela NecessidadeEspecial - CandidatoId
            modelBuilder.Entity<NecessidadeEspecial>().HasRequired(c => c.Candidato)
             .WithMany(p => p.NecessidadesEspeciais).HasForeignKey(p => p.Candidato.CandidatoId);

            // A deleção em cascata a partir de Candidato para NecessidadeEspecial
            modelBuilder.Entity<NecessidadeEspecial>()
                .HasRequired(c => c.Candidato)
                .WithMany(p => p.NecessidadesEspeciais)
                .HasForeignKey(p => p.Candidato.CandidatoId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            // A chave estrangeira para a tabela ExperienciaProfissional - CandidatoId
            modelBuilder.Entity<ExperienciaProfissional>().HasRequired(c => c.Candidato)
             .WithMany(p => p.ExperienciasProfissionais).HasForeignKey(p => p.Candidato.CandidatoId);

            // A deleção em cascata a partir de Candidato para ExperienciaProfissional
            modelBuilder.Entity<ExperienciaProfissional>()
                .HasRequired(c => c.Candidato)
                .WithMany(p => p.ExperienciasProfissionais)
                .HasForeignKey(p => p.Candidato.CandidatoId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);

            // A chave estrangeira para a tabela OutroCurso - CandidatoId
            modelBuilder.Entity<OutroCurso>().HasRequired(c => c.Candidato)
             .WithMany(p => p.OutrosCursos).HasForeignKey(p => p.Candidato.CandidatoId);

            // A deleção em cascata a partir de Candidato para OutroCurso
            modelBuilder.Entity<OutroCurso>()
                .HasRequired(c => c.Candidato)
                .WithMany(p => p.OutrosCursos)
                .HasForeignKey(p => p.Candidato.CandidatoId)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);


            #endregion

        }
    }
}
