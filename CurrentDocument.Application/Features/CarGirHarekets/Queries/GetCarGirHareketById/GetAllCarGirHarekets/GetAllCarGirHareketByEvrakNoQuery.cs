using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById.GetAllCarGirHarekets
{
    public class GetAllCarGirHareketByEvrakNoQuery : IRequest<List<CarGirHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
