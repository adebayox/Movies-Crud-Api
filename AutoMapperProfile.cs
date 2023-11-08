using System;
using AutoMapper;
using Movies.Dtos.Movies;
using Movies.Models;

namespace Movies
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
            CreateMap<Movie, GetMovieDto>();

			CreateMap<AddMovieDto, Movie>();

            CreateMap<UpdateMovieDto, Movie>();
        }
	}
}

