using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Collections.Generic;
using MovieApi.Models;
using MovieApi.Services;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly MovieApiService _movieApiService;

        public MovieApiController(MovieApiService movieApiService)
        {
            _movieApiService = movieApiService;
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetMovieGenres()
        {
            var genres = await _movieApiService.GetGenresAsync();
            return Ok(genres);
        }

        [HttpPost("movies")]
        public async Task<IActionResult> DiscoverMovies([FromBody] string genreId)
        {
            var movies = await _movieApiService.DiscoverMoviesByGenreAsync(genreId);
            return Ok(movies);
        }

        [HttpGet("discover")]
        public async Task<IActionResult> DiscoverMoviesByGenre([FromQuery] string genreId)
        {
            try
            {
                var movies = await _movieApiService.DiscoverMoviesByGenreAsync(genreId);
                return Ok(new { movies = movies });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
