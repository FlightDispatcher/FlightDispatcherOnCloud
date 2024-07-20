using FlightDispatcher.Infostructure.Repositories;
using FlightDispatcher.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FlightRoutesController : Controller
    {
        private readonly ILogger<FlightRoutesController> _logger;
        private readonly FlightRouteRepository _flightRouteRepository;

        public FlightRoutesController(ILogger<FlightRoutesController> logger, FlightRouteRepository flightRouteRepository)
        {
            _logger = logger;
            _flightRouteRepository = flightRouteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var flightRoutes = await _flightRouteRepository.GetAll();

            return Ok(flightRoutes.ToModelList());
        }
    }
}
