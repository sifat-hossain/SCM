using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CourseManagemnet.Models
{
    public class Batch
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Start_Time { get; set; }
        [Required]
        public string Duration { get; set; }
        [Required]
        public int CourseId { get; set; }

    }
}