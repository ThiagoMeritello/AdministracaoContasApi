using FluentValidation;

namespace AdministracaoContas.Business.Models.Validations
{
    public class DespesaValidation : AbstractValidator<Despesa>
    {
        public DespesaValidation()
        {
            RuleFor(c => c.DataCompra)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Loja)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Produto)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Valor)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.FormaPagamento)
                    .NotEmpty().WithMessage("O Campo {PropertyName} precisa ser fornecido");

        }
    }
}
