using DAL.Abstract;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;

namespace DAL.Concrete
{
    public class FilmRepository : IFilmRepository
    {
        

        public void AddRange(List<Film> list)
        {
            using(var db = new FilmEntities())
            { 

                db.Film.AddRange(list);

                db.SaveChanges();
            }
        }

        public List<Film> GetAll()
        {
            using(var db = new FilmEntities())
            {
                return db.Film.ToList();
            }
        }

        public Film GetById(int filmId)
        {
            using(var db = new FilmEntities())
            {
                
                var p = db.Film.Where(x => x.Id == filmId).SingleOrDefault();

                if(p == null)
                {
                    throw new Exception("Film Id is not valid");
                }

                return p;
            }
        }

        public List<Film> GetFilms(int pageNumber, int pageLenth)
        {
            using(var db = new FilmEntities())
            {
                var p = db.Film.OrderByDescending(x => x.popularity).Skip(pageNumber * pageLenth).Take(pageLenth).ToList();

                return p;
            }
        }

        public void Update(List<Film> list)
        {
            using(var db = new FilmEntities())
            {
                var t = list.Select(x => x.Id).ToList();

                var p = db.Film.Where(x => t.Contains(x.Id)).ToList();

                foreach(var f in p)
                {
                    var h = list.Where(x => x.Id == f.Id).Single();

                    f.popularity = h.popularity;

                    f.vote_average = h.vote_average;

                    f.vote_count = h.vote_count;
                }

                db.SaveChanges();
            }
        }
    }
}
