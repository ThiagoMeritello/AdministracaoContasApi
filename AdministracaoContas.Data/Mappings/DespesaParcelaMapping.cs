using AdministracaoContas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdministracaoContas.Data.Mappings
{
    public class DespesaParcelaMapping : IEntityTypeConfiguration<DespesaParcela>
    {
        public void Configure(EntityTypeBuilder<DespesaParcela> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataPagamento);

            builder.Property(p => p.Parcela);

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(9,2)");

            builder.HasOne(p => p.Despesa)
                .WithMany(p => p.DespesaParcela)
                .HasForeignKey(p => p.IdDespesa);

            builder.ToTable("DespesasParcela");
        }
    }
}