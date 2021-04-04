
using BLL.Abstract;
using BLL.DTO;
using BLL.Validation;
using DAL.Abstract;
using DAL.Concrete;
using EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Concrete
{
    public class FilmManager : IFilmService
    {
        private IFilmRepository _filmRepository;

        private ICommentRepository _commentRepository;

        private IPointRepository _pointRepository;

        private IUserRepository _userRepository;

        public FilmManager(IFilmRepository filmRepository, 
                           ICommentRepository commentRepository,
                           IPointRepository pointRepository,
                           IUserRepository userRepository)
        {
            _filmRepository = filmRepository;

            _commentRepository = commentRepository;

            _pointRepository = pointRepository;

            _userRepository = userRepository;
        }

        public void AddNote(int userId, int filmId, string note)
        {
            _commentRepository.Add(userId, filmId, note);
        }

        public void AddPoint(int userId, int filmId, int point)
        {
            
            var p = new PointValidator();

            var result = p.Validate(point);

            if(result.Errors.Count != 0)
            {
                throw new Exception(string.Join("\n", result.Errors.Select(x => x.ErrorMessage)));
            }

            var t = _pointRepository.Get(userId, filmId);

            if(t == null)
            {
                _pointRepository.Add(userId, filmId, point);
            }
            else
            {
                _pointRepository.Update(userId, filmId, point);
            }
        }

        public FilmWithComment GetById(int userId, int filmId)
        {
            var p = _filmRepository.GetById(filmId);

            var k = _userRepository.GetById(userId);

            int? s = null;

            var z = k.Point.Where(x => x.FilmId == filmId).FirstOrDefault();

            if (z != null)
                s = z.point1;

            var t = new FilmWithComment()
            {
                Id = p.Id,
                adult = p.adult,
                backdrop_path = p.backdrop_path,
                genre_ids = p.genre_ids,
                original_language = p.original_language,
                original_title = p.original_title,
                overview = p.overview,
                popularity = p.popularity,
                poster_path = p.poster_path,
                release_date = p.release_date,
                title = p.title,
                video = p.video,
                vote_average = p.vote_average,
                vote_count = p.vote_count,
                note = k.Comment.Where(x => x.FilmId == filmId).Select(x => x.note).ToList(),
                point = s 
            };

            return t;
        }

        public List<FilmAsIs> GetFilms(int pageNumber, int pageLenth)
        {
            var x = _filmRepository.GetFilms(pageNumber, pageLenth);

            var t = x.Select(p => new FilmAsIs()
            {
                Id = p.Id,
                adult = p.adult,
                backdrop_path = p.backdrop_path,
                genre_ids = p.genre_ids,
                original_language = p.original_language,
                original_title = p.original_title,
                overview = p.overview,
                popularity = p.popularity,
                poster_path = p.poster_path,
                release_date = p.release_date,
                title = p.title,
                video = p.video,
                vote_average = p.vote_average,
                vote_count = p.vote_count,

            }


            ).ToList();

            return t;
        }

        public void SaveFilmsFromWeb(WebFilmClass webFilmClass)
        {

            var p = webFilmClass.results.Select(x => new Film
            {
                adult = x.adult,
                backdrop_path = x.backdrop_path,
                genre_ids = string.Join(",", x.genre_ids.ToArray()),
                Id = x.id,
                original_language = x.original_language,
                original_title = x.original_title,
                overview = x.overview,
                popularity = (decimal)x.popularity,
                poster_path = x.poster_path,
                release_date = x.release_date,
                title = x.title,
                video = x.video,
                vote_average = (decimal)x.vote_average,
                vote_count = x.vote_count
            }

                ).ToList();

            var all = _filmRepository.GetAll();

            var distinct = p.Where(l2 => all.All(l1 => l1.Id != l2.Id)).ToList();

            _filmRepository.AddRange(distinct);

            var same = p.Where(l2 => all.Any(l1 => l1.Id == l2.Id)).ToList();

            _filmRepository.Update(same);
        }

    }
}
