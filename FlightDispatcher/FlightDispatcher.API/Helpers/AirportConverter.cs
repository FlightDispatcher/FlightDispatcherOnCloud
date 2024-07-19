using FlightDispatcher.API.DTOs;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;

namespace FlightDispatcher.API.Helpers
{
    /* 
        This Converter Class transform AirportModel object in AirportDTO object and viceversa
     */

    public static class AirportConverter
    {
        #region DTO -> Model
        public static AirportModel ToModel(this AirportDTO dto)
        {
            return new AirportModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IATA = dto.IATA,
                ICAO = dto.ICAO,
                Country = dto.Country
            };
        }

        public static List<AirportModel> ToModelList(this List<AirportDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> DTO
        public static AirportDTO ToDTO(this AirportModel model)
        {
            return new AirportDTO
            {
                Id = model.Id,
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO,
                Country = model.Country
            };
        }

        public static List<AirportDTO> ToDTOList(this List<AirportModel> models)
        {
            return models.Select(ToDTO).ToList();
        }
        #endregion
    }
}
