
using EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstract
{
    public  interface IFilmRepository
    {
        void AddRange(List<Film> list);

        List<Film> GetFilms(int pageNumber, int pageLenth);

        Film GetById(int filmId);

        List<Film> GetAll();

        void Update(List<Film> list);
        
    }
}
