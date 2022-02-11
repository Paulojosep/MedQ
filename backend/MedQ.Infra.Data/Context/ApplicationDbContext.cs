using MedQ.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
