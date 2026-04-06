using System;
using System.Collections.Generic;
using System.Text;

namespace Class09.CinemaSystem.Models
{
    public class Cinema
    {
        public string Name { get; set; }
        public int Halls { get; set; }
        public List<Movie> ListOfMovies { get; set; }


        public Cinema(string name, int halls, List<Movie> movies)
        {
            Name = name;
            Halls = halls;
            ListOfMovies = movies;
        }

        public void MoviePlaying(Movie movie)
        {
            try
            {
                if (movie == null)
                {
                    throw new Exception("Movie cannot be null!");
                }

                Console.WriteLine($"Watching {movie.Title}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while trying to play movie: {ex.Message}");
            }
        }

    }
}
