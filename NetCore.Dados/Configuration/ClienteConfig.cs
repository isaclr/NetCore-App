using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.Configuration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(x => x.Nome).IsRequired(true).IsUnicode(false).HasMaxLength(125);
            builder.Property(x => x.Email).IsRequired(true).IsUnicode(false).HasMaxLength(125);
            builder.Property(x => x.CNPJ).IsRequired(true).IsUnicode(false).HasMaxLength(14);
            builder.Property(x => x.Cep).IsRequired(false).IsUnicode(false).HasMaxLength(10);
            builder.Property(x => x.Rua).IsRequired(false).IsUnicode(false).HasMaxLength(255);
            builder.Property(x => x.Numero).IsRequired(false);
            builder.Property(x => x.Complemento).IsRequired(false).IsUnicode(false).HasMaxLength(50);
            builder.Property(x => x.Cidade).IsRequired(false).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Estado).IsRequired(false).IsUnicode(false).HasMaxLength(50);
            
        }
    }
}
