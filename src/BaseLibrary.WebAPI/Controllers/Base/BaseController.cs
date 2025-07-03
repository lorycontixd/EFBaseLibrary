using BaseLibrary.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppLibraryTest.Controllers
{
    public interface IBaseController<TEntity> where TEntity : class
    {
        public Task<ActionResult<IEnumerable<TEntity>>> GetAll();
        public Task<ActionResult<TEntity>> Get(int id);
        public Task<IActionResult> Create([FromBody] TEntity value);
        public Task<IActionResult> Update(int id, [FromBody] TEntity value);
        public Task<IActionResult> Delete(int id);
    }

    [ApiController]
    [Route("api/RTF/[controller]")]
    public abstract class BaseController<TEntity>(IBaseService<TEntity> service) : ControllerBase, IBaseController<TEntity> where TEntity : class
    {
        protected readonly IBaseService<TEntity> _service = service;
        private readonly ILogger<BaseController<TEntity>> _logger;
        private readonly ILoggingService _loggingService;

        public BaseController(IBaseService<TEntity> service, ILogger<BaseController<TEntity>> logger) : this(service)
        {
            _logger = logger;
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TEntity value)
        {
            if (value == null)
            {
                _logger.LogError($"Received null value for POST request for entity type {typeof(TEntity)}");
                return BadRequest($"Invalid data for POST request for entity type {typeof(TEntity)}");
            }

            try
            {
                await _service.AddAsync(value);
                return CreatedAtAction(nameof(get), new { id = value.GetType().GetProperty("Id")?.GetValue(value, null) }, value);
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, $"Database update error occurred while creating entity of type {typeof(TEntity)}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Database update error while creating data.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while creating entity of type {typeof(TEntity)}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error while creating data.");
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> get(int id)
        {
            try
            {
                var value = await _service.GetByIdAsync(id);
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting entity of type {typeof(TEntity)} with ID {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error while fetching data.");
            }
        }

        public Task<ActionResult<TEntity>> Get(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> getAll()
        {
            try
            {
                var values = await _service.GetAllAsync();
                return Ok(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while getting all entities of type {typeof(TEntity)}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error while fetching data.");
            }
        }

        public Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<IActionResult> Update(int id, [FromBody] TEntity value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
