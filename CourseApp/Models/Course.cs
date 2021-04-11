using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }
       
        public decimal Price { get; set; }

        public bool IsActive { get; set; }


        public int InstructorId { get; set; }

        public  Instructor Instructor { get; set; }
    }
}
