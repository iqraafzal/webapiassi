using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Assignments
    {
        [Key]
        public int Assignmentid{ get; set; }
        public string Assignmenttopic { get; set; }
        public string Submmittedto{ get; set; }

    }
}
