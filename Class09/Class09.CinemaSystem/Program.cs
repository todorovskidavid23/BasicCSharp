using Class09.CinemaSystem.Enums;
using Class09.CinemaSystem.Models;


List<Movie> movies1 = new List<Movie>()
{
    new Movie("Inception", Genre.SciFi, 5),
    new Movie("Interstellar", Genre.SciFi, 5),
    new Movie("Titanic", Genre.Drama, 4),
    new Movie("The Notebook", Genre.Drama, 4),
    new Movie("John Wick", Genre.Action, 5),
    new Movie("Gladiator", Genre.Action, 5),
    new Movie("The Conjuring", Genre.Horror, 4),
    new Movie("It", Genre.Horror, 3),
    new Movie("The Hangover", Genre.Comedy, 4),
    new Movie("Superbad", Genre.Comedy, 4)
};

List<Movie> movies2 = new List<Movie>()
{
    new Movie("Avatar", Genre.SciFi, 5),
    new Movie("The Matrix", Genre.SciFi, 5),
    new Movie("La La Land", Genre.Drama, 4),
    new Movie("A Star is Born", Genre.Drama, 4),
    new Movie("Mad Max", Genre.Action, 5),
    new Movie("Die Hard", Genre.Action, 5),
    new Movie("Insidious", Genre.Horror, 4),
    new Movie("Halloween", Genre.Horror, 3),
    new Movie("Step Brothers", Genre.Comedy, 4),
    new Movie("The 40-Year-Old Virgin", Genre.Comedy, 4)
};

List<Cinema> cinemas = new List<Cinema>()
{
    new Cinema("Cineplex", 10, movies1),
    new Cinema("Millennium", 8, movies2)
};

