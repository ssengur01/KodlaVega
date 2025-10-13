using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById.GetCarCikHarekets
{
    public class GetCarCikHareketByEvrakNoQuery : IRequest<List<CarCikHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
