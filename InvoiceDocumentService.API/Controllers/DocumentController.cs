using Document.Application.Strategies.Factory;
using Document.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IStrategyFactory _strategyFactory;

        public DocumentController(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }


        [HttpGet("{invoiceType}")]
        public IActionResult GetAll(InvoiceType invoiceType)
        {
            dynamic strategy = _strategyFactory.GetStrategy(invoiceType);
            var list = strategy.List();
            return Ok(list);
        }

        [HttpGet("{invoiceType}/{faturaInd}")]
        public IActionResult GetById(InvoiceType invoiceType, int faturaInd)
        {
            dynamic strategy = _strategyFactory.GetStrategy(invoiceType);
            var item = strategy.GetById(faturaInd);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
