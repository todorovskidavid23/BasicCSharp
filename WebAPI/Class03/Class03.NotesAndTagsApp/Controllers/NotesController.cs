using Class03.NotesAndTagsApp.Data;
using Class03.NotesAndTagsApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Class03.NotesAndTagsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        //lista na site notes
        //https://localhost:[port]/api/notes
        [HttpGet]
        public ActionResult<List<Note>> Get()
        {
            try
            {
                return Ok(StaticDb.Notes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //https://localhost:[port]/api/notes/{id}
        [HttpGet("{id:int}")]
        public ActionResult<Note> GetById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return BadRequest("Id must be positive number");
                }
                if (id >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {id}");
                }
                return Ok(StaticDb.Notes[id]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //QueryParametar
        //https://localhost:[port]/api/notes/queryString?id=1

        [HttpGet("queryString")]
        public ActionResult<Note> GetByIdQueryString(int? id)
        {
            try
            {
                if(id == null)
                {
                    return BadRequest("Id is required parameter");
                }
                if (id < 0)
                {
                    return BadRequest("Id must be positive number");
                }
                if (id >= StaticDb.Notes.Count)
                {
                    return NotFound($"There is no resource on index {id}");
                }
                return Ok(StaticDb.Notes[id.Value]);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //pathVariables
        //https://localhost:[port]/api/notes/gym/priority/2
        //gym e path variabla i 2 path variabla
        //gym da e variabla i 2 da e variabla da bidat search zbor za text notes
        [HttpGet("{text:alpha}/priority/{priority:int}")]
        public ActionResult<List<Note>> FilterNotes(string text, int priority)
        {
            try
            {
                if(string.IsNullOrEmpty(text) || priority <= 0)
                {
                    return BadRequest("Filter parameters are required and must be valid");
                }
                if (priority > 3)
                {
                    return BadRequest("Priority must be between 1 and 3");
                }
                var notes = StaticDb.Notes.Where(x => x.Text.ToLower().Contains(text.ToLower()) && (int)x.Priority == priority).ToList();
                if (notes.Count > 0)
                {
                    return Ok(notes);
                }
                return Ok("There aren't any notes found with that filter");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //https://localhost:[port]/api/notes

        [HttpPost]
        public IActionResult Post([FromBody]Note note)
        {
            try
            {
                if (string.IsNullOrEmpty(note.Text))
                {
                    return BadRequest("Note text is required");
                }
                if (note.Tags == null || note.Tags.Count == 0)
                {
                    return BadRequest("Note must have at least one tag");
                }
                StaticDb.Notes.Add(note);
                return StatusCode(StatusCodes.Status201Created, note);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //https://localhost:[port]/api/notes

        [HttpGet("userAgent")]
        public IActionResult GetUserAgent(
            [FromHeader(Name ="User-Agent")] string userAgent,
            [FromHeader(Name= "my-token")] string myToken)
        {
            //var headers = Request.QueryString.Value["||"];
            List<string> headers = [userAgent, myToken];
            return Ok(headers);
        }

    }
}
