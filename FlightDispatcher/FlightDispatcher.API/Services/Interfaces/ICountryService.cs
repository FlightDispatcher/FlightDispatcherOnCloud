using FlightDispatcher.Domain.Models;

namespace FlightDispatcher.API.Services.Interfaces
{
    public interface ICountryService: IControllerServiceReadOnly<CountryModel>
    {
        /// <summary>
        /// Retrieves a country by its ISO code.
        /// </summary>
        /// <param name="code">The ISO code of the country.</param>
        /// <returns>A <see cref="CountryModel"/>.</returns>
        Task<CountryModel> GetByCode(string code);
    }
}
