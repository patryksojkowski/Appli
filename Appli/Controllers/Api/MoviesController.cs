using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Appli.Models;
using Appli.Dtos;

namespace Appli.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        // GET api/movies
        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = context.Movies
                .Include(m => m.Genre);

            if (!string.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query)).Where(m => m.NumberAvailable > 0);
            }

            var moviesDto = moviesQuery.Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDto);
        }

        // GET api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movieDb = context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieDb is null)
            {
                return NotFound();
            }
            var movieDto = Mapper.Map<Movie, MovieDto>(movieDb);
            return Ok(movieDto);
        }

        // POST api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]

        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            context.Movies.Add(movie);
            context.SaveChanges();
            Mapper.Map(movie, movieDto);
            return Created(new Uri($"{Request.RequestUri}/{movieDto.Id}"), movieDto);
        }

        // PUT api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movieDb = context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieDb is null)
            {
                return NotFound();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movieDb.Update(movie);
            context.SaveChanges();

            Mapper.Map(movieDb, movieDto);
            return Ok(movieDto);
        }

        // PUT api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieDb = context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieDb is null)
            {
                return NotFound();
            }

            context.Movies.Remove(movieDb);
            context.SaveChanges();
            return Ok();
        }
    }
}
