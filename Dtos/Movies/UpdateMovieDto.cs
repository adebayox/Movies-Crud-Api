using System;
using Movies.Models;

namespace Movies.Dtos.Movies
{
	public class UpdateMovieDto
	{
        public int MovieId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public decimal Rating { get; set; }

        public decimal TicketPrice { get; set; }

        public string Country { get; set; }

        public string Genres { get; set; }

        public string Photo { get; set; }
    }
}

