using Document.Shared.Dtos;
using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById.GetAllSatFatHarekets
{
    public class GetAllSatFatHareketsQuery : IRequest<List<SatFatHareketDto>>
    {
    }
}
