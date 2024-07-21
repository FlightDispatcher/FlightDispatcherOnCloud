using Microsoft.AspNetCore.Mvc;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Infostructure.Interfaces;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.API.Services;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.API.DTOs;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Exceptions;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AirlinesController : Controller
    {
        private readonly ILogger<AirlinesController> _logger;
        private readonly IAirlineService _airlineService;

        public AirlinesController(ILogger<AirlinesController> logger, IAirlineService airlineService)
        {
            _logger = logger;
            _airlineService = airlineService;
        }

        /// <summary>
        /// Retrieves all airlines.
        /// </summary>
        /// <returns>A list of <see cref="AirlineDTO"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<AirlineDTO>>> GetAll()
        {
            var airlines = await _airlineService.GetAll();
            return Ok(airlines.ToDTOList());
        }

        /// <summary>
        /// Retrieves an airline by its ID.
        /// </summary>
        /// <param name="id">The ID of the airline.</param>
        /// <returns>An <see cref="AirlineDTO"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineDTO>> GetById(string id)
        {
            try
            {
                var airline = await _airlineService.GetById(id);
                return Ok(airline.ToDTO());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new airline.
        /// </summary>
        /// <param name="model">The airline dto to be created.</param>
        /// <returns>The created <see cref="AirlineDTO"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<AirlineDTO>> Create([FromBody] AirlineDTO dto)
        {
            var createdAirline = await _airlineService.Create(dto.ToModel());
            return CreatedAtAction(nameof(GetById), new { id = createdAirline.Id }, createdAirline.ToDTO());
        }

        /// <summary>
        /// Updates an existing airline.
        /// </summary>
        /// <param name="id">The ID of the airline to be updated.</param>
        /// <param name="dto">The airline dto with updated data.</param>
        /// <returns>The updated <see cref="AirlineDTO"/>.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<AirlineDTO>> Update(string id, [FromBody] AirlineDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var updatedAirline = await _airlineService.Update(dto.ToModel());
            return Ok(updatedAirline);
        }

        /// <summary>
        /// Deletes an airline by its ID.
        /// </summary>
        /// <param name="id">The ID of the airline to be deleted.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _airlineService.Delete(id);
            return NoContent();
        }
    }
}
