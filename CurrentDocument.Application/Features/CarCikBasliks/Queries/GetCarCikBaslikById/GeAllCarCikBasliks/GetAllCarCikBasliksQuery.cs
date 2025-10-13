using CurrentDocument.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById.GeAllCarCikBasliks
{
    public class GetAllCarCikBasliksQuery : IRequest<List<CarCikBaslikDto>>
    {
    }
}
