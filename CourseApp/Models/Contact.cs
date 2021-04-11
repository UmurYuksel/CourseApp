using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public Adres Adres { get; set; }
    }
}
