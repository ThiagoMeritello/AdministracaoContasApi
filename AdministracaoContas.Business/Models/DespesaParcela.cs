using System;
using System.Collections.Generic;
using System.Text;

namespace AdministracaoContas.Business.Models
{
    public class DespesaParcela : Entity
    {
        public Guid IdDespesa { get; set; }
        public Decimal Valor { get; set; }
        public int Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
        public Despesa Despesa { get; set; }
    }
}
