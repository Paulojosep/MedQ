using MedQ.Domain.Entities;
using MedQ.Infra.Data.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.Data.Context
{
    public class MedQContext : IdentityDbContext
    {
        public MedQContext(DbContextOptions<MedQContext> options) : base(options)
        {}

        public MedQContext()
        {}

        public DbSet<AgendamentoDisponiveis> AgendamentoDisponiveis { get; set; }
        public DbSet<Calendario> Calendario { get; set; }
        public DbSet<Consultas> Consultas { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Estabelecimento> Estabelecimento { get; set; }
        public DbSet<Fila> Fila { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
        public DbSet<MinhasConsulta> MinhasConsulta { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoAtendimento> TipoAtendimento { get; set; }
        public DbSet<TipoEstabelecimento> TipoEstabelecimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoDisponiveisConfiguration());
            modelBuilder.ApplyConfiguration(new CalendarioConfiguration());
            modelBuilder.ApplyConfiguration(new ConsultasConfiguration());
            modelBuilder.ApplyConfiguration(new EspecialidadeConfiguration());
            modelBuilder.ApplyConfiguration(new EstabelecimentoConfiguration());
            modelBuilder.ApplyConfiguration(new FilaConfiguration());
            modelBuilder.ApplyConfiguration(new MedicoConfiguration());
            modelBuilder.ApplyConfiguration(new MensagensConfiguration());
            modelBuilder.ApplyConfiguration(new MinhasConsultaConfiguration());
            modelBuilder.ApplyConfiguration(new SocioConfiguration());
            modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            modelBuilder.ApplyConfiguration(new TipoAtendimentoConfiguration());
            modelBuilder.ApplyConfiguration(new TipoEstabelecimentoConfiguration());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedQContext).Assembly);
        }
    }
}
