using Document.Application.Repositories;
using Document.Domain.Entities;
using Document.Infrastructure.Data;
using Document.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DocumentDbContext _context;
        private IRepository<AlFatBaslik>? _alFatBaslikRepository;
        private IRepository<AlFatHareket>? _alFatHareketRepository;
        private IRepository<SatFatBaslik>? _satFatBaslikRepository;
        private IRepository<SatFatHareket>? _satFatHareketRepository;

        public UnitOfWork(DocumentDbContext context)
        {
            _context = context;
        }

        public IRepository<AlFatBaslik> AlFatBaslikRepository => _alFatBaslikRepository ??= new GenericRepository<AlFatBaslik>(_context);

        public IRepository<AlFatHareket> AlFatHareketRepository => _alFatHareketRepository ??= new GenericRepository<AlFatHareket>(_context);

        public IRepository<SatFatBaslik> SatFatBaslikRepository => _satFatBaslikRepository ??= new GenericRepository<SatFatBaslik>(_context);

        public IRepository<SatFatHareket> SatFatHareketRepository => _satFatHareketRepository ??= new GenericRepository<SatFatHareket>(_context);

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
