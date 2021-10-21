using AdministracaoContas.Business.Interfaces;

namespace AdministracaoContas.Business.Services
{
    public class DespesaPagaService : BaseService, IDespesaPagaService
    {
        private readonly IDespesaPagaRepository _despesaPagaRepository;

        public DespesaPagaService(IDespesaPagaRepository despesaPagaRepository,
                              INotificador notificador) : base(notificador)
        {
            _despesaPagaRepository = despesaPagaRepository;
        }

        public void Dispose()
        {
            _despesaPagaRepository?.Dispose();
        }
    }
}
