﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

#nullable disable

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication2.Models.ClienteModel", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("NmCliente")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("WebApplication2.Models.ProdutoModel", b =>
                {
                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<string>("DscProduto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("VlrUnitario")
                        .HasColumnType("real");

                    b.HasKey("IdProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("WebApplication2.Models.VendaModel", b =>
                {
                    b.Property<int>("IdVenda")
                        .HasColumnType("int");

                    b.Property<int>("ClienteIdCliente")
                        .HasColumnType("int");

                    b.Property<DateTime>("DthVenda")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProduto")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoIdProduto")
                        .HasColumnType("int");

                    b.Property<int>("QtdVenda")
                        .HasColumnType("int");

                    b.Property<float>("VlrUnitarioVenda")
                        .HasColumnType("real");

                    b.HasKey("IdVenda");

                    b.HasIndex("ClienteIdCliente");

                    b.HasIndex("ProdutoIdProduto");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("WebApplication2.Models.VendaModel", b =>
                {
                    b.HasOne("WebApplication2.Models.ClienteModel", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication2.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoIdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}
