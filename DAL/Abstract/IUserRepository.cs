using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string userName, string password);

        User GetById(int userId);
    }
}
