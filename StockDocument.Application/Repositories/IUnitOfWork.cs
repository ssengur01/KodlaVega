using StockDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<StkGirBaslik> StkGirBaslikRepository { get; }
        IRepository<StkGirHareket> StkGirHareketRepository { get; }
        IRepository<StkCikBaslik> StkCikBaslikRepository { get; }
        IRepository<StkCikHareket> StkCikHareketRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
