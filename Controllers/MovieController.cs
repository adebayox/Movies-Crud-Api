using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.Dtos.Movies;
using Movies.Models;
using Movies.Services.MovieService;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //GET ALL Movies
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> Get()
        {
            return Ok(await _movieService.GetAllMovies());
        }

        //DELETE A Movie
        [HttpDelete("{movieid}")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> Delete(int movieid)
        {
            var response = await _movieService.DeleteMovie(movieid);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        //GET A SINGLE movie BY USING movie ID
        [HttpGet("{movieid}")]
        public async Task<ActionResult<ServiceResponse<GetMovieDto>>> GetSingle(int movieid)
        {
            return Ok(await _movieService.GetMovieById(movieid));
        }

        //Create a movie
        [HttpPost("create-movie")]
        public async Task<ActionResult<ServiceResponse<List<GetMovieDto>>>> AddMovie(AddMovieDto newMovie)
        {

            return Ok(await _movieService.AddMovie(newMovie));
        }

        //update a movie
        [HttpPut("edit-movie")]
        public async Task<ActionResult<ServiceResponse<GetMovieDto>>> UpdatedMovie(UpdateMovieDto updatedMovie)
        {
            var response = await _movieService.UpdateMovie(updatedMovie);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
