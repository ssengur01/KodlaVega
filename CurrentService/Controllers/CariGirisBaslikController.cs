using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariGirisBaslikController : GenericController<CariGirisBaslik> 
    {
        private readonly IRepository<CariGirisBaslik> _repository;
        private readonly FirmaDonemContext _firmaContext;

        public CariGirisBaslikController(IRepository<CariGirisBaslik> repository, FirmaDonemContext firmaContext) : base(repository)
        {
            _repository = repository;
            _firmaContext = firmaContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CariGirisBaslik>>> GetAll()
        {
            if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var all = await _repository.GetAllAsync();

            return Ok(all);
        }


        [HttpGet("firma-no/{firmaNo}")]
        public async Task<ActionResult<IEnumerable<CariGirisBaslik>>> GetByFirmaNo(int firmaNo)
        {
            var list = await _repository.FindAsync(x => x.FirmaNo == firmaNo);
            return Ok(list);
        }

        [HttpGet("belge-no/{belgeNo}")]
        public async Task<ActionResult<IEnumerable<CariGirisBaslik>>> GetByBelgeNo(string belgeNo)
        {
            var list = await _repository.FindAsync(x => x.BelgeNo == belgeNo);
            return Ok(list);
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CariGirisBaslik>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
    }
}











