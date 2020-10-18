using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class CourseAssignments
    {
        [Key]
        public string Assignment_Name { get; set; }
        public ICollection<Courses> Coursess { get; set; }
        public ICollection<Assignments> Assignmentss { get; set; }
    }
}
