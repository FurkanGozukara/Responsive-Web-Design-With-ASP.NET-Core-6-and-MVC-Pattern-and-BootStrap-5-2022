namespace lecture_1.Models
{
    public class ListOfMovies
    {
        public List<Movie> MoviesList { get; set; }

        public ListOfMovies()
        {
            MoviesList = new List<Movie>
            {
                new Movie {MovieName = "Inception", MovieGenre = "Thriller", MovieId = 1, MovieYear = 2012},
                new Movie {MovieName = "Star Wars" , MovieGenre = "Science Fiction" , MovieId = 2 , MovieYear = 2020},
                new Movie{MovieName = "Alien 1", MovieGenre = "Horror", MovieId = 3, MovieYear = 1985}
            };
        }
    }
}
