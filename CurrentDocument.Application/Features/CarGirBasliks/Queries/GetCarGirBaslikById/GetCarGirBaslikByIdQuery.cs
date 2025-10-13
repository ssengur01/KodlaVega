using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById
{
    public class GetCarGirBaslikByIdQuery : IRequest<CarGirBaslikDto?>
    {
        public int IND { get; set; }
    }
}
