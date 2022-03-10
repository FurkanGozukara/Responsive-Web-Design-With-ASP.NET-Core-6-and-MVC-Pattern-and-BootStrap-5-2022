using Microsoft.AspNetCore.Mvc;
using lecture_1.Models;

namespace lecture_1.Controllers
{
    public class MovieDetailsController : Controller
    {
        public IActionResult ListMovies()
        {
            ListOfMovies moviesList = new ListOfMovies();
            return View("ListMovies", moviesList);
        }

        public IActionResult MovieDetails(string? srMovieName)
        {
            return RedirectToAction("ListMovies", "MovieDetails");//we will return back to list movies action

            ListOfMovies moviesList = new ListOfMovies();
            var vrSelected = moviesList.MoviesList.Where(pr => pr.MovieName == srMovieName);

            if(!vrSelected.Any())
                return RedirectToAction("ListMovies", "MovieDetails");

            return View();
        }
    }
}
