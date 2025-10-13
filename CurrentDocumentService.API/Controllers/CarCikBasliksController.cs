using CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById;
using CurrentDocument.Application.Features.CarCikBasliks.Queries.GetCarCikBaslikById.GeAllCarCikBasliks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCikBasliksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarCikBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarCikBasliks()
        {
            var query = new GetAllCarCikBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetCarCikBaslikById(int id)
        {
            var result = await _mediator.Send(new GetCarCikBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
