using ASP.NET.Core.MVC.Class07.Database;
using ASP.NET.Core.MVC.Class07.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ASP.NET.Core.MVC.Class07.Helpers;

namespace ASP.NET.Core.MVC.Class07.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentVM> students = StaticDb.Students.Select(x =>
            Mapper.MapToStudentVM(x)
            ).ToList();

            return View(students);
        }

        [HttpGet("{id}")]//redosledot mora da bide ist
        public IActionResult GetStudentById([FromRoute]int id)//redoslednot mora da bide ist
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }
        [HttpGet("id")]
        public IActionResult GetStudentByIdWithQuery([FromQuery] int id)
        {
            var student = StaticDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }

        [HttpGet("filterBy")]
        public IActionResult GetStudentFilter([FromQuery] StudentFilterViewModel studentFilterViewModel)
        {
            var student = StaticDb.Students.FirstOrDefault(x => (DateTime.Now.Year - x.DateOfBirth.Year) == studentFilterViewModel.Age && x.GetFullName().ToLower() == studentFilterViewModel.FullName.ToLower());
            if (student == null)
            {
                return NotFound();
            }
            var studentVM = Mapper.MapToStudentDetailsVM(student);
            return View("StudentDetails", studentVM);
        }


        //ista routa httpget i httppost 
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult Create([FromForm]CreateStudentVM createStudentVM)//da se znae deka site podatoci se zemaat od forma
        {
            //biding atribut from for
            //kako imame forma vo vieto kje znae deka kje treba da go zeme kako cel objekt spakuvan i da go dade vo create student

            //MOdel state zima podatoci za sekoje pole , pred da gi kaze da li se validni
            //sekoe property 
            if (ModelState.IsValid)
            {
                //za dodavanje na baza treba da se dodade vo baaa treba mapiranje od view model vo domainski model
                //kreiranje na mapper
                StaticDb.Students.Add(Mapper.MapToStudent(createStudentVM));
                return RedirectToAction("Index");
            }
            //ako ne e validno treba pak da se vidi sto e greshno
            return View(createStudentVM);

        }



    }
}
