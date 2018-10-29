using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCore.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.Configuration
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(x => x.NomeCategoria).IsRequired(true).IsUnicode(false).HasMaxLength(255);
        }
    }
}
