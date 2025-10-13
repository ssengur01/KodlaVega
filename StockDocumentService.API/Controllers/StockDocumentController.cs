using CurrentDocument.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockDocument.Application.Strategies.Factory;
using StockDocument.Shared.Enums;

namespace StockDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockDocumentController : ControllerBase
    {
        private readonly IStrategyFactory _strategyFactory;

        public StockDocumentController(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        [HttpGet("{stockType}")]
        public IActionResult GetAll(StockType stockType)
        {
            dynamic strategy = _strategyFactory.GetStrategy(stockType);
            var list = strategy.List();
            return Ok(list);
        }

        [HttpGet("{stockType}/{faturaInd}")]
        public IActionResult GetById(StockType stockType, int faturaInd)
        {
            dynamic strategy = _strategyFactory.GetStrategy(stockType);
            var item = strategy.GetById(faturaInd);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
