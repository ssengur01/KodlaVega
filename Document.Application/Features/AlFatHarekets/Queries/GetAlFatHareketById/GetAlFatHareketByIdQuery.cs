using Document.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById
{
    public class GetAlFatHareketByIdQuery : IRequest<List<AlFatHareketDto>>
    {
        public int Ind { get; set; }
    }
}