try
{
    Console.WriteLine("Choose a cinema:");
    for (int i = 0; i < cinemas.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {cinemas[i].Name}");
    }

    if (!int.TryParse(Console.ReadLine(), out int cinemaIndex) || cinemaIndex < 1 || cinemaIndex > cinemas.Count)
        throw new Exception("Invalid cinema selection.");

    Cinema selectedCinema = cinemas[cinemaIndex-1];

    Console.WriteLine("Choose an option:");
    Console.WriteLine("1.AllMovies");
    Console.WriteLine("2.By genre");
    string option = Console.ReadLine();

    List<Movie> listToShow;

    if (option == "1")
    {
        listToShow = selectedCinema.ListOfMovies;
    }
    else if (option == "2")
    {
        Console.WriteLine("Enter your favorite genre (Comedy, Horror, Action, Drama, SciFi):");
        string genreInput = Console.ReadLine();
        if (!Enum.TryParse(genreInput, true, out Genre genre))
            throw new Exception("Invalid genre!");

        listToShow = selectedCinema.ListOfMovies.FindAll(m => m.Genre == genre);
        if (listToShow.Count == 0)
            throw new Exception("No movies in this genre.");
    }
    else
    {
        throw new Exception("Invalid option!");
    }

    for (int i = 0; i < listToShow.Count; i++)
    {
        var m = listToShow[i];
        Console.WriteLine($"{i + 1}. {m.Title} ({m.Genre}) - Rating: {m.Rating} - Price: ${m.TicketPrice}");
    }

    Console.WriteLine("Enter the number of the movie you want to watch:");
    if (!int.TryParse(Console.ReadLine(), out int movieIndex) || movieIndex < 1 || movieIndex > listToShow.Count)
        throw new Exception("Invalid movie selection!");

    Movie chosen = listToShow[movieIndex - 1];
    selectedCinema.MoviePlaying(chosen);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



//List<Movie> movies = new List<Movie>()
//{
//    new Movie("Inception", Genre.SciFi, 5),
//    new Movie("Interstellar", Genre.SciFi, 5),
//    new Movie("Titanic", Genre.Drama, 4),
//    new Movie("The Notebook", Genre.Drama, 4),
//    new Movie("John Wick", Genre.Action, 5),
//    new Movie("Gladiator", Genre.Action, 5),
//    new Movie("The Conjuring", Genre.Horror, 4),
//    new Movie("It", Genre.Horror, 3),
//    new Movie("The Hangover", Genre.Comedy, 4),
//    new Movie("Superbad", Genre.Comedy, 4)
//};

//Cinema cinema1 = new Cinema("Cineplex", 10, movies);
//// If you want, add more cinemas later by adding more Cinema instances to this list.
//List<Cinema> cinemas = new List<Cinema> { cinema1 };

//try
//{
//    Console.WriteLine("Choose a cinema (enter the number):");
//    for (int i = 0; i < cinemas.Count; i++)
//    {
//        Console.WriteLine($"{i + 1}. {cinemas[i].Name}");
//    }

//    string cinemaInput = Console.ReadLine();
//    if (!int.TryParse(cinemaInput, out int cinemaIndex) || cinemaIndex < 1 || cinemaIndex > cinemas.Count)
//    {
//        throw new Exception("Invalid cinema selection.");
//    }

//    Cinema selectedCinema = cinemas[cinemaIndex - 1];

//    Console.WriteLine("Choose an option:\n1. All movies\n2. By genre");
//    string option = Console.ReadLine();

//    if (option == "1")
//    {
//        if (selectedCinema.ListOfMovies == null || selectedCinema.ListOfMovies.Count == 0)
//            throw new Exception("No movies available in this cinema.");

//        Console.WriteLine("All movies:");
//        for (int i = 0; i < selectedCinema.ListOfMovies.Count; i++)
//        {
//            var m = selectedCinema.ListOfMovies[i];
//            Console.WriteLine($"{i + 1}. {m.Title} ({m.Genre}) - Rating: {m.Rating} - Price: ${m.TicketPrice}");
//        }

//        Console.WriteLine("Enter the number of the movie you want to watch:");
//        string movieChoice = Console.ReadLine();
//        if (!int.TryParse(movieChoice, out int movieIndex) || movieIndex < 1 || movieIndex > selectedCinema.ListOfMovies.Count)
//            throw new Exception("Invalid movie selection.");

//        Movie chosen = selectedCinema.ListOfMovies[movieIndex - 1];
//        selectedCinema.MoviePlaying(chosen);
//    }
//    else if (option == "2")
//    {
//        // By genre
//        Console.WriteLine("Enter your favorite genre. Available genres:");
//        foreach (var name in Enum.GetNames(typeof(Genre)))
//        {
//            Console.WriteLine($"- {name}");
//        }

//        string genreInput = Console.ReadLine();
//        if (!Enum.TryParse<Genre>(genreInput, true, out Genre parsedGenre))
//            throw new Exception("Invalid genre.");

//        var filtered = selectedCinema.ListOfMovies.FindAll(m => m.Genre == parsedGenre);
//        if (filtered == null || filtered.Count == 0)
//            throw new Exception($"No movies found for genre {parsedGenre}.");

//        Console.WriteLine($"Movies in {parsedGenre}:");
//        for (int i = 0; i < filtered.Count; i++)
//        {
//            var m = filtered[i];
//            Console.WriteLine($"{i + 1}. {m.Title} - Rating: {m.Rating} - Price: ${m.TicketPrice}");
//        }

//        Console.WriteLine("Enter the number of the movie you want to watch:");
//        string movieChoice = Console.ReadLine();
//        if (!int.TryParse(movieChoice, out int movieIndex) || movieIndex < 1 || movieIndex > filtered.Count)
//            throw new Exception("Invalid movie selection.");

//        Movie chosen = filtered[movieIndex - 1];
//        selectedCinema.MoviePlaying(chosen);
//    }
//    else
//    {
//        throw new Exception("Invalid option selected.");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error: {ex.Message}");
//}
