namespace MoviesApp.Domain.Models
{
    public class Director : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        //we use ICollection<Movie> to represent the one-to-many relationship between Director and Movie.
        //A director can direct multiple movies, so we use a collection to hold all the movies directed by a particular director.
    }
}
