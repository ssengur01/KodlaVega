using Current.Application.Repositories;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariCikisBaslikController : GenericController<CariCikisBaslik>
    {

        private readonly IRepository<CariCikisBaslik> _repository;
        private readonly FirmaDonemContext _firmaContext;

        public CariCikisBaslikController(IRepository<CariCikisBaslik> repository, FirmaDonemContext firmaContext) : base(repository)
        {
            _repository = repository;
            _firmaContext = firmaContext;
        }


        [HttpGet("getAll")]
            public async Task<ActionResult<IEnumerable<CariCikisBaslik>>> GetAll()
                
            {
             if (string.IsNullOrEmpty(_firmaContext.FirmaInd))
                return BadRequest("Header'dan FirmaInd gelmedi.");

            var donemInd = _firmaContext.DonemInd;

            var all = await _repository.GetAllAsync();

            return Ok(all);
        }

        
            [HttpGet("{id}")]
            public async Task<ActionResult<CariCikisBaslik>> GetById(int id)
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null) return NotFound();
                return Ok(entity);
            }

            
            [HttpGet("firma-no/{firmaNo}")]
            public async Task<ActionResult<IEnumerable<CariCikisBaslik>>> GetByFirmaNo(int firmaNo)
            {
                var list = await _repository.FindAsync(x => x.FirmaNo == firmaNo);
                return Ok(list);
            }

           
            [HttpGet("belge-no/{belgeNo}")]
            public async Task<ActionResult<IEnumerable<CariCikisBaslik>>> GetByBelgeNo(string belgeNo)
            {
                var list = await _repository.FindAsync(x => x.BelgeNo == belgeNo);
                return Ok(list);
            }

           
            [HttpGet("tarih/{tarih:datetime}")]
            public async Task<ActionResult<IEnumerable<CariCikisBaslik>>> GetByTarih(DateTime tarih)
            {
                var list = await _repository.FindAsync(x => x.Tarih == tarih);
                return Ok(list);
            }

           
            [HttpGet("iptal/{iptal}")]
            public async Task<ActionResult<IEnumerable<CariCikisBaslik>>> GetByIptal(bool iptal)
            {
                var list = await _repository.FindAsync(x => x.Iptal == iptal);
                return Ok(list);
            }
        }
    }

