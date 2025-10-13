using StockDocument.Application.Repositories;
using StockDocument.Domain.Entities;
using StockDocument.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly StockDbContext _context;

        public InvoiceRepository(StockDbContext context)
        {
            _context = context;
        }

        public IQueryable<StkGirBaslik> StkGirBasliks => _context.StkGirBasliklar;

        public IQueryable<StkGirHareket> StkGirHarekets => _context.StkGirHareketler;

        public IQueryable<StkCikBaslik> StkCikBasliks => _context.StkCikBasliklar;

        public IQueryable<StkCikHareket> StkCikHarekets => _context.StkCikHareketler;
    }
}
