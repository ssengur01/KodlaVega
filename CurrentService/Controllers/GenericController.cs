using Current.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public GenericController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet("getGeneric")]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return Ok(list);
        }

        [HttpGet("generic/{id}")]
        public virtual async Task<ActionResult<TEntity>> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return NotFound();
            return Ok(entity);
        }
    }
}
