  using CourseApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repositories
{
    public interface IInstructorRepostiory : IGenericRepository<Instructor>
    {
        IEnumerable<Instructor> GetTopInstructors();
    }
}
