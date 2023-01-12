using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.Configuration
{
    public class EstabelecimentoConfiguration : IEntityTypeConfiguration<Estabelecimento>
    {
        public void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            builder.ToTable("tb_estabelecimento");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.CEP).HasColumnName("cep");
            builder.Property(p => p.Endereco).HasColumnName("endereco");
            builder.Property(p => p.Complemento).HasColumnName("complemento");
            builder.Property(p => p.Cidade).HasColumnName("cidade");
            builder.Property(p => p.Bairro).HasColumnName("bairro");
            builder.Property(p => p.Estado).HasColumnName("estado");
            builder.Property(p => p.Image).HasColumnName("image");
            builder.Property(p => p.Data_Cadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.TipoEstabelecimentoId).HasColumnName("fk_tipo_estabelecimento_id").IsRequired();
            builder.Property(p => p.SocioId).HasColumnName("fk_socio_id").IsRequired();

            builder.HasOne(te => te.TipoEstbelecimento).WithMany(e => e.Estabelecimentos).HasForeignKey(te => te.TipoEstabelecimentoId);
            builder.HasOne(s => s.Socio).WithMany(e => e.Estabelecimentos).HasForeignKey(s => s.SocioId);
        }
    }
}
