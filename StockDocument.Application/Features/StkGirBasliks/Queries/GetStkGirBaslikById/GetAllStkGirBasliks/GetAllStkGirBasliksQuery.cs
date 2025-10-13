using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirBasliks.Queries.GetStkGirBaslikById.GetAllStkGirBasliks
{
    public class GetAllStkGirBasliksQuery : IRequest<List<StkGirBaslikDto>>
    {
    }
}
