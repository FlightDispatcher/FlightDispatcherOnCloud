using FlightDispatcher.Infostructure.Repositories;
using FlightDispatcher.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly CountryRepository _countryRepository;

        public CountriesController(ILogger<CountriesController> logger, CountryRepository countryRepository)
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
