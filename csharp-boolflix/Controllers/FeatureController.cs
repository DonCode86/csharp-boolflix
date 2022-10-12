using csharp_boolflix.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace csharp_boolflix.Controllers
{
    public class FeatureController : Controller
    {
        private BoolflixDbContext _db;

        public FeatureController()
        {
            _db = new BoolflixDbContext();
        }
        public IActionResult Index()
        {
            List<Feature> features = _db.Features.ToList();
            return View(features);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Feature feature)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _db.Features.Add(feature);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
