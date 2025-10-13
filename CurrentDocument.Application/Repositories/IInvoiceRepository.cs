using CurrentDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Repositories
{
    public interface IInvoiceRepository
    {
        IQueryable<CarGirBaslik> CarGirBasliks { get; }
        IQueryable<CarGirHareket> CarGirHarekets { get; }
        IQueryable<CarCikBaslik> CarCikBasliks { get; }
        IQueryable<CarCikHareket> CarCikHarekets { get; }
        IQueryable<CarGirDevirBaslik> CarGirDevirBasliks { get; }
        IQueryable<CarGirDevirHareket> CarGirDevirHarekets { get; }
        IQueryable<CarCikDevirBaslik> CarCikDevirBasliks { get; }
        IQueryable<CarCikDevirHareket> CarCikDevirHarekets { get ; }
    }
}
