using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;
using System.Collections.Generic;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/Categories")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        public MovieApiController()
        {
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetMovieCategories()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/genre/movie/list?language=en");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJjYTBkZDZmM2QwZmVhODZmMTA1NTIwMTAyOWY1ZTJhOSIsIm5iZiI6MTcyMjk3OTI5Ny43MjgzODksInN1YiI6IjYwYzUyYzFhN2E5N2FiMDA0MmIzN2FhMSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.PgyQ_KGH721zQhHOILJKlgQkBT07LVsKhC6U2W01MGA");
            var response = await client.GetAsync(request);

            if (response.IsSuccessful)
            {
                var jsonResponse = response.Content;

                // Deserialize the JSON response
                var genres = JsonSerializer.Deserialize<GenresResponse>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return Ok(genres);
            }
            else
            {
                return StatusCode((int)response.StatusCode, response.StatusDescription);
            }
        }
    }
}
