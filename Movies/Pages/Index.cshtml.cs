using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        //public MovieDatabase MovieDatabase = new MovieDatabase();
        public List<Movie> Movies;
        [BindProperty]
        public String Search { get; set; } = "";
        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();
        [BindProperty]
        public double? IMBD { get; set; } 
        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }
        public void OnPost(string search, List<string> mpaa, double? IMBD)
        {
            Movies = MovieDatabase.All;

            if(search != null)
            {
                Movies = MovieDatabase.Search(Movies,search);
            }
            if(mpaa.Count > 0)
            {
                Movies = MovieDatabase.Filter(Movies,mpaa);
            }
            if(IMBD != null)
            {
                Movies = MovieDatabase.FilterByIMBD(Movies,IMBD);
            }
        }
    }
}
