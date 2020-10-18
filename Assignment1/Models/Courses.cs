using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Courses
    {
        [Key]
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public string Semester { get; set; }
    }
}
