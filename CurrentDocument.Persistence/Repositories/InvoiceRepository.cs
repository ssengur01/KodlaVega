using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly CurrentDocumentDbContext _context;

        public InvoiceRepository(CurrentDocumentDbContext context)
        {
            _context = context;
        }

        public IQueryable<CarGirBaslik> CarGirBasliks => _context.CarGirBasliklar;

        public IQueryable<CarGirHareket> CarGirHarekets => _context.CarGirHareketler;

        public IQueryable<CarCikBaslik> CarCikBasliks => _context.CarCikBasliklar;

        public IQueryable<CarCikHareket> CarCikHarekets => _context.CarCikHareketler;

        public IQueryable<CarGirDevirBaslik> CarGirDevirBasliks => _context.CarGirDevirBasliklar;

        public IQueryable<CarGirDevirHareket> CarGirDevirHarekets => _context.CarGirDevirHareketler;

        public IQueryable<CarCikDevirBaslik> CarCikDevirBasliks => _context.CarCikDevirBasliklar;

        public IQueryable<CarCikDevirHareket> CarCikDevirHarekets => _context.CarCikDevirHareketler;
    }
}
