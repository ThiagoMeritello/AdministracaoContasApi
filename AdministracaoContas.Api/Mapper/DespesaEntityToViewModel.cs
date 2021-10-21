using AdministracaoContas.Api.DTO.Request;
using AdministracaoContas.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracaoContas.Api.Mapper
{
    public static class DespesaEntityToViewModel
    {
        public static Despesa ToResponse(this DespesaAdicionarRequest entity)
        {
            var despesa = new Despesa();
            despesa.DataCompra = entity.DataCompra;
            despesa.Loja = entity.Loja;
            despesa.Produto = entity.Produto;
            despesa.Valor = entity.Valor;
            despesa.CodigoFormaPagamento = entity.CodigoFormaPagamento;
            despesa.Parcela = entity.Parcela;
            despesa.DataPagamento = entity.DataPagamento;
            despesa.DiaPagamento = entity.DiaPagamento;
            despesa.ValorParcelaFinanciamento = entity.ValorParcelaFinanciamento;

            return despesa;
        }
    }
}
