using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Data.Context;

namespace AdministracaoContas.Data.Repository
{
    public class DespesaRepository : Repository<Despesa>, IDespesaRepository
    {
        public DespesaRepository(MeuDbContext context) : base(context) { }
    }
}
