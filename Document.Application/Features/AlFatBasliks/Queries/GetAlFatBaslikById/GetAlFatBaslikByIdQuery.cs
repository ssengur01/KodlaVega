using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById
{
    public class GetAlFatBaslikByIdQuery : IRequest<AlFatBaslikDto?>
    {
        public int IND { get; set; }
    }
}
