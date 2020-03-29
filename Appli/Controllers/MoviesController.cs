using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Appli.Models;
using Appli.ViewModels;

namespace Appli.Controllers
{
    public partial class MoviesController : Controller
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        public virtual ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View(MVC.Movies.Views.List);
            }
            return View(MVC.Movies.Views.ReadOnlyList);
        }

        public virtual ActionResult Details(int id)
        {
            var movie = context.Movies.Include(m => m.Genre).FirstOrDefault(x => x.Id == id);
            if (movie is null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public virtual ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Movie = new Movie(),
                Genres = context.Genres
            };
            return View(MVC.Movies.Views.MovieForm, viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public virtual ActionResult Edit(int id)
        {
            var movieDb = context.Movies.FirstOrDefault(x => x.Id == id);
            if (movieDb is null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel()
            {
                Movie = movieDb,
                Genres = context.Genres
            };
            return View(MVC.Movies.Views.MovieForm, viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public virtual ActionResult Save(MovieFormViewModel viewModel)
        {
            var movie = viewModel.Movie;
            if (!ModelState.IsValid)
            {
                viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = context.Genres
                };
                return View(MVC.Movies.Views.MovieForm, viewModel);
            }

            var movieDb = context.Movies.FirstOrDefault(x => x.Id == movie.Id);
            if (movieDb is null)
            {
                movie.DateAdded = DateTime.Now;
                context.Movies.Add(movie);
            }
            else
            {
                movieDb.Update(movie);
            }
            context.SaveChanges();
            return RedirectToAction(MVC.Movies.Index());
        }
    }
}