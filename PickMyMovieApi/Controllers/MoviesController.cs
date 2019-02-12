using Microsoft.AspNetCore.Mvc;
using PickMyMovieApi.Data;
using PickMyMovieApi.Data.Repositories;

namespace PickMyMovieApi.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private MovieRepository moviesRepository = new MovieRepository(new PickMyMovieContext());

        [HttpGet]
        public IActionResult GetMovies()
        {
            var movies = moviesRepository.FindAll();

            if (movies == null)
                return NoContent();

            return Ok(movies);
        }
    }
}
