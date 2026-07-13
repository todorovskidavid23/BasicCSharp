using ASP.NET.Core.MVC.Database.Class09.DataAccess;
using ASP.NET.Core.MVC.Database.Class09.Models.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;

namespace ASP.NET.Core.MVC.Database.Class09.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        //za da rabotime so baza
        private readonly DemoDbContext _context;

        public StudentController(DemoDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();//ni dava DbSet preku context konekcija i mora Students deka taka ni se vika DbSetot!
            //SELECT * FROM STUDENTS e istoto ova gore
            return View(students);
        }

        //dodavanje vo baza
        //eden get i post za da se kreira forma
        [HttpGet("create")]
        public IActionResult Create()
        {
            var courses = _context.Courses.ToList();
            ViewBag.Courses = new SelectList(courses, "Id", "Name");//celiot model, key,value eve gi podatoite od courses, key sto se isprakja, i tie sto sakame da se prikazat KAKO MAPIRANJE NEKOE
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm]Student student)//prima cela forma
        {
            _context.Students.Add(student);//SEKOGAS KOGA DODAVAME BRISEME UPDATETIRAME MORA SaveChanges
            //se pretvara vo sql query
            _context.SaveChanges();//so ova se zacuvuva studentot
            return RedirectToAction("Index");
        }
    }
}
