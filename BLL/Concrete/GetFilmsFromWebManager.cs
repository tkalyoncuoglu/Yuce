using BLL.Abstract;
using BLL.DTO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace BLL.Concrete
{
    public class GetFilmsFromWebManager : IGetFilmsFromWebService
    {
        public WebFilmClass Get()
        {
            var webClient = new WebClient();

            /*https://api.themoviedb.org/discover/movie?sort_by=popularity.desc&api_key=a15ca077773f8f5c0085592227cd7dfc");*/

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var bytes = webClient.DownloadData("https://api.themoviedb.org/3/discover/movie?sort_by=popularity.desc&api_key=a15ca077773f8f5c0085592227cd7dfc");

            string utf8 = Encoding.UTF8.GetString(bytes); 

            return JsonSerializer.Deserialize<WebFilmClass>(utf8);
        }
    }
}
