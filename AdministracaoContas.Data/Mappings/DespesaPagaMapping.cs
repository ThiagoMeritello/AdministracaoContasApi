using AdministracaoContas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracaoContas.Data.Mappings
{
    public class DespesaPagaMapping : IEntityTypeConfiguration<DespesaPaga>
    {
        public void Configure(EntityTypeBuilder<DespesaPaga> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Despesa)
                .WithOne(p => p.DespesaPaga)
                .HasForeignKey<DespesaPaga>(p => p.IdDespesa);

            builder.HasOne(p => p.DespesaParcela)
                .WithOne(p => p.DespesaPaga)
                .HasForeignKey<DespesaPaga>(p => p.IdDespesaParcela);

            builder.ToTable("DespesasPaga");
        }
    }
}
