using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Interfaces;
using ToDoApp.Mapper;

namespace ToDoApp.Services.Implementations
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Status> _statusRepository;

        public ToDoService(IToDoRepository toDoRepository, IRepository<Category> categoryRepository, IRepository<Status> statusRepository)
        {
            _toDoRepository = toDoRepository;
            _categoryRepository = categoryRepository;
            _statusRepository = statusRepository;
        }

        public List<ToDosVM> GetAllTodos(int? categoryId, int? statusId)
        {
            List<ToDo> todos = _toDoRepository.GetAll();

            //FILTER
            if (categoryId.HasValue && categoryId.Value > 0)//> 0 zatoa sto vo baza imame categorii koi sto se pogolemi od 0
            {
                //logika
                todos = todos.Where(x => x.CategoryId == categoryId.Value).ToList();
            }
            if(statusId.HasValue && statusId.Value > 0)
            {
                todos = todos.Where(x => x.StatusId== statusId.Value).ToList();
            }

            var todosVM = new List<ToDosVM>();
            //mapiranje sto kje treba dase zeme sekoe todo ida se imapira vo view model
            foreach(var todo in todos)
            {
                var category = _categoryRepository.GetById(todo.CategoryId);
                var status = _statusRepository.GetById(todo.StatusId);

                var todoVM = OptionalMapper.MapToToDosVM(todo);
                todosVM.Add(todoVM);
            }
            return todosVM;
        }

    }
}
