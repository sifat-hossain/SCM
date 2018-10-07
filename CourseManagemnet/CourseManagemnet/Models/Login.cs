﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CourseManagemnet.Models;

namespace CourseManagemnet.Models
{
    public class Login
    {
        [Required]
        public string Name { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}