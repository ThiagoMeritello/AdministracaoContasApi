using AdministracaoContas.Business.Interfaces;
using AdministracaoContas.Business.Models;
using AdministracaoContas.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdministracaoContas.Data.Repository
{
    public class DespesaParcelaRepository : Repository<DespesaParcela>, IDespesaParcelaRepository
    {
        public DespesaParcelaRepository(MeuDbContext context) : base(context) { }
    }
}
