using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Models.Dtos;
using ToDoApp.Services.Interfaces;


namespace ToDoApp.Services.Implementations
{
    //za da pristapime do bazata taa ni e vo dataaccess, treba da kreirame instanca, so Dependency Injection

    //dava services do baza se povikani
    //sleden cekor dodavanje na controller
    
    public class FilterService : IFilterService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public FilterService(IRepository<Category> categoryRepository, IRepository<Status> statusRepository)
        {
            _categoryRepository = categoryRepository;
            _statusRepository = statusRepository;
        }

        public List<CategoryDto> GetCategories()
        {
            var categories = _categoryRepository.GetAll().Select(x => Mapper.OptionalMapper.MapToCategoryDto(x)).ToList();
            return categories;
        }

        public List<StatusDto> GetStatuses()
        {
            return _statusRepository.GetAll().Select(x => Mapper.OptionalMapper.MapToStatusDto(x)).ToList();
        }
    }
}
