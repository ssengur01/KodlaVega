using CurrentDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<CarGirBaslik> CarGirBaslikRepository { get; }
        IRepository<CarGirHareket> CarGirHareketRepository { get; }
        IRepository<CarCikBaslik> CarCikBaslikRepository { get; }
        IRepository<CarCikHareket> CarCikHareketRepository { get; }
        IRepository<CarGirDevirBaslik> CarGirDevirBaslikRepository{ get; }
        IRepository<CarGirDevirHareket> CarGirDevirHareketRepository { get; }
        IRepository<CarCikDevirBaslik> CarCikDevirBaslikRepository { get; }
        IRepository<CarCikDevirHareket> CarCikDevirHareketRepository{ get; }

        Task<int> SaveChangesAsync();
    }
}
