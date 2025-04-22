﻿using System.ComponentModel.DataAnnotations;

namespace App.Web.Mvc.Models
{
    public class LoginViewModel
    {
        [Required,EmailAddress]
        public string Email { get; set; } = null!;
        [Required, DataType(DataType.Password), MinLength(4)]
        public string Password { get; set; } = null!;
    }
}
