using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

    namespace CurrentService.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class CariCikisHareketController : GenericController<CariCikisHareket>
    {
            private readonly IRepository<CariCikisHareket> _repository;
        private readonly FirmaDonemContext _firmaContext;

        public CariCikisHareketController(IRepository<CariCikisHareket> repository, FirmaDonemContext firmaContext) : base(repository)
        { 
            _repository = repository;
            _firmaContext = firmaContext;
        }


        [HttpGet("GetCariCikis")]
        public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetAll()
        {
            if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var all = await _repository.GetAllAsync();

            return Ok(all);
        }


        [HttpGet("{id}")]
            public async Task<ActionResult<CariCikisHareket>> GetById(int id)
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return NotFound();
                return Ok(entity);
            }

    
            [HttpGet("firma-no/{firmaNo}")]
            public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetByFirmaNo(int firmaNo)
            {
                var list = await _repository.FindAsync(x => x.FirmaNo == firmaNo);
                return Ok(list);
            }

          
            [HttpGet("belge-no/{belgeNo}")]
            public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetByBelgeNo(string belgeNo)
            {
                var list = await _repository.FindAsync(x => x.BelgeNo == belgeNo);
                return Ok(list);
            }

           
            [HttpGet("vade/{vade:datetime}")]
            public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetByVade(DateTime vade)
            {
                var list = await _repository.FindAsync(x => x.Vade == vade);
                return Ok(list);
            }

            
            [HttpGet("vade-araligi")]
            public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetByVadeAraligi(
                [FromQuery] DateTime baslangic,
                [FromQuery] DateTime bitis)
            {
                var list = await _repository.FindAsync(x => x.Vade >= baslangic && x.Vade <= bitis);
                return Ok(list);
            }

            
            [HttpGet("status/{status}")]
            public async Task<ActionResult<IEnumerable<CariCikisHareket>>> GetByStatus(int status)
            {
                var list = await _repository.FindAsync(x => x.Status == status);
                return Ok(list);
            }
        }
    }














