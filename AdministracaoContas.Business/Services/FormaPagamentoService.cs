using AdministracaoContas.Business.Interfaces;

namespace AdministracaoContas.Business.Services
{
    public class FormaPagamentoService : BaseService, IFormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;
        public FormaPagamentoService(IFormaPagamentoRepository formaPagamentoRepository,
            INotificador notificador) : base(notificador)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }
        public void Dispose()
        {
            _formaPagamentoRepository?.Dispose();
        }
    }
}
