using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Car.Models
{
    public class User
    {
        [HiddenInput]
        public int ID { get; set; }

        [Required]
        [HiddenInput]
        public UserRole UserRole { get; set; } = UserRole.User;

        [Required(ErrorMessage = "Email adress is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool IsLoggedIn { get; set; } = false;

        public ShoppingCart ShoppingCart { get; set; }
    }
}
