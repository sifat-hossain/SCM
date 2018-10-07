using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CourseManagemnet.Models;

namespace CourseManagemnet.Models
{
    public class Course
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

    }
}