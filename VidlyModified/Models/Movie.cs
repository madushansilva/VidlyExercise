using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VidlyModified.Models
{
    public class Movie
    {

        public int Id { get; set; }

        public string Name { get; set; }



        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }


    }
}