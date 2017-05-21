using MovieRentalStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalStore.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime RealeaseDate { get; set; }

        public DateTime AddedDate { get; set; }

        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        public byte NumberInStock { get; set; }

    }
}