namespace MoviesApp.Domain.Models
{
    public class Actor : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
