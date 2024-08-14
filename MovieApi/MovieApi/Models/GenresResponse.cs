namespace MovieApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenresResponse
    {
        public List<Genre> Genres { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class DiscoverMoviesResponse
    {
        public int Page { get; set; }
        public List<Movie> Results { get; set; }
    }
}
