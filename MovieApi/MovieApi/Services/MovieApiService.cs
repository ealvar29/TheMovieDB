using RestSharp;
using System.Text.Json;
using MovieApi.Models;

namespace MovieApi.Services
{
    public class MovieApiService
    {
        private readonly RestClient _client;
        private readonly string _bearerToken;

        public MovieApiService(string baseUrl, string bearerToken)
        {
            _bearerToken = bearerToken;
            var options = new RestClientOptions(baseUrl)
            {
                // You can set other options here if needed, like timeouts or proxies
            };
            _client = new RestClient(options);
        }

        private RestRequest CreateRequest(string endpoint, Method method = Method.Get)
        {
            var request = new RestRequest(endpoint, method);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", $"Bearer {_bearerToken}");
            return request;
        }

        public async Task<GenresResponse> GetGenresAsync()
        {
            var request = CreateRequest("/genre/movie/list?language=en");
            var response = await _client.GetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonSerializer.Deserialize<GenresResponse>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                // Handle the error appropriately
                throw new Exception($"Failed to fetch genres: {response.StatusCode} {response.StatusDescription}");
            }
        }

        public async Task<DiscoverMoviesResponse> DiscoverMoviesByGenreAsync(IEnumerable<Genre> genreList)
        {
            RestRequest request = null;
            if (genreList.Any() && genreList.Count() < 2)
            {
                request = CreateRequest($"/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc&with_genres={genreList.FirstOrDefault().Id}");
            }
            else if(genreList.Any() && genreList.Count() > 1)
            {
                string commaListed = string.Join(",", genreList.Select(x => x.Id));
                request = CreateRequest($"/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc&with_genres={commaListed}");
            }
            var response = await _client.GetAsync(request);

            if (response.IsSuccessful)
            {
                return JsonSerializer.Deserialize<DiscoverMoviesResponse>(response.Content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                // Handle the error appropriately
                throw new Exception($"Failed to discover movies: {response.StatusCode} {response.StatusDescription}");
            }
        }
    }
}
