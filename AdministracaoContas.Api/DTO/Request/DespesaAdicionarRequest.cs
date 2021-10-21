using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracaoContas.Api.DTO.Request
{
    public class DespesaAdicionarRequest
    {
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
        public int? ValorParcelaFinanciamento { get; set; }
    }
}
