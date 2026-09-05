using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    public class UpdateMovieDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Range(1888, 2100)]
        public int? Year { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? DurationMinutes { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int? GenreId { get; set; }

        public int? DirectorId { get; set; }

        public List<int> ActorIds { get; set; } = new();
    }
}
