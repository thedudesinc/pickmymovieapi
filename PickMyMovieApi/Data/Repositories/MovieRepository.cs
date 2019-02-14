using PickMyMovieApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickMyMovieApi.Data.Repositories
{
    public class MovieRepository
    {
        private readonly PickMyMovieContext _context;

        public MovieRepository(PickMyMovieContext context)
        {
            _context = context;
        }

        public Movie Create(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            var createdMovie = Find(movie.Id);
            return createdMovie;
        }

        public void Delete(long id)
        {
            _context.Remove(_context.Movies.Where(m => m.Id == id).Single());
            _context.SaveChanges();
        }

        public Movie Find(long id)
        {
            return _context.Movies.Where(m => m.Id == id).ToList().SingleOrDefault();
        }

        public List<Movie> FindAll()
        {
            return _context.Movies.OrderBy(m => m.Title).ToList();
        }

        public List<Movie> FindMoviesForGroup(long groupId)
        {
            return _context.Movies.Where(m => m.GroupId == groupId).OrderBy(m => m.Title).ToList();
        }

        public long CountAll()
        {
            return _context.Movies.Count();
        }
    }
}
