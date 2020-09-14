using AdministracaoContas.Business.Models;
using System;
using System.Threading.Tasks;

namespace AdministracaoContas.Business.Interfaces
{
    public interface IDespesaService : IDisposable
    {
        Task Adicionar(Despesa despesa);
        Task Atualizar(Despesa despesa);
        Task Remover(Guid id);
    }
}
