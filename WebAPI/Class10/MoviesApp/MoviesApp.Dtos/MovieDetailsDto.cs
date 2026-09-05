using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    // GET /api/movies/{id} - истото плус актерите.
    public class MovieDetailsDto : MovieDto
    {
        public List<ActorDto> Actors { get; set; } = new();
    }
}
