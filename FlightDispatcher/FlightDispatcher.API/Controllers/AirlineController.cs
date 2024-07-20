using FlightDispatcher.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Infostructure.Repositories;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineController : Controller
    {
        private readonly ILogger<AirlineController> _logger;
        private readonly AirlineRepository _airlineRepository;

        public AirlineController(ILogger<AirlineController> logger, AirlineRepository airlineRepository)
        {
            _logger = logger;
            _airlineRepository = airlineRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var airlines = await _airlineRepository.GetAll();

            return Ok(airlines.ToModelList());
        }
    }
}
