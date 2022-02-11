using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class ConsultasConfiguration : IEntityTypeConfiguration<Consultas>
    {
        public void Configure(EntityTypeBuilder<Consultas> builder)
        {
            builder.ToTable("tb_consultas");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Data).HasColumnName("data").IsRequired();
            builder.Property(p => p.Hora).HasColumnName("hora").IsRequired();
            builder.Property(p => p.Status).HasColumnName("status").IsRequired();
            builder.Property(p => p.Senha).HasColumnName("senha");
            builder.Property(p => p.AgendamentoId).HasColumnName("fk_agendamento_id").IsRequired();
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id").IsRequired();
            builder.Property(p => p.SocioId).HasColumnName("fk_socio_id").IsRequired();

            builder.HasOne(a => a.Agendamento).WithMany(c => c.Consultas).HasForeignKey(a => a.AgendamentoId);
            builder.HasOne(e => e.Estabelecimento).WithMany(c => c.Consultas).HasForeignKey(e => e.EstabelecimentoId);
            builder.HasOne(s => s.Socio).WithMany(c => c.Consultas).HasForeignKey(s => s.SocioId);
        }
    }
}
