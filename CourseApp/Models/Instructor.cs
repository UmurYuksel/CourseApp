using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Instrctr Name")]
        public string Name { get; set; }
        [Display(Name = "Instrctr City")]
        public string City { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public Contact Contact { get; set; }
    }
}
