using FlightDispatcher.API.DTOs;
using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CountriesController : Controller
    {
        private readonly ILogger<CountriesController> _logger;
        private readonly ICountryService _countryService;

        public CountriesController(ILogger<CountriesController> logger, ICountryService countryService)
        {
            _logger = logger;
            _countryService = countryService;
        }

        /// <summary>
        /// Retrieves all countries.
        /// </summary>
        /// <returns>A list of <see cref="CountryDTO"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<CountryDTO>>> GetAll()
        {
            var countries = await _countryService.GetAll();
            return Ok(countries.ToDTOList());
        }

        /// <summary>
        /// Retrieves a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country.</param>
        /// <returns>A <see cref="CountryDTO"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetById(string id)
        {
            try
            {
                var country = await _countryService.GetById(id);
                return Ok(country.ToDTO());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
