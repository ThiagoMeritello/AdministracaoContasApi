using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracaoContas.Data.Repository
{
    public class DespesaParcelaRepository : Repository<DespesaParcela>, IDespesaParcelaRepository
    {
        public DespesaParcelaRepository(MeuDbContext context) : base(context) { }

        public async Task RemoverPelaDespesa(Guid idDespesa)
        {
            DbSet.RemoveRange(await ObterDespesaParcelaPorIdDespesa(idDespesa));
        }
        public async Task<IEnumerable<DespesaParcela>> ObterDespesaParcelaPorIdDespesa(Guid idDespesa)
        {
            return await DbSet.AsNoTracking().Where(d => d.IdDespesa == idDespesa).ToListAsync();
        }
    }
}
