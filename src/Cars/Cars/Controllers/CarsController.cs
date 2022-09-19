using Microsoft.AspNetCore.Mvc;
using Cars.Dtos;
using Cars.Repositories;

namespace Cars.Controllers
{
    [ApiController]
    [Route("api/cars")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarSummary>>> Index()
        {
            var results = await _carRepository.GetCarsAsync();
            return Ok(results);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarDetails>> Details(int id)
        {
            var results = await _carRepository.GetCarAsync(id);

            if (results is null)
                return NotFound();

            return Ok(results);
        }
    }
}
