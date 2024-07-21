using FlightDispatcher.API.DTOs;
using FlightDispatcher.API.Exceptions;
using FlightDispatcher.API.Helpers;
using FlightDispatcher.API.Services.Interfaces;
using FlightDispatcher.Domain.Helpers;
using FlightDispatcher.Domain.Models;
using FlightDispatcher.Infostructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightDispatcher.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FlightRoutesController : Controller
    {
        private readonly ILogger<FlightRoutesController> _logger;
        private readonly IFlightRouteService _flightRouteService;

        public FlightRoutesController(ILogger<FlightRoutesController> logger, IFlightRouteService flightRouteService)
        {
            _logger = logger;
            _flightRouteService = flightRouteService;
        }

        /// <summary>
        /// Retrieves all flight routes.
        /// </summary>
        /// <returns>A list of <see cref="FlightRouteDTO"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<List<FlightRouteDTO>>> GetAll()
        {
            var flightRoutes = await _flightRouteService.GetAll();
            return Ok(flightRoutes.ToDTOList());
        }

        /// <summary>
        /// Retrieves a flight route by its ID.
        /// </summary>
        /// <param name="id">The ID of the flight route.</param>
        /// <returns>A <see cref="FlightRouteDTO"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightRouteDTO>> GetById(string id)
        {
            try
            {
                var flightRoute = await _flightRouteService.GetById(id);
                return Ok(flightRoute.ToDTO());
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Creates a new flight route.
        /// </summary>
        /// <param name="dto">The flight route dto to be created.</param>
        /// <returns>The created <see cref="FlightRouteDTO"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<FlightRouteDTO>> Create([FromBody] FlightRouteDTO dto)
        {
            var createdFlightRoute = await _flightRouteService.Create(dto.ToModel());
            return CreatedAtAction(nameof(GetById), new { id = createdFlightRoute.Id }, createdFlightRoute.ToDTO());
        }

        /// <summary>
        /// Updates an existing flight route.
        /// </summary>
        /// <param name="id">The ID of the flight route to be updated.</param>
        /// <param name="dto">The flight route dto with updated data.</param>
        /// <returns>The updated <see cref="FlightRouteDTO"/>.</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<FlightRouteDTO>> Update(string id, [FromBody] FlightRouteDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var updatedFlightRoute = await _flightRouteService.Update(dto.ToModel());
            return Ok(updatedFlightRoute);
        }

        /// <summary>
        /// Deletes a flight route by its ID.
        /// </summary>
        /// <param name="id">The ID of the flight route to be deleted.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _flightRouteService.Delete(id);
            return NoContent();
        }
    }
}
