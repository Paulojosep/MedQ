using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.Configuration
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("tb_telefone");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.DDD).HasColumnName("DDD");
            builder.Property(p => p.Numero).HasColumnName("numero");
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id");
            builder.Property(p => p.SocioId).HasColumnName("tb_socio_id");

            builder.HasOne(e => e.Estabelecimento).WithMany(t => t.Telefones).HasForeignKey(e => e.EstabelecimentoId);
            builder.HasOne(s => s.Socio).WithMany(t => t.Telefones).HasForeignKey(s => s.SocioId);
        }
    }
}
