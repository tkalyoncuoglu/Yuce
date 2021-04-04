using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IPointRepository
    {
        Point Get(int userId, int FilmId);

        void Add(int userId, int FilmId, int point);

        void Update(int user, int FilmId, int point);
    }
}
