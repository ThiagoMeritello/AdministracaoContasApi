using AdministracaoContas.Business.Models;
using System;
using System.Threading.Tasks;

namespace AdministracaoContas.Business.Interfaces
{
    public interface IDespesaParcelaRepository : IRepository<DespesaParcela>
    {
        Task RemoverPelaDespesa(Guid idDespesa);
    }
}
