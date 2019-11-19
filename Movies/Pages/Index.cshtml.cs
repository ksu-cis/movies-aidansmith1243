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
        public MovieDatabase MovieDatabase = new MovieDatabase();
        public List<Movie> Movies;
        [BindProperty]
        public String Search { get; set; } = "";
        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();
        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }
        public void OnPost(string search, List<string> mpaa)
        {
            if(search != null && mpaa.Count > 0)
            {
                Movies = MovieDatabase.Filter(MovieDatabase.Search(search),mpaa);
            }
            else if(search != null)
            {
                Movies = MovieDatabase.Search(search);
            }
            else if(mpaa.Count > 0)
            {
                Movies = MovieDatabase.Filter(MovieDatabase.All,mpaa);
            }
            else
            {
                Movies = MovieDatabase.All;
            }
        }
    }
}
