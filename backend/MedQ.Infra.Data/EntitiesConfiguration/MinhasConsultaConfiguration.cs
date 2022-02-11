using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class MinhasConsultaConfiguration : IEntityTypeConfiguration<MinhasConsulta>
    {
        public void Configure(EntityTypeBuilder<MinhasConsulta> builder)
        {
            builder.ToTable("tb_minhas_consultas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Titulo).HasColumnName("titulo");
            builder.Property(p => p.Resumo).HasColumnName("resumo");
            builder.Property(p => p.Texto).HasColumnName("texto");
            builder.Property(p => p.Pedido).HasColumnName("pedido");
            builder.Property(p => p.Senha).HasColumnName("senha");
            builder.Property(p => p.Profissional).HasColumnName("profissional");
            builder.Property(p => p.Data).HasColumnName("data");
            builder.Property(p => p.Hora).HasColumnName("hora");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.Finished).HasColumnName("finished");
            builder.Property(p => p.ConsultaId).HasColumnName("fk_consultas_id").IsRequired();
            builder.Property(p => p.SocioId).HasColumnName("fk_socio_id").IsRequired();

            builder.HasOne(c => c.Consulta).WithMany(mc => mc.MinhasConsultas).HasForeignKey(c => c.ConsultaId);
            builder.HasOne(s => s.Socio).WithMany(mc => mc.MinhasConsultas).HasForeignKey(s => s.SocioId);
        }
    }
}
