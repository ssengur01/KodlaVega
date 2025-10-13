using Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById;
using Document.Application.Features.AlFatBasliks.Queries.GetAlFatBaslikById.GetAllAlFatBasliks;
using Document.Application.Strategies.Factory;
using Document.Shared.Dtos;
using Document.Shared.DTOs;
using Document.Shared.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlFatBasliksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlFatBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAlFatBasliks()
        {
            var query = new GetAllAlFatBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }


        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetAlFatBaslikById(int id)
        {
            var result = await _mediator.Send(new GetAlFatBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}