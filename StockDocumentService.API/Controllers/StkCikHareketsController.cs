using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById;
using StockDocument.Application.Features.StkCikHarekets.Queries.GetStkCikHareketById.GetStkCikHarekets;

namespace StockDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StkCikHareketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StkCikHareketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStkCikHarekets()
        {
            var query = new GetAllStkCikHareketsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStkCikHareketById(int id)
        {
            var query = new GetStkCikHareketByIdQuery { Ind = id };
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

            var query = new GetStkCikHareketByEvrakNoQuery { EvrakNo = evrakNo };
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Fatura hareketleri bulunamadı.");

            return Ok(result);
        }
    }
}
