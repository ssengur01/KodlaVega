using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariGenelHareketController : GenericController<CariGenelHareket>
    {
        private readonly IRepository<CariGenelHareket> _repository;
        private readonly FirmaDonemContext _firmaContext;

        public CariGenelHareketController(IRepository<CariGenelHareket> repository, FirmaDonemContext firmaContext) : base(repository)
        {
            _repository = repository;
            _firmaContext = firmaContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetAll()
        {
            if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var all = await _repository.GetAllAsync();

            return Ok(all);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CariGenelHareket>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        
        [HttpGet("firma-no/{firmaNo}")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByFirmaNo(int firmaNo)
        {
            var list = await _repository.FindAsync(x => x.FirmaNo == firmaNo);
            return Ok(list);
        }

       
        [HttpGet("belge-no/{belgeNo}")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByBelgeNo(string belgeNo)
        {
            var list = await _repository.FindAsync(x => x.BelgeNo == belgeNo);
            return Ok(list);
        }

        
        [HttpGet("tarih/{tarih:datetime}")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByTarih(DateTime tarih)
        {
            var list = await _repository.FindAsync(x => x.Tarih == tarih);
            return Ok(list);
        }

        
        [HttpGet("tarih-araligi")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByTarihAraligi(
            [FromQuery] DateTime baslangic,
            [FromQuery] DateTime bitis)
        {
            var list = await _repository.FindAsync(x => x.Tarih >= baslangic && x.Tarih <= bitis);
            return Ok(list);
        }

        
        [HttpGet("vade/{vade:datetime}")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByVade(DateTime vade)
        {
            var list = await _repository.FindAsync(x => x.Vade == vade);
            return Ok(list);
        }

        
        [HttpGet("vade-araligi")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByVadeAraligi(
            [FromQuery] DateTime baslangic,
            [FromQuery] DateTime bitis)
        {
            var list = await _repository.FindAsync(x => x.Vade >= baslangic && x.Vade <= bitis);
            return Ok(list);
        }

        
        [HttpGet("iptal/{iptal}")]
        public async Task<ActionResult<IEnumerable<CariGenelHareket>>> GetByIptal(bool iptal)
        {
            var list = await _repository.FindAsync(x => x.Iptal == iptal);
            return Ok(list);
        }
    }
}














