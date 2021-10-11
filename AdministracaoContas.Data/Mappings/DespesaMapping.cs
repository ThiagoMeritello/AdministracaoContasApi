using AdministracaoContas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracaoContas.Data.Mappings
{
    public class DespesaMapping : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Produto)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Loja)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Valor)
                .HasColumnType("decimal(9,2)");

            builder.HasOne(p => p.FormaPagamento)
                .WithOne(p => p.Despesa)
                .HasForeignKey<Despesa>(p => p.CodigoFormaPagamento);

            builder.ToTable("Despesas");
        }
    }
}
