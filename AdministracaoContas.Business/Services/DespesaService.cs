using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdministracaoContas.Business.Services
{
    public class DespesaService : BaseService, IDespesaService
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IDespesaParcelaRepository _despesaParcelaRepository;

        public DespesaService(IDespesaRepository despesaRepository,
                             IDespesaParcelaRepository despesaParcelaRepository,
                              INotificador notificador) : base(notificador)
        {
            _despesaRepository = despesaRepository;
            _despesaParcelaRepository = despesaParcelaRepository;
        }

        public async Task Adicionar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;

            await _despesaRepository.Adicionar(despesa);

            AdicionarParcela(despesa);

            await _despesaRepository.SaveChanges();
        }

        public async Task Atualizar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;
            
            await _despesaRepository.Atualizar(despesa);
            
            await _despesaParcelaRepository.RemoverPelaDespesa(despesa.Id);

            AdicionarParcela(despesa);

            await _despesaRepository.SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            await _despesaRepository.Remover(id);
            await _despesaParcelaRepository.RemoverPelaDespesa(id);
            await _despesaRepository.SaveChanges();
        }

        private void AdicionarParcela(Despesa despesa)
        {
            if (despesa.Parcela != null && despesa.Parcela > 1)
            {
                despesa.DespesaParcela = new List<DespesaParcela>();
                for (int parcela = 1; parcela <= despesa.Parcela; parcela++)
                {
                    var despesaParcela = new DespesaParcela()
                    {
                        IdDespesa = despesa.Id,
                        Valor = despesa.Valor / (int)despesa.Parcela,
                        Parcela = parcela,
                        DataPagamento = (DateTime)despesa.DataPagamento?.AddMonths(parcela - 1)
                    };
                    _despesaParcelaRepository.Adicionar(despesaParcela);
                }
            }
        }

        public void Dispose()
        {
            _despesaRepository?.Dispose();
        }
    }
}
