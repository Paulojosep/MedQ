using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.Configuration
{
    public class TipoAtendimentoConfiguration : IEntityTypeConfiguration<TipoAtendimento>
    {
        public void Configure(EntityTypeBuilder<TipoAtendimento> builder)
        {
            builder.ToTable("tb_tipo_atendimento");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Tipo).HasColumnName("tipo").IsRequired();
        }
    }
}
