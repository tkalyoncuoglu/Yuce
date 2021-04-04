using BLL.Concrete;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Abstract
{
    public interface IGetFilmsFromWebService
    {
        WebFilmClass Get();
    }
}
