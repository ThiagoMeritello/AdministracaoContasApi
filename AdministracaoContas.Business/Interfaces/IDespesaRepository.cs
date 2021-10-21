using AdministracaoContas.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdministracaoContas.Business.Interfaces
{
    public interface IDespesaRepository : IRepository<Despesa>
    {
        Task<Despesa> ObterPorIdDespesaParcelada(Guid id);  
        Task<List<Despesa>> ObterPorDespesasFiltro(int mes, int ano, int? formaPagamento);  
    }
}
