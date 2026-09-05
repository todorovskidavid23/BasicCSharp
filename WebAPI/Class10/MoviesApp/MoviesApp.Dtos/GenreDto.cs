using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Ендпоинт #7: "list, each with its movie count".
        // Ова ќе го пресметаме во SQL со проекција, не во меморија.
        public int MovieCount { get; set; }
    }
}
