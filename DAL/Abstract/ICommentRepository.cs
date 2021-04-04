using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICommentRepository
    {

        void Add(int userId, int filmId, string note);

        
    }
}
