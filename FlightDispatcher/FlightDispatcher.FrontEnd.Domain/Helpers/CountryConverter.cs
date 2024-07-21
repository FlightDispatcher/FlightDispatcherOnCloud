using FlightDispatcher.FrontEnd.Domain.DTOs;
using FlightDispatcher.FrontEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightDispatcher.FrontEnd.Domain.Helpers
{
    /* 
        This Converter Class transform CountryModel object in CountryDTO object and viceversa
     */

    public static class CountryConverter
    {
        #region DTO -> Model
        public static CountryModel ToModel(this CountryDTO dto)
        {
            return new CountryModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Code = dto.Code
            };
        }

        public static List<CountryModel> ToModelList(this List<CountryDTO> dtos)
        {
            return dtos.Select(ToModel).ToList();
        }
        #endregion

        #region Model -> DTO
        public static CountryDTO ToDTO(this CountryModel model)
        {
            return new CountryDTO
            {
                Id = model.Id,
                Name = model.Name,
                Code = model.Code
            };
        }

        public static List<CountryDTO> ToDTOList(this List<CountryModel> models)
        {
            return models.Select(ToDTO).ToList();
        }
        #endregion
    }
}
