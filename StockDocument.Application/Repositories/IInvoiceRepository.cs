using StockDocument.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Repositories
{
    public interface IInvoiceRepository
    {
        IQueryable<StkGirBaslik> StkGirBasliks { get; }
        IQueryable<StkGirHareket> StkGirHarekets { get; }
        IQueryable<StkCikBaslik> StkCikBasliks { get; }
        IQueryable<StkCikHareket> StkCikHarekets { get; }

    }
}
