using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyModified.Models;
using System.ComponentModel.DataAnnotations;

namespace VidlyModified.ViewModel
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }



        [Display(Name = "Genre")]
        public Byte? GenreId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }


        public NewMovieViewModel()
        {
            Id = 0;
        }

        public NewMovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;


        }
    }
}