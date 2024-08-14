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
        private readonly string _bearerToken;

        public MovieApiController(IConfiguration configuration)
        {
            // Retrieve the token from appsettings.json
            _bearerToken = configuration["MovieApi:BearerToken"]
                ?? throw new InvalidOperationException("Bearer token not found in configuration.");
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetMovieCategories()
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/genre/movie/list?language=en");
            var client = new RestClient(options);
            var request = new RestRequest();
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_bearerToken}");
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
