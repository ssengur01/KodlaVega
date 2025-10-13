using Document.Domain.Entities;
using Document.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Repositories
{
    public interface IInvoiceRepository
    {
        IQueryable<AlFatBaslik> AlFatBasliks { get; }
        IQueryable<AlFatHareket> AlFatHarekets { get; }
        IQueryable<SatFatBaslik> SatFatBasliks { get; }
        IQueryable<SatFatHareket> SatFatHarekets { get; }
    }
}
