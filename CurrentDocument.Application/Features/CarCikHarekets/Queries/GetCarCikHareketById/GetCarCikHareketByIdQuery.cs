using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById
{
    public class GetCarCikHareketByIdQuery : IRequest<List<CarCikHareketDto>>
    {
        public int Ind { get; set; }
    }
}
