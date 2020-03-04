using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyModified.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public byte GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int NumberInStock { get; set; }

    }
}