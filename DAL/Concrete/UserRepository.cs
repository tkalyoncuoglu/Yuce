using DAL.Abstract;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int userId)
        {
            using (var db = new FilmEntities())
            {
                var k = db.User.Include(x => x.Comment).
                                Include(x => x.Point).
                                Where(x => x.Id == userId).Single();

                

                return k;
            }
        }

        public async Task<User> ValidateUser(string userName, string password)
        {
            using(var db = new FilmEntities())
            {
                var k = await db.User.Where(x => x.username == userName && x.password == password).SingleOrDefaultAsync();

                return k;
            }
        }
    }
}
