using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class TipoEstabelecimentoConfiguration : IEntityTypeConfiguration<TipoEstabelecimento>
    {
        public void Configure(EntityTypeBuilder<TipoEstabelecimento> builder)
        {
            builder.ToTable("tb_tipo_estabelecimento");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Tipo).HasColumnName("tipo").IsRequired();
        }
    }
}
