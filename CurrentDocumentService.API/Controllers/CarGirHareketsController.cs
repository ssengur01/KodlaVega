using CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById;
using CurrentDocument.Application.Features.CarGirHarekets.Queries.GetCarGirHareketById.GetAllCarGirHarekets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarGirHareketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarGirHareketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarGirHarekets()
        {
            var query = new GetAllCarGirHareketsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarGirHareketById(int id)
        {
            var query = new GetCarGirHareketByIdQuery { Ind = id };
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

            var query = new GetAllCarGirHareketByEvrakNoQuery { EvrakNo = evrakNo };
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Fatura hareketleri bulunamadı.");

            return Ok(result);
        }
    }
}
