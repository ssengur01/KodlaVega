using Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById;
using Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById.GetAllAlFatBasliks;
using Document.Application.Features.SatFatBasliks.Queries.GetSatFatBaslikById;
using Document.Application.Features.SatFatBasliks.Queries.GetSatFatBaslikById.GetAllSatFatBasliks;
using Document.Application.Strategies.Factory;
using Document.Shared.Dtos;
using Document.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatFatBasliksController : ControllerBase
    {
       private readonly IMediator _mediator;

        public SatFatBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSatFatBasliks()
        {
            var query = new GetAllSatFatBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetSatFatBaslikById(int id)
        {
            var result = await _mediator.Send(new GetSatFatBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
