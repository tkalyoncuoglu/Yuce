using BLL.DTO;
using EF;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IFilmService
    {
        void SaveFilmsFromWeb(WebFilmClass webFilmClass);

        List<FilmAsIs> GetFilms(int pageNumber, int pageLenth);

        void AddNote(int userId, int filmId, string note);

        void AddPoint(int userId, int filmId, int point);

        FilmWithComment GetById(int userId, int filmId);
        
    }
}
