using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById.GetAllAlFatBasliks
{
    public class GetAllAlFatBasliksQuery : IRequest<List<AlFatBaslikDto>>
    {
    }
}
