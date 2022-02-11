using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class CalendarioConfiguration : IEntityTypeConfiguration<Calendario>
    {
        public void Configure(EntityTypeBuilder<Calendario> builder)
        {
            builder.ToTable("tb_calendario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Dia).HasColumnName("dia");
            builder.Property(p => p.HoraInicio).HasColumnName("horario_inicio");
            builder.Property(p => p.HoraFim).HasColumnName("horario_final");
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id").IsRequired();

            builder.HasOne(e => e.Estabelecimento).WithMany(c => c.Calendarios).HasForeignKey(e => e.EstabelecimentoId);
        }
    }
}
