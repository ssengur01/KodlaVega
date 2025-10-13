using Current.Application.Repositories;
using Current.Domain.DTOs;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariController : GenericController<Cari>
    {
        private readonly IRepository<Cari> _cariRepo;
        private readonly FirmaDonemContext _firmaContext;
        private readonly RedisCacheRepository _cache;

        public CariController(IRepository<Cari> repository, IRepository<Cari> cariRepo, FirmaDonemContext firmaContext, RedisCacheRepository cache)
            : base(repository)
        {
            _cariRepo = cariRepo;
            _firmaContext = firmaContext;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cari>>> GetAllCariler()
        {
            if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var cacheKey = "cari_listesi";
            var cached = await _cache.GetAsync<List<Cari>>(cacheKey);
            if (cached != null)
                return Ok(cached);

            var cariler = (await _cariRepo.GetAllAsync()).ToList();
            await _cache.SetAsync(cacheKey, cariler, TimeSpan.FromMinutes(10));
            return Ok(cariler);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cari>> GetCari(int id)
        {
            var cari = await _cariRepo.GetByIdAsync(id);
            if (cari == null) return NotFound();
            return Ok(cari);
        }
    }
}




