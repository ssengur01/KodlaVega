using CurrentService.WEBUI.Models;
using Document.Application.Repositories;
using Document.Domain.Entities;
using Document.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Persistence.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DocumentDbContext _context;

        public InvoiceRepository(DocumentDbContext context)
        {
            _context = context;
        }

        public IQueryable<AlFatBaslik> AlFatBasliks => _context.AlFatBasliklar;

        public IQueryable<AlFatHareket> AlFatHarekets => _context.AlFatHareketler;

        public IQueryable<SatFatBaslik> SatFatBasliks => _context.SatFatBasliklar;
        public IQueryable<SatFatHareket> SatFatHarekets => _context.SatFatHareketler;
    }
}
