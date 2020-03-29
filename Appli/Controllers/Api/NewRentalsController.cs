using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Appli.Dtos;
using Appli.Models;

namespace Appli.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        ApplicationDbContext context = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        // POST api/newrentals
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = context.Customers.First(x => x.Id == newRental.CustomerId);
            var movies = context.Movies.Where(x => newRental.MovieIds.Contains(x.Id));

            foreach(var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest($"Movie {movie.Name} is not available.");
                }
                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                context.Rentals.Add(rental);
            }

            context.SaveChanges();
            return Ok();
        }
    }
}