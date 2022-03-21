using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class MensagensConfiguration : IEntityTypeConfiguration<Mensagens>
    {
        public void Configure(EntityTypeBuilder<Mensagens> builder)
        {
            builder.ToTable("tb_mensagens");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Titulo).HasColumnName("titulo");
            builder.Property(p => p.Resumo).HasColumnName("resumo");
            builder.Property(p => p.Texto).HasColumnName("texto");
            builder.Property(p => p.Data).HasColumnName("data");
            builder.Property(p => p.Hora).HasColumnName("hora");
            builder.Property(p => p.Viewd).HasColumnName("viewed");
            builder.Property(p => p.SocioId).HasColumnName("fk_socio_id").IsRequired();

            builder.HasOne(s => s.Socio).WithMany(m => m.Mensagens).HasForeignKey(s => s.SocioId);
        }
    }
}
