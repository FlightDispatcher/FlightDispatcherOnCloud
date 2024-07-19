using FlightDispatcher.API.DTOs;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;

namespace FlightDispatcher.API.Helpers
{
    /* 
        This Converter Class transform FlightRouteModel object in FlightRouteDTO object and viceversa
     */

    public static class FlightRouteConverter
    {
        #region DTO -> Model
        public static FlightRouteModel ToModel(FlightRouteDTO dto)
        {
            return new FlightRouteModel
            {
                Id = dto.Id,
                AirLine =
                {
                    Id = dto.AirLine.Id,
                    Name = dto.AirLine.Name,
                    IATA = dto.AirLine.IATA
                },
                DepartureAirport =
                {
                    Id = dto.DepartureAirport.Id,
                    Name = dto.DepartureAirport.Name,
                    IATA = dto.DepartureAirport.IATA
                },
                ArrivalAirport =
                {
                    Id = dto.ArrivalAirport.Id,
                    Name = dto.ArrivalAirport.Name,
                    IATA = dto.ArrivalAirport.IATA
                },
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime
            };
        }

        public static List<FlightRouteModel> ToModelList(List<FlightRouteDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> DTO
        public static FlightRouteDTO ToDTO(FlightRouteModel model)
        {
            return new FlightRouteDTO
            {
                Id = model.Id,
                AirLine =
                {
                    Id = model.AirLine.Id,
                    Name = model.AirLine.Name,
                    IATA = model.AirLine.IATA
                },
                DepartureAirport =
                {
                    Id = model.DepartureAirport.Id,
                    Name = model.DepartureAirport.Name,
                    IATA = model.DepartureAirport.IATA
                },
                ArrivalAirport =
                {
                    Id = model.ArrivalAirport.Id,
                    Name = model.ArrivalAirport.Name,
                    IATA = model.ArrivalAirport.IATA
                },
                DepartureTime = model.DepartureTime,
                ArrivalTime = model.ArrivalTime
            };
        }

        public static List<FlightRouteDTO> ToDTOList(List<FlightRouteModel> models)
        {
            return models.Select(ToDTO).ToList();
        }
        #endregion
    }
}
