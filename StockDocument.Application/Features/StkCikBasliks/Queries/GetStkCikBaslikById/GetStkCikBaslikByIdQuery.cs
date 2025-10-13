using MediatR;
using StockDocument.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById
{
    public class GetStkCikBaslikByIdQuery : IRequest<StkCikBaslikDto>
    {
        public int IND { get; set; }
    }
}
