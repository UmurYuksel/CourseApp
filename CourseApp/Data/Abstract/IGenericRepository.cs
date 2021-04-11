using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Abstract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Insert(TEntity newCourse);
        void Update(TEntity updatedCoure);
        void Delete(int id);

    }
}
