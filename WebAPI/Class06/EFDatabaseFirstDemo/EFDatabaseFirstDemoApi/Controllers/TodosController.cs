using EFDatabaseFirstDemoApi.Domain.Context;
using EFDatabaseFirstDemoApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        //nemame service, dataaccess itn i toa ne e dobro
        private readonly AppDbContext _context;

        public TodosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Todo>> GetAll()//znaeme sto kje vrati a IActionResult koga ne znaeme sto kje vrarime
        {
            //   List<Todo> todos = _context.Todos dbset vrakja a na kraj so .ToList() dava LISTA
            List<Todo> todos = _context.Todos
                .Include(todo=>todo.Category)
                .Include(todo=>todo.Status)
                .ToList();

            return Ok(todos);
        }
    
    }
}
