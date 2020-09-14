using System;

namespace AdministracaoContas.Business.Models
{
    public class Despesa : Entity
    {
        public DateTime DataCompra { get; set; }
        public string Loja { get; set; }
        public string Produto { get; set; }
        public Decimal Valor { get; set; }
        public string FormaPagamento { get; set; }
        public int Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
