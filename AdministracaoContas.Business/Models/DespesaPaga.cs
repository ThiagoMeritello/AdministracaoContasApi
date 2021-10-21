using System;

namespace AdministracaoContas.Business.Models
{
    public class DespesaPaga : Entity
    {
        public Guid IdDespesa { get; set; }
        public Guid? IdDespesaParcela { get; set; }
        public DateTime DataRealizadaPagamento { get; set; }
        public Despesa Despesa { get; set; }
        public DespesaParcela DespesaParcela { get; set; }
    }
}
