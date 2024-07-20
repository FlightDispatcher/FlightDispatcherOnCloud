using FlightDispatcher.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Infostructure.Interfaces;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirportsController : Controller
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IAirportRepository _airportRepository;

        public AirportsController(ILogger<AirportsController> logger, IAirportRepository airportRepository)
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
