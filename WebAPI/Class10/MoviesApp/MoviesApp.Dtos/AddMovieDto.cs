using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    public class AddMovieDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        public string? Description { get; set; }

        // int? + [Required] - ова е клучот, види објаснувањето подолу.
        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int? Year { get; set; }

        [Required(ErrorMessage = "DurationMinutes is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "DurationMinutes must be greater than 0.")]
        public int? DurationMinutes { get; set; }

        [Required(ErrorMessage = "GenreId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "GenreId must be a positive number.")]
        public int? GenreId { get; set; }

        // Навистина опционален - без [Required].
        public int? DirectorId { get; set; }

        public List<int> ActorIds { get; set; } = new();
    }
}
