using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieRentalStore.Dtos;
using MovieRentalStore.Models;

namespace MovieRentalStore.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        } 


        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRental)
        {
            var customerDb = _context.Customers
                .Single(c => c.Id == newRental.CustomerId);
            var movies = _context.Movies
                .Where(m=> newRental.MovieIds.Contains(m.Id))
                .ToList();



            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not Available");

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customerDb,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
              
            }
            _context.SaveChanges();

            return Ok();
        }

    }
}
