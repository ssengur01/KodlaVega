using Document.Shared.DTOs;
using Document.Shared.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets
{
    public class GetAlFatHareketByEvrakNoQuery : IRequest<List<AlFatHareketDto>>
    {
        public int EvrakNo { get; set; }
    }
}
