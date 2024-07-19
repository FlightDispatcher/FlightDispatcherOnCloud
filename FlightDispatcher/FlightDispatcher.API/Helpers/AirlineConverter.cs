﻿using FlightDispatcher.API.DTOs;
using FlightDispatcher.Domain.Models;
using MongoDB.Bson;

namespace FlightDispatcher.API.Helpers
{
    /* 
        This Converter Class transform AirlineModel object in AirLineDTO object and viceversa
     */

    public static class AirlineConverter
    {
        #region DTO -> Model
        public static AirlineModel ToModel(this AirlineDTO dto)
        {
            return new AirlineModel
            {
                Id = dto.Id,
                Name = dto.Name,
                IATA = dto.IATA,
                ICAO = dto.ICAO
            };
        }

        public static List<AirlineModel> ToModelList(this List<AirlineDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> DTO
        public static AirlineDTO ToDTO(this AirlineModel model)
        {
            return new AirlineDTO
            {
                Id = model.Id,
                Name = model.Name,
                IATA = model.IATA,
                ICAO = model.ICAO
            };
        }

        public static List<AirlineDTO> ToDTOList(this List<AirlineModel> models)
        {
            return models.Select(ToDTO).ToList();
        }
        #endregion
    }
}
