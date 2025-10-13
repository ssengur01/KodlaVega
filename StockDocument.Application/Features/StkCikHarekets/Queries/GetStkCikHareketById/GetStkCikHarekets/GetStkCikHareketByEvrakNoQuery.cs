using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById.GetStkCikHarekets
{
    public class GetStkCikHareketByEvrakNoQuery : IRequest<List<StkCikHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
