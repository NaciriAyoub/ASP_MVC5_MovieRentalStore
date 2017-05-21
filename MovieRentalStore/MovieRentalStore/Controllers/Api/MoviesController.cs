﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using MovieRentalStore.Dtos;
using MovieRentalStore.Models;
using AutoMapper;

namespace MovieRentalStore.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=> m.Id == id);
            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }


        //POST
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        //PUT
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Single(x => x.Id == id);
            if (movieInDb == null)
                return NotFound();


            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }


        //Delete
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.Single(x => x.Id == id);
            if (movieInDb == null)
                return NotFound();


            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }

    }
}