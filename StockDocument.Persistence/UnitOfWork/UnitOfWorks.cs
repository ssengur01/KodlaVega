using StockDocument.Application.Repositories;
using StockDocument.Domain.Entities;
using StockDocument.Infrastructure.Data;
using StockDocument.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Persistence.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly StockDbContext _context;
        private IRepository<StkGirBaslik>? _stkGirBaslikRepository;
        private IRepository<StkGirHareket>? _stkGirHareketRepository;
        private IRepository<StkCikBaslik>? _stkCikBaslikRepository;
        private IRepository<StkCikHareket>? _stkCikHareketRepository;

        public UnitOfWorks(StockDbContext context)
        {
            _context = context;
        }

        public IRepository<StkGirBaslik> StkGirBaslikRepository => _stkGirBaslikRepository ??= new GenericRepository<StkGirBaslik>(_context);

        public IRepository<StkGirHareket> StkGirHareketRepository => _stkGirHareketRepository ??= new GenericRepository<StkGirHareket>(_context);

        public IRepository<StkCikBaslik> StkCikBaslikRepository => _stkCikBaslikRepository ??= new GenericRepository<StkCikBaslik>(_context);

        public IRepository<StkCikHareket> StkCikHareketRepository => _stkCikHareketRepository ?? new GenericRepository<StkCikHareket>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
