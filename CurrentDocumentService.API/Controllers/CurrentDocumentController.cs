using CurrentDocument.Application.Strategies.Factory;
using CurrentDocument.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentDocumentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentDocumentController : ControllerBase
    {
        private readonly IStrategyFactory _strategyFactory;

        public CurrentDocumentController(IStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }


        [HttpGet("{currentType}")]
        public IActionResult GetAll(CurrentType currentType)
        {
            dynamic strategy = _strategyFactory.GetStrategy(currentType);
            var list = strategy.List();
            return Ok(list);
        }

        [HttpGet("{currentType}/{faturaInd}")]
        public IActionResult GetById(CurrentType currentType, int faturaInd)
        {
            dynamic strategy = _strategyFactory.GetStrategy(currentType);
            var item = strategy.GetById(faturaInd);
            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
