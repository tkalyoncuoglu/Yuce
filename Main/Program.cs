using BLL.Concrete;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = new UserRepository();

            //var p = k.ValidateUser("tarkan", "123");

            var t = new GetFilmsFromWebManager();

            var s = t.Get();

        }
    }
}
