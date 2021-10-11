using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdministracaoContas.Api.ViewModels
{
    public class DespesaViewModel
    {
        [Key]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Loja { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Produto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CodigoFormaPagamento { get; set; }
        public int? Parcela { get; set; }
        public DateTime? DataPagamento { get; set; }
        public int? DiaPagamento { get; set; }
        public IList<DespesaParcelaViewModel> DespesaParcela { get; set; }
        public FormaPagamentoViewModel FormaPagamento { get; set; }
    }
}
