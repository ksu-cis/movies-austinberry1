using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Movies
{
    /// <summary>
    /// A class representing a database of movies
    /// </summary>
    public static class MovieDatabase
    {
        private static List<Movie> movies;
        
        public  static List<Movie> All {
            get
            {
                if(movies == null)
                {
                    using (StreamReader file = System.IO.File.OpenText("movies.json"))
                    {
                        string json = file.ReadToEnd();
                        movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    }
                }
                

                return movies; } }

        public static List<Movie> SearchAndFilter(List<Movie> movies,string term)
        {
            
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {

              if(movie.Title.Contains(term, StringComparison.OrdinalIgnoreCase))
                    {
                        results.Add(movie);
                    }

                
            }
            return results;

        }
        public static List<Movie> FilterByMPAA(List<Movie> movies, List<string> mpaa)
        {
            List<Movie> results = new List<Movie>();
            foreach(Movie movie in movies)
            {
                if (mpaa.Contains(movie.MPAA_Rating))
                {
                    results.Add(movie);
                }
            }
            return results;
        }
        public static List<Movie> FilterByMinMPAA(List<Movie> movies, float minIMDB)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && minIMDB <= movie.IMDB_Rating )
                {
                    results.Add(movie);
                }
            }
            return results;
        }
        public static  List<Movie> FilterByMaxMPAA(List<Movie> movies, float minIMDB)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in movies)
            {
                if (movie.IMDB_Rating != null && minIMDB >= movie.IMDB_Rating)
                {
                    results.Add(movie);
                }
            }
            return results;
        }

    }
}
