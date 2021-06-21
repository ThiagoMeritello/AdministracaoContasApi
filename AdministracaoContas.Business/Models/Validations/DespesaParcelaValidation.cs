using FluentValidation;

namespace AdministracaoContas.Business.Models.Validations
{
    public class DespesaParcelaValidation : AbstractValidator<DespesaParcela>
    {
        public DespesaParcelaValidation()
        {
            RuleFor(c => c.Valor)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Parcela)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.DataPagamento)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

        }
    }
}
