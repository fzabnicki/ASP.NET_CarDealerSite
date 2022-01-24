using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Car.Models
{
    public class Cars
    {
        [HiddenInput]
        public int ID { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        [Required(ErrorMessage = "Please input model of the car.")]
        public string Model { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        [Required(ErrorMessage = "Please input brand of the car.")]
        public string Brand { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please input year of production.")]
        public DateTime ProductionDate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9'' ']+$", ErrorMessage = "Special character should not be entered")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please input price of the car.")]
        public decimal Price { get; set; }
    }
}
