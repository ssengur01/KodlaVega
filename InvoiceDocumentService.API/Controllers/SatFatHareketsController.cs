using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById;
using Document.Application.Features.AlFatHarekets.Queries.GetAlFatHareketById.GetAllAlFatHarekets;
using Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById;
using Document.Application.Features.SatFatHarekets.Queries.GetSatFatHareketById.GetAllSatFatHarekets;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatFatHareketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SatFatHareketsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSatFatHarekets()
        {
            var query = new GetAllSatFatHareketsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSatFatHareketById(int id)
        {
            var query = new GetSatFatHareketByIdQuery { Ind = id };
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

            var query = new GetAllSatFatHareketByEvrakNoQuery { EvrakNo = evrakNo };
            var result = await _mediator.Send(query);

            if (result == null || !result.Any())
                return NotFound("Fatura hareketleri bulunamadı.");

            return Ok(result);
        }
    }
}
