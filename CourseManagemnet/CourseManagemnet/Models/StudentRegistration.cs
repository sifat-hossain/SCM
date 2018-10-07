using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CourseManagemnet.Models;

namespace CourseManagemnet.Models
{
    public class StudentRegistration
    {
        public int ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength =5 )]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Cell { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Father_name { get; set; }
        [Required]
        public string Mother_name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Adress { get; set; }
        [Required]
        public int Course_id { get; set; }
        [Required]
        public int Batch_id { get; set; }

        public string Result { get; set; }
    }
}