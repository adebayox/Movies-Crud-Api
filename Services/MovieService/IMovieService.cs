using System;
using Movies.Dtos.Movies;
using Movies.Models;

namespace Movies.Services.MovieService
{
	public interface IMovieService
	{
		object Movies { get; }

        Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies();

        Task<ServiceResponse<GetMovieDto>> GetMovieById(int movieid);

        Task<ServiceResponse<List<GetMovieDto>>> AddMovie(AddMovieDto newMovie);

        Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updatedMovie);

        Task<ServiceResponse<List<GetMovieDto>>> DeleteMovie(int movieid);
    }
}

