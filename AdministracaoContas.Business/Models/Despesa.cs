using System;
using System.Collections.Generic;

namespace AdministracaoContas.Business.Models
{
    public class Despesa : Entity
    {
        public DateTime DataCompra { get; set; }
        public string Loja { get; set; }
        public string Produto { get; set; }
        public Decimal Valor { get; set; }
        public int CodigoFormaPagamento { get; set; }
        public int? Parcela { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? DiaPagamento { get; set; }
        public IList<DespesaParcela> DespesaParcela { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}
