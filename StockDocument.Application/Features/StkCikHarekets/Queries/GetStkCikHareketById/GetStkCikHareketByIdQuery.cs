using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById
{
    public class GetStkCikHareketByIdQuery : IRequest<List<StkCikHareketDto>>
    {
        public int Ind { get; set; }
    }
}
