using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class AgendamentoDisponiveisConfiguration : IEntityTypeConfiguration<AgendamentoDisponiveis>
    {
        public void Configure(EntityTypeBuilder<AgendamentoDisponiveis> builder)
        {
            builder.ToTable("tb_agendamentos_disponiveis");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Data).HasColumnName("data").IsRequired();
            builder.Property(p => p.Hora).HasColumnName("hora").IsRequired();
            builder.Property(p => p.Disponibilidade).HasColumnName("disponibilidade");
            builder.Property(p => p.MedicoId).HasColumnName("fk_medico_id");
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id");

            builder.HasOne(m => m.Medico).WithMany(ad => ad.AgendamentoDisponiveis).HasForeignKey(m => m.MedicoId);
            builder.HasOne(e => e.Estabelecmento).WithMany(ad => ad.AgendamentoDisponiveis).HasForeignKey(e => e.EstabelecimentoId);
        }
    }
}
