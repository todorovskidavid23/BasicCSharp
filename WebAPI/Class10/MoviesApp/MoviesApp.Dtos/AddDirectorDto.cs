using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Dtos
{
    public class AddDirectorDto
    {
        [Required][MaxLength(50)] public string FirstName { get; set; } = string.Empty;
        [Required][MaxLength(50)] public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
    }
}
