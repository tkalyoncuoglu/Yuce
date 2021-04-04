using DAL.Abstract;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class PointRepository : IPointRepository
    {
        public void Add(int userId, int filmId, int point)
        {
            try
            {
                using (var db = new FilmEntities())
                {
                    db.Point.Add(new Point() { FilmId = filmId, UserId = userId, point1 = point });

                    db.SaveChanges();
                }
            }
            catch(Exception)
            {
                throw new Exception("Film Id is not valid");
            }
        }

        public Point Get(int userId, int filmId)
        {
            using (var db = new FilmEntities())
            {
                var p = db.Point.Where(x => x.UserId == userId && x.FilmId == filmId).SingleOrDefault();

                return p;
            }
        }

        public void Update(int userId, int filmId, int point)
        {
            using (var db = new FilmEntities())
            {
                var p = db.Point.Where(x => x.UserId == userId && x.FilmId == filmId).SingleOrDefault();

                p.point1 = point;

                db.SaveChanges();
            }
        }
    }
}
