﻿using System;

namespace AdministracaoContas.Business.Models
{
    public class DespesaParcela : Entity
    {
        public Guid IdDespesa { get; set; }
        public Decimal Valor { get; set; }
        public int Parcela { get; set; }
        public DateTime DataPagamento { get; set; }
        public Despesa Despesa { get; set; }
        public DespesaPaga DespesaPaga { get; set; }
    }
}
