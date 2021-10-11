using System.ComponentModel.DataAnnotations;

namespace AdministracaoContas.Api.ViewModels
{
    public class FormaPagamentoViewModel
    {
        [Key]
        public int? Codigo { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public DespesaViewModel Despesa { get; set; }
    }
}
