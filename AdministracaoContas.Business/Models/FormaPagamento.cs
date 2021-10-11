namespace AdministracaoContas.Business.Models
{
    public class FormaPagamento : Entity
    {
        public int Codigo { get; set; }
        public string Sigla { get; set; }
        public string Descricao { get; set; }
        public Despesa Despesa { get; set; }
    }
}
