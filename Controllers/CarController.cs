using Microsoft.AspNetCore.Mvc;
using WebApplicationLar.Entities;
using WebApplicationLar.Services;

namespace WebApplicationLar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarServices _carServices;

        public CarController(ICarServices carServices, ILogger<CarController> logger)
        {
            _logger = logger;
            _carServices = carServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var carListFromDb = await _carServices.GetAll();

                if (carListFromDb == null)
                {
                    return NoContent();
                }

                return Ok(carListFromDb);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var carFromDb = await _carServices.GetById(id);

                if (carFromDb == null)
                {
                    return NoContent();
                }

                return Ok(carFromDb);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Car car)
        {
            try
            {
                await _carServices.Add(car);
                return CreatedAtAction("GetById", new { id = car.Id }, car);
            }
            catch (Exception e )
            {
                _logger.LogError(e.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            try
            {
                await _carServices.Update(car);
                return NoContent();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(ModelState);

            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var telephone = await _carServices.GetById(id);
            if (telephone == null)
            {
                return NotFound();
            }

            await _carServices.Delete(id);
            return NoContent();
        }
    }
}
