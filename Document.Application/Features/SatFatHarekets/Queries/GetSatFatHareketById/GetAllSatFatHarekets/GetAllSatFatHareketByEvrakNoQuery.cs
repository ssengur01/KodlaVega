using Document.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById.GetAllSatFatHarekets
{
    public class GetAllSatFatHareketByEvrakNoQuery : IRequest<List<SatFatHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
