using Microsoft.AspNetCore.Mvc;
using lecture_1.Models;

namespace lecture_1.Controllers
{
    public class MovieDetailsController : Controller
    {
        public IActionResult ListMovies()
        {
            ListOfMovies _moviesList = new ListOfMovies();
            ParentMovieListing parentMovie = new ParentMovieListing
            {
                moviesList = _moviesList,
                perMovie = null
            };
            return View("ListMovies", parentMovie);
        }

        [Route("MovieDetails")]
        public IActionResult MovieDetails(string? srMovieName)
        {
            ListOfMovies moviesList = new ListOfMovies();
            var vrSelected = moviesList.MoviesList.Where(pr => pr.MovieName == srMovieName).FirstOrDefault();

            if (vrSelected == null)
                return RedirectToAction("ListMovies", "MovieDetails");

            ParentMovieListing parentMovie = new ParentMovieListing
            {
                moviesList = null,
                perMovie = vrSelected
            };

            return View("ListMovies", parentMovie);
        }
    }
}
