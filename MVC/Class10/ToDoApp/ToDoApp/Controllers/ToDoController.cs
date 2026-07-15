using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models.Dtos;
using ToDoApp.Models.ViewModels;
using ToDoApp.Services.Implementations;
using ToDoApp.Services.Interfaces;

namespace ToDoApp.Controllers
{
    [Route("todos")]
    public class ToDoController : Controller
    {
        private readonly IToDoService _toDoService;
        private readonly IFilterService _filterService;
        public ToDoController(IToDoService toDoService, IFilterService filterService)
        {
            //_toDoService = new ToDoService();
            _toDoService = toDoService;
            _filterService = filterService;
        }

        [HttpGet]
        public IActionResult GetAllToDos([FromQuery] int? categoryId, [FromQuery] int? statusId)
        {
            ViewBag.Filter = new FilterDto();//stanuva tip od FilterDto prenesuva so podatoci od ova view i sega kje treba da gi popolnime

            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            if (TempData["HasFilter"] != null)//ako ima filtriranje
            {
                //ViewBag.HasFilter = true;//nacin kako da ispatime podtoci od controller vo view
                //viewmodel 
                //videdata
                ViewBag.Filter.CategoryId = categoryId;
                ViewBag.Filter.StatusId = statusId;
            }

            //ovde bea dvete ViewBag
            

            var todos = _toDoService.GetAllTodos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterVM filterVM)//od fomata kje gi zememe podatoci da gi ispratime vo baza
        {
            //da se proveri dali imame nesto za filtriranje
            if(filterVM.StatusId > 0 || filterVM.CategoryId > 0)
            {
                //tempt data koga sakame da preneseme podatoci od edna akcija vo druga
                //dali filterot imas filter ili neams filter samo so True/False, ako se pogolemi od 0 imame data za filtriranje
                TempData["HasFilter"] = true;
                return RedirectToAction("GetAllToDos", new { categoryId = filterVM.CategoryId, statusId = filterVM.StatusId });
            }
            return RedirectToAction("GetAllToDos");
        }

    }
}
