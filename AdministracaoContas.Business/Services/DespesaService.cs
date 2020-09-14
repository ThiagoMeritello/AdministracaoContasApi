using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace AdministracaoContas.Business.Services
{
    public class DespesaService : BaseService, IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;

        public DespesaService(IDespesaRepository despesaRepository,
                              INotificador notificador) : base(notificador)
        {
            _despesaRepository = despesaRepository;
        }

        public async Task Adicionar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;

            await _despesaRepository.Adicionar(despesa);
        }

        public async Task Atualizar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;

            await _despesaRepository.Atualizar(despesa);
        }

        public async Task Remover(Guid id)
        {
            await _despesaRepository.Remover(id);
        }

        public void Dispose()
        {
            _despesaRepository?.Dispose();
        }        
    }
}
