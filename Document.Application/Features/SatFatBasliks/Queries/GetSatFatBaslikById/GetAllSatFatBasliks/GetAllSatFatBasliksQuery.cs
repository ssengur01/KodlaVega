using Document.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.SatFatBasliks.Queries.GetSatFatBaslikById.GetAllSatFatBasliks
{
    public class GetAllSatFatBasliksQuery : IRequest<List<SatFatBaslikDto>>
    {
    }
}
