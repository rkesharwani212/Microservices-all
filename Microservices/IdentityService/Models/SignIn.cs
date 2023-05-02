﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityService.Models
{
    public class SignIn
    {
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
