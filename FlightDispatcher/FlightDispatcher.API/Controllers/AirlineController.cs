using FlightDispatcher.API.DTOs;
using FlightDispatcher.Infostructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Domain.Helpers;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineController : Controller
    {
        private readonly ILogger<AirlineController> _logger;
        private readonly IAirlineRepository _airlineRepository;

        public AirlineController(ILogger<AirlineController> logger, IAirlineRepository airlineRepository)
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
