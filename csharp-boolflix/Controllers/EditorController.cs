using Microsoft.AspNetCore.Mvc;

namespace csharp_boolflix.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
        public IActionResult Film()
        {
            return View();
        }

        public IActionResult TvSeries()
        {
            return View();
        }

        public IActionResult Genres()
        {
            return View();
        }

        public IActionResult Features()
        {
            return View();
        }

        public IActionResult Actors()
        {
            return View();
        }
    }
}
