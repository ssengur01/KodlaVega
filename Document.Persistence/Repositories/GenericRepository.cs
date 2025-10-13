using Document.Application.Repositories;
using Document.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Document.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DocumentDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DocumentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

    //    public async Task AddAsync(TEntity entity)
      //  {
        //    await _dbSet.AddAsync(entity);
        //}

//        public void Delete(TEntity entity)
  //      {
    //        _dbSet.Remove(entity);
      //  }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AsNoTracking().SingleOrDefaultAsync(predicate);
        }

    //    public void Update(TEntity entity)
   //     {
     //       _dbSet.Update(entity);
       // }
    }
}
