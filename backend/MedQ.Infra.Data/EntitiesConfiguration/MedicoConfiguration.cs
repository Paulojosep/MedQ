using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    class MedicoConfiguration : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("tb_medicos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome").IsRequired();
            builder.Property(p => p.CPF).HasColumnName("cpf");
            builder.Property(p => p.EspecialidadeId).HasColumnName("fk_especialidade_id").IsRequired();
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id").IsRequired();

            builder.HasOne(e => e.Especialidade).WithMany(m => m.Medicos).HasForeignKey(e => e.EspecialidadeId);
            builder.HasOne(e => e.Estabelecimento).WithMany(m => m.Medicos).HasForeignKey(e => e.EstabelecimentoId);
        }
    }
}
