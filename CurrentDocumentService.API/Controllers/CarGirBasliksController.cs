using CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById;
using CurrentDocument.Application.Features.CarGirBasliks.Queries.GetCarGirBaslikById.GetAllCarGirBasliks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarGirBasliksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarGirBasliksController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCarGirBasliks()
        {
            var query = new GetAllCarGirBasliksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("GetDetail/{id}")]
        public async Task<IActionResult> GetCarGirBaslikById(int id)
        {
            var result = await _mediator.Send(new GetCarGirBaslikByIdQuery { IND = id });

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
