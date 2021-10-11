using AdministracaoContas.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdministracaoContas.Data.Mappings
{
    public class FormaPagamentoMapping : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            builder.HasKey(p => p.Codigo);

            builder.Property(p => p.Sigla)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Descricao)
                .HasColumnType("varchar(1000)");

            builder.Ignore(p => p.Id);

            builder.ToTable("FormaPagamento");
        }
    }
}