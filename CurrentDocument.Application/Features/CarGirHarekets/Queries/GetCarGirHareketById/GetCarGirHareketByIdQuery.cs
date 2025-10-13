using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById
{
    public class GetCarGirHareketByIdQuery : IRequest<List<CarGirHareketDto>>
    {
        public int Ind { get; set; }
    }
}
