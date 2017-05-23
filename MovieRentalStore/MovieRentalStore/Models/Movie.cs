using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalStore.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name="Release Date")]
        public DateTime RealeaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime AddedDate { get; set; }

        [Required]
        [Range(1,20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        [Display(Name = "Number in Stock")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }
    }
}