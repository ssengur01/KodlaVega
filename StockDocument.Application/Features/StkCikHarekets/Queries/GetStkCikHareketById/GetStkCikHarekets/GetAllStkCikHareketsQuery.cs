using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById.GetStkCikHarekets
{
    public class GetAllStkCikHareketsQuery : IRequest<List<StkCikHareketDto>>
    {
    }
}
