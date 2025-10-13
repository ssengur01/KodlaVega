using Current.Application.Repositories;
using Current.Domain.DTOs;
using Current.Domain.Entities;
using Current.Infrastructure.Data;
using CurrentService.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CurrentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariHareketleriController : GenericController<CariHareketleri>
    {    
        private readonly IRepository<CariHareketleri> _repository;
        private readonly FirmaDonemContext _firmaContext;
        private readonly CurrentDbContext _context;

        public CariHareketleriController(IRepository<CariHareketleri> repository, FirmaDonemContext firmaContext, CurrentDbContext context) : base(repository)
        {
            _repository = repository;
            _firmaContext = firmaContext;
            _context = context;
        }

        [HttpGet("GetCariHareketleri")]
        public async Task<ActionResult<IEnumerable<CariHareketleri>>> GetAllCariHareketleri()
        {
           var all = await _repository.GetAllAsync();              
           return Ok(all);
        }

        
        [HttpGet("{cariId}")]
        public async Task<ActionResult<IEnumerable<CariHareketleriDto>>> GetByCariId(int cariId)
        {
            var firstHareket = await _context.CariHareketleri
       .Where(c => c.FirmaNo == cariId)
       .OrderBy(c => c.Tarih)
       .FirstOrDefaultAsync();

            if (firstHareket == null)
                return NotFound("Cari hareketleri bulunamadý.");

            int ln = firstHareket.Ln ?? 0;

            var hareketler = await _context.CariHareketleri
                .Where(c => c.FirmaNo == cariId)
                .Select(c => new CariHareketleriDto
                {
                    FirmaNo = c.FirmaNo,
                    Tarih = c.Tarih,
                    Izahat = c.Izahat,
                    EvrakNo = c.EvrakNo,
                    Borc = c.Borc,
                    Alacak = c.Alacak,
                    Bakiye = c.Bakiye,
                    Ln = c.Ln,
                    Iade = c.Iade,
                    Ln2 = c.Ln2,
                    ConvNum = c.ConvNum,
                    ConvStyle = c.ConvStyle,
                    ParaBirimi = c.ParaBirimi,
                    Kur = c.Kur,
                    OdemeTarihi = c.OdemeTarihi,
                    IslemTarihi = c.IslemTarihi,
                    SiralamaTarihi = c.SiralamaTarihi,
                    OzelKod = c.OzelKod,
                    SiralamaTarihiEx = c.SiralamaTarihiEx,
                    IzahatFromFunction = _context.GetIzahatFromFunction(Convert.ToInt32(c.Izahat))
                })
                .ToListAsync();

            return Ok(hareketler);
        }


        [HttpGet("firma-no/{firmaNo}")]
        public async Task<ActionResult<IEnumerable<CariHareketleri>>> GetByFirmaNo(int firmaNo)
        {
            Expression<Func<CariHareketleri, bool>> filter = c => c.FirmaNo == firmaNo;
            var list = await _repository.FindAsync(filter);
            return Ok(list);
        }

       
        [HttpGet("evrak-no/{evrakNo}")]
        public async Task<ActionResult<IEnumerable<CariHareketleri>>> GetByEvrakNo(string evrakNo)
        {
            Expression<Func<CariHareketleri, bool>> filter = c => c.EvrakNo == evrakNo;
            var list = await _repository.FindAsync(filter);
            return Ok(list);
        }

        
        [HttpGet("iade/{iade}")]
        public async Task<ActionResult<IEnumerable<CariHareketleri>>> GetByIade(bool iade)
        {
            Expression<Func<CariHareketleri, bool>> filter = c => c.Iade == iade;
            var list = await _repository.FindAsync(filter);
            return Ok(list);
        }

        
        [HttpGet("para-birimi/{paraBirimi}")]
        public async Task<ActionResult<IEnumerable<CariHareketleri>>> GetByParaBirimi(string paraBirimi)
        {
            Expression<Func<CariHareketleri, bool>> filter = c => c.ParaBirimi == paraBirimi;
            var list = await _repository.FindAsync(filter);
            return Ok(list);
        }
    }
}
