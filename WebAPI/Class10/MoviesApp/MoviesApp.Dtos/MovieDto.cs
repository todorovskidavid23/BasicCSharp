namespace MoviesApp.Dtos
{
    // Тоа што клиентот го добива за секој филм во листа.
    // Забележи: ИМИЊА, не Id-а. README: "shows genre name, director name
    // and actor names - not ids".
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Year { get; set; }
        public int DurationMinutes { get; set; }

        public string GenreName { get; set; } = string.Empty;

        // null кога филмот нема режисер. NotesApp тука враќа "Unknown";
        // јас предпочитам null - клиентот сам одлучува како да го прикаже,
        // а "Unknown" е презентациска одлука што не ѝ е местото во API.
        public string? DirectorFullName { get; set; }
    }
}
