using Document.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AlFatBaslik> AlFatBaslikRepository { get; }
        IRepository<AlFatHareket> AlFatHareketRepository { get; }
        IRepository<SatFatBaslik> SatFatBaslikRepository { get; }
        IRepository<SatFatHareket> SatFatHareketRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
