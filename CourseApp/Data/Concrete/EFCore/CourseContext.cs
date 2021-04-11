using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class CourseContext : DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) 
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Instructor> Instructor { get; set; }

    }
}
