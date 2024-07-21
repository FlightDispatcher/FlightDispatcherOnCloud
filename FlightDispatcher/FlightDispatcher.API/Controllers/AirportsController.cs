using FlightDispatcher.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Infrastructure.Interfaces;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.API.DTOs;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Exceptions;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirportsController : Controller
    {
        private readonly ILogger<AirportsController> _logger;
        private readonly IAirportService _airportService;

        public AirportsController(ILogger<AirportsController> logger, IAirportService airportService)
        {
            _logger = logger;
            _airportService = airportService;
        }

        /// <summary>
        /// Retrieves all airports.
        /// </summary>
        /// <returns>A list of <see cref="AirportDTO"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<AirportDTO>>> GetAll()
        {
            var airports = await _airportService.GetAll();
            return Ok(airports.ToDTOList());
        }

        /// <summary>
        /// Retrieves an airport by its ID.
        /// </summary>
        /// <param name="id">The ID of the airport.</param>
        /// <returns>An <see cref="AirportDTO"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDTO>> GetById(string id)
        {
            try
            {
                var airport = await _airportService.GetById(id);
                return Ok(airport.ToDTO());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new airport.
        /// </summary>
        /// <param name="dto">The airport dto to be created.</param>
        /// <returns>The created <see cref="AirportDTO"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<AirportDTO>> Create([FromBody] AirportDTO dto)
        {
            try
            {
                var createdAirport = await _airportService.Create(dto.ToModel());
                return CreatedAtAction(nameof(GetById), new { id = createdAirport.Id }, createdAirport.ToDTO());
            }
            catch (CountryCodeNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AirportCodeAlreadyInUseException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing airport.
        /// </summary>
        /// <param name="id">The ID of the airport to be updated.</param>
        /// <param name="dto">The airport dto with updated data.</param>
        /// <returns>The updated <see cref="AirportDTO"/>.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<AirportDTO>> Update(string id, [FromBody] AirportDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");
            
            try
            {
                var updatedAirport = await _airportService.Update(dto.ToModel());
                return Ok(updatedAirport);
            }
            catch (CountryCodeNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AirportCodeAlreadyInUseException ex)
            {
                return Conflict(ex.Message);
            }
        }

        /// <summary>
        /// Deletes an airport by its ID.
        /// </summary>
        /// <param name="id">The ID of the airport to be deleted.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _airportService.Delete(id);
            return NoContent();
        }

        /// <summary>
        /// Gets an airport by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airport.</param>
        /// <returns>An <see cref="AirportModel"/>.</returns>
        [HttpGet("iata/{code}")]
        public async Task<ActionResult<AirportModel>> GetByIATACode(string code)
        {
            try
            {
                var airport = await _airportService.GetByIATACode(code);
                return Ok(airport);
            }
            catch (AirportCodeNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
