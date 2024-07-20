using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Infostructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountryRepository _countryRepository;

        public CountriesController(ILogger<CountriesController> logger, ICountryRepository countryRepository)
        {
            _logger = logger;
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var countrys = await _countryRepository.GetAll();

            return Ok(countrys.ToModelList());
        }
    }
}
