using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    public class DirectorDetailsDto : DirectorDto
    {
        public List<MovieDto> Movies { get; set; } = new();
    }
}
