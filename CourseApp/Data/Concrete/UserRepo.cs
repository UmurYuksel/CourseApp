using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApp.Models
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _db;

        public UserRepo(UserContext db)
        {
            _db = db;

        }
        public IEnumerable<User> GetUsers()
        {
            return _db.Users;
        }
    }
}
