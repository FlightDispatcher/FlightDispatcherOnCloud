﻿using System.ComponentModel.DataAnnotations;

namespace FlightDispatcher.API.DTOs
{
    public class CountryDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
    }
}
