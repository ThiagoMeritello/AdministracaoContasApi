using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracaoContas.Api.ViewModels
{
    public class DespesaParcelaViewModel
    {
        [Key]
        public Guid? Id { get; set; }
        public Guid? IdDespesa { get; set; }
        public Decimal Valor { get; set; }
        public int Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
        public DespesaViewModel Despesa { get; set; }
    }
}
