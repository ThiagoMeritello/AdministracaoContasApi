using AdministracaoContas.Business.Enum;
using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracaoContas.Data.Repository
{
    public class DespesaRepository : Repository<Despesa>, IDespesaRepository
    {
        public DespesaRepository(MeuDbContext context) : base(context) { }

        public async Task<List<Despesa>> ObterPorDespesasFiltro(int mes, int ano, int? codigoFormaPagamento)
        {
            var despesas = new List<Despesa>();
            DateTime dataInicio = new DateTime(ano, mes, 1);
            DateTime dataFinal = dataInicio.AddMonths(1);

            //Despesa financiamento, credito
            var despesasParceladas = await Db.dbDespesas
               .Include(i => i.DespesaParcela.Where(x => x.DataPagamento >= dataInicio && x.DataPagamento < dataFinal)).AsNoTracking()
               .Include(i => i.FormaPagamento).AsNoTracking()
               .Where(x => (x.CodigoFormaPagamento == (int)EnumDespesa.FormaPagamento.CartaoCredito ||
                           x.CodigoFormaPagamento == (int)EnumDespesa.FormaPagamento.Financiamento) &&
                           (codigoFormaPagamento == null || x.CodigoFormaPagamento == codigoFormaPagamento))
               .AsNoTracking().ToListAsync();
            despesas.AddRange(despesasParceladas);

            //Despesa a vista
            var despesasAVista = await Db.dbDespesas
               .Include(i => i.FormaPagamento).AsNoTracking()
               .Where(x => x.DataPagamento >= dataInicio && x.DataPagamento < dataFinal)
               .Where(x => (x.CodigoFormaPagamento == (int)EnumDespesa.FormaPagamento.AVista ||
                           x.CodigoFormaPagamento == (int)EnumDespesa.FormaPagamento.CartaoDebito) &&
                           (codigoFormaPagamento == null || x.CodigoFormaPagamento == codigoFormaPagamento))
               .AsNoTracking().ToListAsync();
            despesas.AddRange(despesasAVista);

            //Mensal, fixo
            var despesasMensal = await Db.dbDespesas
               .Include(i => i.FormaPagamento).AsNoTracking()
               .Where(x => x.DataPagamento >= dataInicio && x.DataPagamento < dataFinal)
               .Where(x => (x.CodigoFormaPagamento == (int)EnumDespesa.FormaPagamento.Mensal) &&
                           (codigoFormaPagamento == null || x.CodigoFormaPagamento == codigoFormaPagamento))
               .AsNoTracking().ToListAsync();
            despesas.AddRange(despesasMensal);

            foreach (var itemDespesa in despesas)
            {
                itemDespesa.FormaPagamento.Despesa = null;
                foreach (var itemDespesaParcelain in itemDespesa.DespesaParcela)
                    itemDespesaParcelain.Despesa = null;
            }

            return despesas;
        }

        public async Task<Despesa> ObterPorIdDespesaParcelada(Guid id)
        {
            var despesa = await Db.dbDespesas
                        .Include(i => i.DespesaParcela)
                        .Include(i => i.FormaPagamento)
                        .Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();

            despesa.FormaPagamento.Despesa = null;
            foreach (var item in despesa.DespesaParcela)
                item.Despesa = null;

            return despesa;
        }
    }
}
