using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedQ.Infra.Data.EntitiesConfiguration
{
    public class FilaConfiguration : IEntityTypeConfiguration<Fila>
    {
        public void Configure(EntityTypeBuilder<Fila> builder)
        {
            builder.ToTable("tb_fila");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.QtdPessoas).HasColumnName("qtd_pessoas");
            builder.Property(p => p.Status).HasColumnName("status");
            builder.Property(p => p.DataCadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.TipoAntendimentoId).HasColumnName("fk_tipo_atendimento_id").IsRequired();
            builder.Property(p => p.EstabelecimentoId).HasColumnName("fk_estabelecimento_id").IsRequired();
            builder.Property(p => p.EspecialidadeId).HasColumnName("fk_especialidade_id").IsRequired();

            builder.HasOne(ta => ta.TipoAtendimento).WithMany(f => f.Filas).HasForeignKey(ta => ta.TipoAntendimentoId);
            builder.HasOne(e => e.Estabelecimento).WithMany(f => f.Filas).HasForeignKey(e => e.EstabelecimentoId);
            builder.HasOne(e => e.Especialidade).WithMany(f => f.Filas).HasForeignKey(e => e.EspecialidadeId);
        }
    }
}
