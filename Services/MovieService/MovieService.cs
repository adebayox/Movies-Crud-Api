using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Dtos.Movies;
using Movies.Models;

namespace Movies.Services.MovieService
{
	public class MovieService : IMovieService
	{

        private static List<Movie> movies = new List<Movie>
        {
            new Movie(),

        };
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieService(IMapper mapper, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
		{
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public object Movies => throw new NotImplementedException();

        //AddMovieDto movie to the db
        public async Task<ServiceResponse<List<GetMovieDto>>> AddMovie(AddMovieDto newMovie)
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
            var movie = _mapper.Map<Movie>(newMovie);

            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Movies
           .Select(c => _mapper.Map<GetMovieDto>(c))
           .ToListAsync();

            return serviceResponse;
        }

        //Delete movie from the db
        public async Task<ServiceResponse<List<GetMovieDto>>> DeleteMovie(int movieid)
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
            try
            {
                var movie = await _context.Movies
                    .FirstOrDefaultAsync(c => c.MovieId == movieid);
                if (movie is null)

                    throw new Exception($"Movie with Id '{movieid}' not found.");

                _context.Movies.Remove(movie);

                await _context.SaveChangesAsync();

                serviceResponse.Data =
                    await _context.Movies         
                        .Select(c => _mapper.Map<GetMovieDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;

            }
            return serviceResponse;
        }

        //GetMovie movie from db
        public async Task<ServiceResponse<List<GetMovieDto>>> GetAllMovies()
        {
            var serviceResponse = new ServiceResponse<List<GetMovieDto>>();
            try
            {
                var movies = await _context.Movies
                    
                    .ToListAsync();

                serviceResponse.Data = _mapper.Map<List<GetMovieDto>>(movies);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        //GetMovie by id
        public async Task<ServiceResponse<GetMovieDto>> GetMovieById(int movieid)
        {
            var serviceResponse = new ServiceResponse<GetMovieDto>();
            var movies = await _context.Movies
                .FirstOrDefaultAsync(c => c.MovieId == movieid);

            if (movies == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Movie not found.";
                return serviceResponse;
            }

            serviceResponse.Data = _mapper.Map<GetMovieDto>(movies);
            return serviceResponse;
        }

        //UpdateMovie in db
        public async Task<ServiceResponse<GetMovieDto>> UpdateMovie(UpdateMovieDto updatedMovie)
        {
            var serviceResponse = new ServiceResponse<GetMovieDto>();
            try
            {
                var movie
                        = await _context.Movies
                        .FirstOrDefaultAsync(c => c.MovieId == updatedMovie.MovieId);
                if (movie is null)
                    throw new Exception($"Movie with Id '{updatedMovie.MovieId}'not found.");

                movie.MovieId = updatedMovie.MovieId;
                movie.Name = updatedMovie.Name;
                movie.Description = updatedMovie.Description;
                movie.ReleaseDate = updatedMovie.ReleaseDate;
                movie.Rating = updatedMovie.Rating;
                movie.TicketPrice = updatedMovie.TicketPrice;
                movie.Country = updatedMovie.Country;
                movie.Genres = updatedMovie.Genres;
                movie.Photo = updatedMovie.Photo;
                

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetMovieDto>(movie);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}

