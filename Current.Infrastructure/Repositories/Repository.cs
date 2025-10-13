using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Current.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly CurrentDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        private readonly FirmaDonemContext _firmaDonem;
        private readonly RedisCacheRepository _cache;

        public Repository(CurrentDbContext context, FirmaDonemContext firmaDonem, RedisCacheRepository cache)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _firmaDonem = firmaDonem;
            _cache = cache;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            var cacheKey = typeof(TEntity).Name + "_list";
            var cached = await _cache.GetAsync<List<TEntity>>(cacheKey);
            if (cached != null)
                return cached;

            var all = await _dbSet.ToListAsync();
            if (filter != null)
                all = all.AsQueryable().Where(filter).ToList();

            await _cache.SetAsync(cacheKey, all, TimeSpan.FromMinutes(10));
            return all;
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

     
        //public async Task<IEnumerable<TEntity>> GetByLnAsync(int ln)
     //   {
       //     if (typeof(TEntity) != typeof(CariHareketleri))
         //       throw new NotSupportedException("GetByLnAsync sadece CariHareketleri için kullanılabilir.");

           // return await _dbSet
             //   .Cast<CariHareketleri>()
             //   .Where(c => c.Ln == ln)
             //   .Cast<TEntity>()
             //   .ToListAsync();
        }
    }
