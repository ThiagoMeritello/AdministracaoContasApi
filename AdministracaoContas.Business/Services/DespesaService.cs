using AdministracaoContas.Business.Enum;
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

        #region MethodsPublic
        public async Task Adicionar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;

            await _despesaRepository.Adicionar(despesa);

            GerarDespesaParcela(despesa);

            await _despesaRepository.SaveChanges();
        }

        public async Task Atualizar(Despesa despesa)
        {
            if (!ExecutarValidacao(new DespesaValidation(), despesa)) return;

            await _despesaRepository.Atualizar(despesa);
            await _despesaParcelaRepository.RemoverPelaDespesa(despesa.Id);

            GerarDespesaParcela(despesa);

            await _despesaRepository.SaveChanges();
        }

        public async Task Remover(Guid id)
        {
            await _despesaRepository.Remover(id);
            await _despesaParcelaRepository.RemoverPelaDespesa(id);
            await _despesaRepository.SaveChanges();
        }
        #endregion

        #region MethodsPrivate
        private void GerarDespesaParcela(Despesa despesa)
        {
            //Cadastrar a despesa e realizar o pagamento automatico
            if ((int)EnumDespesa.FormaPagamento.AVista == despesa.CodigoFormaPagamento || (int)EnumDespesa.FormaPagamento.CartaoDebito == despesa.CodigoFormaPagamento)
                AdicionarPagamentoAutomatico(despesa);
            else if ((int)EnumDespesa.FormaPagamento.CartaoCredito == despesa.CodigoFormaPagamento)
                AdicionarParcelaCartaoCredito(despesa);
            else if ((int)EnumDespesa.FormaPagamento.Financiamento == despesa.CodigoFormaPagamento)
                AdicionarParcelaFinanciamento(despesa);
            // Valores mensais, fixo 
            // Serão incluido somente na despesas.
            // Ao consulta para pagamento gerar sempre uma combrança, caso não tenha feito pagamento para o mês vigente(mes da consulta).
        }
        private void AdicionarPagamentoAutomatico(Despesa despesa)
        {
            // Necessidade de criar um tabela de para gerar paragamento. Quando for esta tipo de pagamento realizar o preenchimento automatico para o mês vigente
        }
        private void AdicionarParcelaCartaoCredito(Despesa despesa)
        {
            if (despesa.Parcela != null && despesa.Parcela > 1)
            {
                for (int parcela = 1; parcela <= despesa.Parcela; parcela++)
                {
                    var despesaParcela = new DespesaParcela()
                    {
                        IdDespesa = despesa.Id,
                        Valor = despesa.Valor / (int)despesa.Parcela,
                        Parcela = parcela,
                        DataPagamento = RetornarDataPagamentoCartaoCredito(despesa.DataCompra).AddMonths(parcela - 1)
                    };
                    _despesaParcelaRepository.Adicionar(despesaParcela);
                }
            }
        }
        private DateTime RetornarDataPagamentoCartaoCredito(DateTime dataCompra)
        {
            if (dataCompra.Day < 29)
            {
                return new DateTime(dataCompra.Year, dataCompra.AddMonths(1).Month, 8);
            }

            return new DateTime(dataCompra.Year, dataCompra.AddMonths(2).Month, 8);
        }
        private void AdicionarParcelaFinanciamento(Despesa despesa)
        {
            if (despesa.Parcela != null && despesa.Parcela > 1)
            {
                for (int parcela = 1; parcela <= despesa.Parcela; parcela++)
                {
                    var despesaParcela = new DespesaParcela()
                    {
                        IdDespesa = despesa.Id,
                        Valor = (decimal)despesa.ValorParcelaFinanciamento,
                        Parcela = parcela,
                        DataPagamento = RetornarDataPagamentoFinaciamento(despesa.DataCompra, despesa.DataPagamento, despesa.DiaPagamento)
                        .AddMonths(parcela - 1)
                    };
                    _despesaParcelaRepository.Adicionar(despesaParcela);
                }
            }
        }
        private DateTime RetornarDataPagamentoFinaciamento(DateTime dataCompra, DateTime? dataPagamento, int? diaVencimento)
        {
            if (dataPagamento != null)
                return (DateTime)dataPagamento;
            if (diaVencimento != null)
                return new DateTime(dataCompra.Year, dataCompra.AddMonths(1).Month, (int)diaVencimento);

            return new DateTime(dataCompra.Year, dataCompra.AddMonths(1).Month, 5);
        }
        #endregion

        public void Dispose()
        {
            _despesaRepository?.Dispose();
        }
    }
}
