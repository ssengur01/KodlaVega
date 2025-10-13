using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById.GetAllCarGirBasliks
{
    public class GetAllCarGirBasliksQuery : IRequest<List<CarGirBaslikDto>>
    {
    }
}
