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

        [Route("MovieDetails/{srMovieName?}")]
        public IActionResult MovieDetails(string? srMovieName)
        {
            ListOfMovies moviesList = new ListOfMovies();
            if (!string.IsNullOrEmpty(srMovieName))
                srMovieName = srMovieName.Replace("_", " ");

            var vrSelected = moviesList.MoviesList.Where(pr => pr.MovieName == srMovieName).FirstOrDefault();

            if (vrSelected == null)//this will keep same url
                return View("ListMovies", new ParentMovieListing { moviesList = new ListOfMovies(), perMovie = null });

            if (vrSelected == null)//this will change url
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
