using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IAirportService : IControllerServiceReadOnly<AirportModel>, IControllerServiceEditable<AirportModel>, IControllerServiceErasable
    {
        /// <summary>
        /// Retrieves an airport model by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airport.</param>
        /// <returns>The airport model with the specified IATA code.</returns>
        Task<AirportModel> GetByIATACode(string code);
    }
}
