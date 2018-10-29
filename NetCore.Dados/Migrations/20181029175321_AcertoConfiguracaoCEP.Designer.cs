﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetCore.Dados.Contexto;

namespace NetCore.Dados.Migrations
{
    [DbContext(typeof(ContextoDB))]
    [Migration("20181029175321_AcertoConfiguracaoCEP")]
    partial class AcertoConfiguracaoCEP
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetCore.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("NetCore.Dominio.Entidades.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(14)
                        .IsUnicode(false);

                    b.Property<int>("CategoriaId");

                    b.Property<string>("Cep")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("Cidade")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Complemento")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .IsUnicode(false);

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(125)
                        .IsUnicode(false);

                    b.Property<int?>("Numero");

                    b.Property<string>("Rua")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("NetCore.Dominio.Entidades.Cliente", b =>
                {
                    b.HasOne("NetCore.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
