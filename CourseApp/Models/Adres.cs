using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class Adres
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }
        public string Province { get; set; }
        public string Text { get; set; }
    }
}
