using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;

        public static List<Movie> All 
        { 
            get {
                if (movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                return movies; 
            } 
        }
        public static List<Movie> Search(List<Movie> mIn,string search)
        {            
            List<Movie> movies = new List<Movie>();
            foreach(Movie m in mIn)
            {
                if(m.Title.Contains(search,StringComparison.OrdinalIgnoreCase) || (m.Director != null && m.Director.Contains(search,StringComparison.OrdinalIgnoreCase)))
                {
                    movies.Add(m);
                }
                
            }
            return movies;
        }
        public static List<Movie> Filter(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> returnMovies = new List<Movie>();
            foreach (Movie m in movies)
            {
                if (m.MPAA_Rating != null && mpaa.Contains(m.MPAA_Rating))
                {
                    returnMovies.Add(m);
                }
            }
            return returnMovies;
        }
        public static List<Movie> FilterByIMBD(List<Movie> movies, double? IMBD)
        {
            List<Movie> returnMovies = new List<Movie>();
            foreach (Movie m in movies)
            {
                if (m.IMDB_Rating != null && m.IMDB_Rating >= IMBD)
                    returnMovies.Add(m);
            }
            return returnMovies;
        }
    }
}
