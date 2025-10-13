using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariGirisHareketController : GenericController<CariGirisHareket>
    {
        private readonly IRepository<CariGirisHareket> _repository;
        private readonly FirmaDonemContext _firmaContext;

        public CariGirisHareketController(IRepository<CariGirisHareket> repository, FirmaDonemContext firmaContext) : base(repository)
        {
            _repository = repository;
            _firmaContext = firmaContext;
        }

        [HttpGet("GetCariGiris")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetAll()
        {
            if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var all = await _repository.GetAllAsync();

            return Ok(all);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CariGirisHareket>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        
        [HttpGet("firma-no/{firmaNo}")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetByFirmaNo(int firmaNo)
        {
            var list = await _repository.FindAsync(c => c.FirmaNo == firmaNo);
            return Ok(list);
        }

        
        [HttpGet("belge-no/{belgeNo}")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetByBelgeNo(string belgeNo)
        {
            var list = await _repository.FindAsync(c => c.BelgeNo == belgeNo);
            return Ok(list);
        }

        
        [HttpGet("vade/{vade:datetime}")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetByVade(DateTime vade)
        {
            var list = await _repository.FindAsync(c => c.Vade == vade);
            return Ok(list);
        }

       
        [HttpGet("vade-araligi")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetByVadeAraligi(
            [FromQuery] DateTime baslangic,
            [FromQuery] DateTime bitis)
        {
            var list = await _repository.FindAsync(c => c.Vade >= baslangic && c.Vade <= bitis);
            return Ok(list);
        }

        
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<CariGirisHareket>>> GetByStatus(int status)
        {
            var list = await _repository.FindAsync(c => c.Status == status);
            return Ok(list);
        }
    }
}
