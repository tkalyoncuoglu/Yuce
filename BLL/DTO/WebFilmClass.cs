using EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   

    public class WebFilmClass
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }


}
