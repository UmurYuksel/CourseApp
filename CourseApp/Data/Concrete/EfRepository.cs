using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class EfRepository : ICourseRepository
    {
        private CourseContext _db;

        public EfRepository(CourseContext db)
        {
            _db = db;
        }

        public IEnumerable<Course> Courses => _db.Courses;

        IQueryable<Course> ICourseRepository.Courses => throw new NotImplementedException();

        public void CreateCourse(Course newCourse)
        {
           
            _db.Courses.Add(newCourse);
            _db.SaveChanges();
        }

        public void DeleteCourse(int courseSlug)
        {
            //First Approach to remove a row from table
           // _db.Courses.Remove(_db.Courses.Find(courseSlug));

            //second approach
            //iki sorgu yerine tek query ile execute.
            //Speed improvement.
            _db.Courses.Remove(new Course { Id = courseSlug });


            _db.SaveChanges();


        }

        public Course GetById(int courseSlug) => _db.Courses.Include(x=>x.Instructor).FirstOrDefault(x=>x.Id.Equals(courseSlug));
      

        public IEnumerable<Course> GetCourses() =>  _db.Courses.Include(x=>x.Instructor).ThenInclude(x=>x.Contact).ThenInclude(x=>x.Adres);

        public IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null)
        {
            //IMPORTANT
            //ASAGIDAKI KOSULLARDAN HANGISI OLUSURSA WHERE KOSULUNA EKLENIR VE ONA GORE FILTRELEME YAPAR !
            //SPEED IMPROVEMENT !!!!
            IQueryable<Course> query = _db.Courses;
            if (name!=null)
            {
                query = query.Where(o => o.Name.ToLower().Contains(name.ToLower()));
            }

            if (price!=null)
            {
                query = query.Where(i => i.Price >= price);
            }

            if (isActive=="on")
            {
                query = query.Where(i => i.IsActive.Equals(true));
            }

             return query.Include(x=>x.Instructor).ToList();
          
        }

        public IEnumerable<Course> GetCoursesByIsActive(bool isActive) => _db.Courses.Include(x=>x.Instructor).Where(o => o.IsActive.Equals(isActive)).ToList();

        public void UpdateAll(int Id, Course[] courses)
        {
            _db.Courses.UpdateRange(courses.Where(x=>x.InstructorId!=Id));
            _db.SaveChanges();
        }

        public void UpdateCourse(Course updatedCourse) 
        {
            //Another approach.
            //Sets every column of row again.
            //_db.Courses.Update(updatedCourse);

            //----------------------------------------------------------------------------------------
            //Change Tracking Style=>

            //Only sets the changed column.
            //But also it selects the row one more time, bad for database...
            //var entity = _db.Courses.Find(updatedCoure.CourseSlug);

            //if (entity!=null)
            //{
            //    entity.Name = updatedCoure.Name;
            //    entity.IsActive = updatedCoure.IsActive;
            //    entity.Price = updatedCoure.Price;
            //    entity.Description = updatedCoure.Description;

            //EntityEntry entry = _db.Entry(entity);

            //Console.WriteLine($"Entity State : { entry.State }");

            //foreach (var property in new string[] {"Name", "Description", "Price", "isActive" })
            //{
            //    Console.WriteLine($"{property} - old : {entry.OriginalValues[property]}");
            //}
            //    _db.SaveChanges();
            //}
            //-----------------------------------------------------------------------------------------------

            //Sets every column of row again.

            //_db.Attach(updatedCourse).State = EntityState.Modified;
            //_db.SaveChanges();


            //Last approach, I think this is the safest one.

            var courseForUpdate = _db.Courses.Include(x => x.Instructor).ThenInclude(x=>x.Contact).SingleOrDefault(x => x.Id == updatedCourse.Id);

            courseForUpdate.Id = updatedCourse.Id;
            courseForUpdate.InstructorId = updatedCourse.InstructorId;
            courseForUpdate.Instructor.City = updatedCourse.Instructor.City;
            courseForUpdate.Instructor.Name = updatedCourse.Instructor.Name;
            courseForUpdate.IsActive = updatedCourse.IsActive;
            courseForUpdate.Name = updatedCourse.Name;
            courseForUpdate.Price = updatedCourse.Price;
            courseForUpdate.Description = updatedCourse.Description;

            _db.Attach(courseForUpdate).State = EntityState.Modified;
            _db.SaveChanges();



        }
    }
}
