namespace MoviesApp.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public int DurationMinutes { get; set; }

        //1:M relations with Genre 
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;
        //Genre genre = null! means that the Genre property is required and cannot be null.
        //The null-forgiving operator (!) is used to suppress the compiler warning about potential null reference.

        //1:M relation with Director
        public int? DirectorId { get; set; }
        public Director? Director { get; set; }
        //Director? Director means that the Director property is optional and can be null.

        //M:N relation with Actor
        public ICollection<Actor> Actors { get; set; } = new List<Actor>();
        
    }
}
