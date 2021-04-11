using CourseApp.Data.Abstract;
using CourseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private CourseContext _db;

        public  GenericRepository(CourseContext db) => _db = db;  
    
        public virtual void Delete(int id) => _db.Remove<TEntity>(Get(id));
       
        public virtual TEntity Get(int id) => _db.Set<TEntity>().Find(id);

        public virtual IEnumerable<TEntity> GetAll() => _db.Set<TEntity>();
      
        public virtual void Insert(TEntity newCourse)
        {
            // _db.Set<TEntity>().Add(newCourse);
            _db.Add<TEntity>(newCourse);
            _db.SaveChanges();
        }

        public virtual void Update(TEntity updatedCoure)
        {
            _db.Update<TEntity>(updatedCoure);
            _db.SaveChanges();
        }
    }
}
