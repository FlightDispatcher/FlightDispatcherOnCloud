using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface IAirlineService: IControllerServiceReadOnly<AirlineModel>, IControllerServiceEditable<AirlineModel>, IControllerServiceErasable
    {
        /// <summary>
        /// Retrieves an airline model by its IATA code.
        /// </summary>
        /// <param name="code">The IATA code of the airline.</param>
        /// <returns>The airline model with the specified IATA code.</returns>
        Task<AirlineModel> GetByIATACode(string code);
    }
}
