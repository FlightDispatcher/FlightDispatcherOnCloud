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
        public static FlightRouteModel ToModel(this FlightRouteDTO dto)
        {
            return new FlightRouteModel
            {
                Id = dto.Id,
                AirLine = new()
                {
                    Id = dto.AirLine.Id,
                    Name = dto.AirLine.Name,
                    IATA = dto.AirLine.IATA
                },
                DepartureAirport = new()
                {
                    Id = dto.DepartureAirport.Id,
                    Name = dto.DepartureAirport.Name,
                    IATA = dto.DepartureAirport.IATA
                },
                ArrivalAirport = new()
                {
                    Id = dto.ArrivalAirport.Id,
                    Name = dto.ArrivalAirport.Name,
                    IATA = dto.ArrivalAirport.IATA
                },
                FlightNumber = dto.FlightNumber,
                DepartureTime = dto.DepartureTime,
                ArrivalTime = dto.ArrivalTime
            };
        }

        public static List<FlightRouteModel> ToModelList(this List<FlightRouteDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> DTO
        public static FlightRouteDTO ToDTO(this FlightRouteModel model)
        {
            return new FlightRouteDTO
            {
                Id = model.Id,
                AirLine = new()
                {
                    Id = model.AirLine.Id,
                    Name = model.AirLine.Name,
                    IATA = model.AirLine.IATA
                },
                DepartureAirport = new()
                {
                    Id = model.DepartureAirport.Id,
                    Name = model.DepartureAirport.Name,
                    IATA = model.DepartureAirport.IATA
                },
                ArrivalAirport = new()
                {
                    Id = model.ArrivalAirport.Id,
                    Name = model.ArrivalAirport.Name,
                    IATA = model.ArrivalAirport.IATA
                },
                FlightNumber = model.FlightNumber,
                DepartureTime = model.DepartureTime,
                ArrivalTime = model.ArrivalTime
            };
        }

        public static List<FlightRouteDTO> ToDTOList(this List<FlightRouteModel> models)
        {
            return models.Select(ToDTO).ToList();
        }
        #endregion
    }
}
