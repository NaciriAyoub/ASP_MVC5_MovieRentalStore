using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalStore.Models;

namespace MovieRentalStore.ViewModels
{
    public class MovieViewModel
    {
        public Movie Movie { set; get; }
        public IEnumerable<Genre> Genres { set; get; }

    }
}