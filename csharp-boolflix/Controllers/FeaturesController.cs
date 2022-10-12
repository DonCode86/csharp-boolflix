using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using csharp_boolflix.Context;

namespace csharp_boolflix.Controllers
{
    public class FeaturesController : Controller
    {
        private BoolflixDbContext _db;

        public FeaturesController()
        {
            _db = new BoolflixDbContext();
        }

        // GET: Features
        public IActionResult Index()
        {
              return View(_db.Features.ToList());
        }

        // GET: Features/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _db.Features == null)
            {
                return NotFound();
            }

            var feature = _db.Features
                .FirstOrDefault(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // GET: Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                _db.Add(feature);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Features/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _db.Features == null)
            {
                return NotFound();
            }

            var feature = _db.Features.Find(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        // POST: Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name")] Feature feature)
        {
            if (id != feature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(feature);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(feature.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Features/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.Features == null)
            {
                return NotFound();
            }

            var feature = _db.Features
                .FirstOrDefault(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // POST: Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_db.Features == null)
            {
                return Problem("Entity set 'BoolflixDbContext.Features'  is null.");
            }
            var feature = _db.Features.Find(id);
            if (feature != null)
            {
                _db.Features.Remove(feature);
            }
            
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureExists(int id)
        {
          return _db.Features.Any(e => e.Id == id);
        }
    }
}
