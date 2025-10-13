using CurrentDocument.Application.Repositories;
using CurrentDocument.Domain.Entities;
using CurrentDocument.Infrastructure.Data;
using CurrentDocument.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Persistence.UnitOfWork
{
    public class UnitOfWorks : IUnitOfWork
    {
        private readonly CurrentDocumentDbContext _context;
        private IRepository<CarGirBaslik>? _carGirBaslikRepository;
        private IRepository<CarGirHareket>? _carGirHareketRepository;
        private IRepository<CarCikBaslik>? _carCikBaslikRepository;
        private IRepository<CarCikHareket>? _carCikHareketRepository;
        private IRepository<CarGirDevirBaslik>? _carGirDevirBaslikRepository;
        private IRepository<CarGirDevirHareket>? _carGirDevirHareketRepository;
        private IRepository<CarCikDevirBaslik>? _carCikDevirBaslikRepository;
        private IRepository<CarCikDevirHareket>? _carCikDevirHareketRepository;

        public UnitOfWorks(CurrentDocumentDbContext context)
        {
            _context = context;
        }

        public IRepository<CarGirBaslik> CarGirBaslikRepository => _carGirBaslikRepository ??= new GenericRepository<CarGirBaslik>(_context);

        public IRepository<CarGirHareket> CarGirHareketRepository => _carGirHareketRepository ??= new GenericRepository<CarGirHareket>(_context);

        public IRepository<CarCikBaslik> CarCikBaslikRepository => _carCikBaslikRepository ??= new GenericRepository<CarCikBaslik>(_context);

        public IRepository<CarCikHareket> CarCikHareketRepository => _carCikHareketRepository ??= new GenericRepository<CarCikHareket>(_context);

        public IRepository<CarGirDevirBaslik> CarGirDevirBaslikRepository => _carGirDevirBaslikRepository ??= new GenericRepository<CarGirDevirBaslik>(_context);

        public IRepository<CarGirDevirHareket> CarGirDevirHareketRepository => _carGirDevirHareketRepository ??= new GenericRepository<CarGirDevirHareket>(_context);

        public IRepository<CarCikDevirBaslik> CarCikDevirBaslikRepository => _carCikDevirBaslikRepository ??= new GenericRepository<CarCikDevirBaslik>(_context);

        public IRepository<CarCikDevirHareket> CarCikDevirHareketRepository => _carCikDevirHareketRepository ??= new GenericRepository<CarCikDevirHareket>(_context);

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
