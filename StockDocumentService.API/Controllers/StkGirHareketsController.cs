using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById;
using StockDocument.Application.Features.StkGirHarekets.Queries.GetStkGirHareketById.GetAllStkGirHarekets;

namespace StockDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkGirHareketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StkGirHareketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStkGirHarekets()
        {
            var query = new GetAllStkGirHareketsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStkGirHareketById(int id)
        {
            var query = new GetStkGirHareketByIdQuery { Ind = id };
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

            var query = new GetAllStkGirHareketByEvrakNoQuery { EvrakNo = evrakNo };
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Fatura hareketleri bulunamadı.");

            return Ok(result);
        }
    }
}
