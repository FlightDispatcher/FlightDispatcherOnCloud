using FlightDispatcher.Infostructure.Repositories;
using FlightDispatcher.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirportsController : Controller
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly AirportRepository _airportRepository;

        public AirportsController(ILogger<AirportsController> logger, AirportRepository airportRepository)
        {
            _logger = logger;
            _airportRepository = airportRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var airports = await _airportRepository.GetAll();

            return Ok(airports.ToModelList());
        }
    }
}
