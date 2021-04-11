using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public static class SeedDatabase
    {


        public static void Seed(DbContext context)
        {
            //Bekleyen migrationsları direk migrate eder.

            // context.Database.Migrate();

            //Yada bekleyen migrations yoksa..

            //if (context.Database.GetAppliedMigrations().Count().Equals(0))
            //{

            //}

            if (context is CourseContext)
            {
                //Eğer Bu contexte ait tabloları beslemek istiyorsak.
                //Dependency Injection..
                CourseContext _context = context as CourseContext;

                if (_context.Courses.Count().Equals(0))
                {
                    _context.Instructor.AddRange(MyInstructors);

                    _context.Courses.AddRange(Courses);

                    _context.SaveChanges();

                }
            }

            if (context is UserContext)
            {
                UserContext _dbUsers = context as UserContext;

                if (_dbUsers.Users.Count().Equals(0))
                {
                    _dbUsers.AddRange(Users);

                    _dbUsers.SaveChanges();
                }
            }


        }
        private static Instructor[] MyInstructors =
        {

                      new Instructor(){Name="First Instructor", City="Istanbul", Contact = new Contact(){ Email="mkyl@gmail.com",Phone="555-555", Adres= new Adres() {City="Pendik", Province="Istanbul",Text="Test Text" } } },
                      new Instructor(){ Name="Second Instructor", City="Istanbul",Contact = new Contact(){ Email="mkyl@gmail.com",Phone="555-555", Adres= new Adres() {City="Pendik", Province="Istanbul",Text="Test Text" } } },
                      new Instructor(){ Name="Third Instructor", City="Istanbul",Contact = new Contact(){ Email="mkyl@gmail.com",Phone="555-555", Adres= new Adres() {City="Pendik", Province="Istanbul",Text="Test Text" } } },
                      new Instructor(){ Name="Fourth Instructor", City="Istanbul",Contact = new Contact(){ Email="mkyl@gmail.com",Phone="555-555", Adres= new Adres() { City="Pendik", Province="Istanbul",Text="Test Text" } } },


        };

        private static Course[] Courses =
        {

                    new Course() {  Name = "XA", Description = "DESCXA", Price = 10.50M, IsActive = true, Instructor = MyInstructors[0] },
                    new Course() {  Name = "BA", Description = "DESCBA", Price = 11.50M, IsActive = true, Instructor = MyInstructors[1] },
                    new Course() {  Name = "CA", Description = "DESCCA", Price = 12.50M, IsActive = true, Instructor = MyInstructors[2] },
                    new Course() {  Name = "DA", Description = "DESCDA", Price = 13.50M, IsActive = true, Instructor = MyInstructors[3] },
                    new Course() {  Name = "FA", Description = "DESCFA", Price = 14.50M, IsActive = true, Instructor = MyInstructors[0] },
                    new Course() {  Name = "EA", Description = "DESCEA", Price = 13.50M, IsActive = true, Instructor = MyInstructors[2] },
                    new Course() {  Name = "GA", Description = "DESCGA", Price = 14.50M, IsActive = true, Instructor = MyInstructors[3]}


        };



        private static readonly User[] Users =
        {
            new User() { UserName = "umur3", Password = "12345", City = "Istanbul", Email = "rndm@gmail.com" },
            new User() { UserName = "umur4", Password = "12345", City = "Istanbul", Email = "rndm@gmail.com" }
        };
    }
}
