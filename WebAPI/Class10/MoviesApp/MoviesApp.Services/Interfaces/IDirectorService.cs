using MoviesApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services.Interfaces
{
    public interface IDirectorService
    {
        Task<List<DirectorDto>> GetAllDirectorsAsync();
        Task<DirectorDetailsDto> GetDirectorByIdAsync(int id);
        Task<DirectorDto> AddDirectorAsync(AddDirectorDto addDirectorDto);
    }
}
