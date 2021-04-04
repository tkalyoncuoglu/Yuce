using BLL.Abstract;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.AspNet.Identity;




namespace Yuce.Controllers
{
    [Authorize]
    
    public class FilmsController : ApiController
    {
        private IGetFilmsFromWebService _getFilmsFromWebService;

        private IFilmService _filmService;

       
        public FilmsController(IGetFilmsFromWebService getFilmsFromWebService,
                               IFilmService filmService)
        {
            _getFilmsFromWebService = getFilmsFromWebService;

            _filmService = filmService;
        }


       
        [HttpGet]
        [Route("api/GetFilms")]
        public List<FilmAsIs> GetFilms(int pageNumber, int pageLength)
        {
            var p = User.Identity.GetUserId();

            return _filmService.GetFilms(pageNumber, pageLength);
        }

        [HttpPost]
        [Route("api/PutNote")]
        public string PutNote(int id, string note)
        {
            try
            {
                _filmService.AddNote(Convert.ToInt32(User.Identity.GetUserId()), id, note);

                return "Note is added successfully";

            }
            catch (Exception e)
            {
                return e.Message;
            }
            
            
        }

        [HttpPost]
        [Route("api/PutPoint")]
        public string PutPoint(int id, int point)
        {
            try
            {
                _filmService.AddPoint(Convert.ToInt32(User.Identity.GetUserId()), id, point);

                return "Point is added successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        [HttpGet]
        [Route("api/GetById")]
        public object GetById(int id)
        {
            try
            { 
                return _filmService.GetById(Convert.ToInt32(User.Identity.GetUserId()), id);
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }
}