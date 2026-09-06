using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Dtos;
using MoviesApp.Services.CustomExceptions;
using MoviesApp.Services.Interfaces;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // #1 GET /api/movies
        // #2 GET /api/movies?genreId=2&year=1994&title=pulp
        [HttpGet]
        public async Task<ActionResult<List<MovieDto>>> GetAll(
            [FromQuery] int? genreId = null,
            [FromQuery] int? year = null,
            [FromQuery] string? title = null)
        {
            try
            {
                // Филтрите се предаваат надолу. Контролерот не филтрира ништо.
                List<MovieDto> result = await _movieService.GetAllMoviesAsync(genreId, year, title);

                // Празна листа е валиден одговор: 200 + [].
                // Свесна одлука - "нема резултати" не е грешка.
                return Ok(result);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #3 GET /api/movies/5
        [HttpGet("{id:int}", Name = nameof(GetMovieById))]
        public async Task<ActionResult<MovieDetailsDto>> GetMovieById([FromRoute] int id)
        {
            try
            {
                MovieDetailsDto result = await _movieService.GetMovieByIdAsync(id);
                return Ok(result);
            }
            catch (MovieNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #4 POST /api/movies
        [HttpPost]
        public async Task<ActionResult<MovieDetailsDto>> Create([FromBody] AddMovieDto addMovieDto)
        {
            try
            {
                MovieDetailsDto created = await _movieService.AddMovieAsync(addMovieDto);

                // 201 + Location заглавје што навистина се отвора.
                // nameof(GetMovieById) мора да одговара на именуваната рута погоре.
                return CreatedAtAction(
                    actionName: nameof(GetMovieById),
                    routeValues: new { id = created.Id },
                    value: created);
            }
            catch (GenreNotFoundException ex)
            {
                // 400: рутата е точна, ТЕЛОТО е погрешно.
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (DirectorNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (ActorNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (MovieDataException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #5 PUT /api/movies/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateMovieDto updateMovieDto)
        {
            try
            {
                await _movieService.UpdateMovieAsync(id, updateMovieDto);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                // 404: id-то доаѓа од РУТАТА.
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (GenreNotFoundException ex)
            {
                // 400: id-то доаѓа од ТЕЛОТО.
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (DirectorNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (ActorNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status400BadRequest);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #6 DELETE /api/movies/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _movieService.DeleteMovieAsync(id);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #15 POST /api/movies/3/actors/5
        [HttpPost("{movieId:int}/actors/{actorId:int}")]
        public async Task<IActionResult> AddActor(
            [FromRoute] int movieId,
            [FromRoute] int actorId)
        {
            try
            {
                await _movieService.AddActorToMovieAsync(movieId, actorId);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (ActorNotFoundException ex)
            {
                // 404: и овој id доаѓа од рутата.
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (ConflictException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status409Conflict);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        // #16 DELETE /api/movies/3/actors/5
        [HttpDelete("{movieId:int}/actors/{actorId:int}")]
        public async Task<IActionResult> RemoveActor(
            [FromRoute] int movieId,
            [FromRoute] int actorId)
        {
            try
            {
                await _movieService.RemoveActorFromMovieAsync(movieId, actorId);
                return NoContent();
            }
            catch (MovieNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (ActorNotFoundException ex)
            {
                return Problem(detail: ex.Message, statusCode: StatusCodes.Status404NotFound);
            }
            catch (Exception)
            {
                return Problem(
                    detail: "An error occurred, please contact the administrator.",
                    statusCode: StatusCodes.Status500InternalServerError);
            }
        }
    }
}
