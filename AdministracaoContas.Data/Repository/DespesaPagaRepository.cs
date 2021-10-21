using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Data.Context;

namespace AdministracaoContas.Data.Repository
{
    public class DespesaPagaRepository : Repository<DespesaPaga>, IDespesaPagaRepository
    {
        public DespesaPagaRepository(MeuDbContext context) : base(context) { }
    }
}
