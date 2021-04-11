using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public interface ICourseRepository
    {
        IQueryable<Course> Courses { get; }
        Course GetById(int courseSlug);
        IEnumerable<Course> GetCourses();
        IEnumerable<Course> GetCoursesByIsActive(bool isActive);
        IEnumerable<Course> GetCoursesByFilter(string name = null, decimal? price = null, string isActive = null);
        void CreateCourse(Course newCourse);
        void UpdateCourse(Course updatedCoure);
        void DeleteCourse(int courseSlug);
        void UpdateAll(int Id,Course[] courses);

    }
}
