namespace MovieApi.Models
{
    public class GenresResponse
    {
        public List<Genre> Genres { get; set; }
    }

    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
