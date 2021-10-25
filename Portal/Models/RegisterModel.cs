﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]

        public string Email { get; set; }
        [Required]
        [UIHint("password")]

        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
