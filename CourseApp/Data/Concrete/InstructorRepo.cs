using CourseApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models.Repositories
{
    public class InstructorRepo : GenericRepository<Instructor>,IInstructorRepostiory
    {

        private CourseContext _db;
        public InstructorRepo(CourseContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<Instructor> GetTopInstructors()
        {
            throw new NotImplementedException();
        }


        public override IEnumerable<Instructor> GetAll()
        {

            //1.Yöntem Her bir instructor icin 1 sorgu daha olustur ve instructor sayısı az oldugunda kullanılabilir ama eğer cok veri varsa bu bizim
            //icin sorun yaratır. Amac veritabanına en az sorgu yollayarak işimizi halletmek.

            //IEnumerable<Instructor> instructors = _db.Instructor;

            //CMD den sadece su sorgulama sırasında ilk _db.Instructor diyince gidip sorguluyor mu yoksa alt satırı bekleyip IQUERYABLE MI yapıyor kontrol et.
            //foreach (var ins in instructors)
            //{
            //    _db.Entry(ins).Collection(i => i.Courses).Query().Where(i => i.IsActive).Load();

            //}
            //return instructors;


            //Load kullanınınca sorguyu execute ederek donen veriyi db context'in cache'inde tutar. Daha sonra bu veriyi alıp kullanabiliriz.
            _db.Courses.Where(i => i.Instructor != null && i.IsActive.Equals(true)).Load();

            return _db.Instructor;
        }
    }
}
