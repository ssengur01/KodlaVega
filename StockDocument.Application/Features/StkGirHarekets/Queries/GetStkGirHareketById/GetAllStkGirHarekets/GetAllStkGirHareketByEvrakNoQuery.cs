using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById.GetAllStkGirHarekets
{
    public class GetAllStkGirHareketByEvrakNoQuery : IRequest<List<StkGirHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
