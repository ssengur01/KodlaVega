using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDocument.Application.Features.StkGirBasliks.Queries.GetStkGirBaslikById;
using StockDocument.Application.Features.StkGirBasliks.Queries.GetStkGirBaslikById.GetAllStkGirBasliks;

namespace StockDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkGirBasliksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StkGirBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllStkGirBasliks()
        {
            var query = new GetAllStkGirBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetStkGirBaslikById(int id)
        {
            var result = await _mediator.Send(new GetStkGirBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
