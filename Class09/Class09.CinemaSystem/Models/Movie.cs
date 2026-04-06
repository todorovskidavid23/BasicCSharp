using Class09.CinemaSystem.Enums;
using System;
using System.Collections.Generic;
using System.Text;
//ctrl K+D za format
namespace Class09.CinemaSystem.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public int Rating { get; set; }
        public int TicketPrice { get; set; }

        public Movie(string title, Genre genre, int rating)
        {
            Title = title;
            Genre = genre;
            //Rating = rating;
            Rating = Rate(rating);
            TicketPrice = 5 * Rating;
        }

        public int Rate(int rating)
        {
            try
            {
                if (rating < 1 || rating > 5)
                {
                    throw new Exception("Rating must be between 1 and 5!");
                }
                else
                {
                    return rating;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }

    }

}
