using Microsoft.AspNetCore.Mvc;
using PickMyMovieApi.Data;
using PickMyMovieApi.Data.Models;
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

        [HttpGet("group/{groupId}")]
        public IActionResult GetMoviesForGroup(long groupId)
        {
            var movies = moviesRepository.FindMoviesForGroup(groupId);

            if (movies == null)
                return NoContent();

            return Ok(movies);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(long id)
        {
            moviesRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(long id)
        {
            var movie = moviesRepository.Find(id);

            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        [HttpGet("count")]
        public IActionResult CountBooks()
        {
            long numberOfMovies = moviesRepository.CountAll();

            if (numberOfMovies == 0)
                return NoContent();

            return Ok(numberOfMovies);
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody]Movie movie)
        {
            var createdMovie = moviesRepository.Create(movie);

            return CreatedAtAction(nameof(GetMovie), new { id = createdMovie.Id }, createdMovie); ;
        }
    }
}
