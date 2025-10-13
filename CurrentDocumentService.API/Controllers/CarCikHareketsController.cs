using CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById;
using CurrentDocument.Application.Features.CarCikHarekets.Queries.GetCarCikHareketById.GetCarCikHarekets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarCikHareketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarCikHareketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarCikHarekets()
        {
            var query = new GetAllCarCikHareketsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarCikHareketById(int id)
        {
            var query = new GetCarCikHareketByIdQuery { Ind = id };
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("Hareket/ByEvrakNo")]
        public async Task<IActionResult> GetByEvrakNo(int evrakNo)
        {
            if (evrakNo <= 0)
                return BadRequest("EvrakNo geçerli bir sayı olmalıdır.");

            var query = new GetCarCikHareketByEvrakNoQuery { EvrakNo = evrakNo };
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Fatura hareketleri bulunamadı.");

            return Ok(result);
        }
    }
}
