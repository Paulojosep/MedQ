using MedQ.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedQ.Infra.Data.Configuration
{
    public class SocioConfiguration : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.ToTable("tb_socio");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.Sexo).HasColumnName("sexo");
            builder.Property(p => p.CPF).HasColumnName("cpf");
            builder.Property(p => p.Email).HasColumnName("email");
            builder.Property(p => p.Senha).HasColumnName("senha");
            builder.Property(p => p.Endereco).HasColumnName("endereco");
            builder.Property(p => p.Complemento).HasColumnName("complemento");
            builder.Property(p => p.Cidade).HasColumnName("cidade");
            builder.Property(p => p.Bairro).HasColumnName("bairro");
            builder.Property(p => p.UF).HasColumnName("uf");
            builder.Property(p => p.Data_Cadastro).HasColumnName("data_cadastro");
            builder.Property(p => p.Image).HasColumnName("image");
            builder.Property(p => p.CodigoVerificacao).HasColumnName("codigo_verificacao");
            builder.Property(p => p.IdGoogle).HasColumnName("id_google");
            builder.Property(p => p.Tipo).HasColumnName("tipo");
        }
    }
}
