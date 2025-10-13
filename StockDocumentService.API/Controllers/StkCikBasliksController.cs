using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById;
using StockDocument.Application.Features.StkCikBasliks.Queries.GetStkCikBaslikById.GetAllStkCikBasliks;

namespace StockDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkCikBasliksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StkCikBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStkCikBasliks()
        {
            var query = new GetAllStkCikBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetStkCikBaslikById(int id)
        {
            var result = await _mediator.Send(new GetStkCikBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
