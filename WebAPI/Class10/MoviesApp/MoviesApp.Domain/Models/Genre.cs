namespace MoviesApp.Domain.Models
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
