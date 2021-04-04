using DAL.Abstract;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class CommentRepository : ICommentRepository
    {
        public void Add(int userId, int filmId, string note)
        {
            using(var db = new FilmEntities())
            {
                db.Comment.Add(new Comment() { FilmId = filmId, UserId = userId, note = note});

                db.SaveChanges();
            }
        }

        
    }
}
