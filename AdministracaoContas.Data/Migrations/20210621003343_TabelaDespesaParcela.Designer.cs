﻿// <auto-generated />
using System;
using AdministracaoContas.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdministracaoContas.Data.Migrations
{
    [DbContext(typeof(MeuDbContext))]
    [Migration("20210621003343_TabelaDespesaParcela")]
    partial class TabelaDespesaParcela
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdministracaoContas.Business.Models.Despesa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCompra")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Loja")
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("Parcela")
                        .HasColumnType("int");

                    b.Property<string>("Produto")
                        .HasColumnType("varchar(1000)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("AdministracaoContas.Business.Models.DespesaParcela", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdDespesa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Parcela")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("IdDespesa");

                    b.ToTable("DespesasParcela");
                });

            modelBuilder.Entity("AdministracaoContas.Business.Models.DespesaParcela", b =>
                {
                    b.HasOne("AdministracaoContas.Business.Models.Despesa", "Despesa")
                        .WithMany("DespesaParcela")
                        .HasForeignKey("IdDespesa")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
