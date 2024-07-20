using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Infostructure.Interfaces;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirlinesController : Controller
    {
        private readonly ILogger<AirlinesController> _logger;
        private readonly IAirlineRepository _airlineRepository;

        public AirlinesController(ILogger<AirlinesController> logger, IAirlineRepository airlineRepository)
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
