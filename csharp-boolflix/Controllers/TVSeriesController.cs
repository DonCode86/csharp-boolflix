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
    public class TVSeriesController : Controller
    {
        public BoolflixDbContext _db;

        public TVSeriesController()
        {
            _db = new BoolflixDbContext();
        }

        // GET: TVSeries
        public IActionResult Index()
        {
              return View(_db.TvSeries.ToList());
        }

        // GET: TVSeries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _db.TvSeries == null)
            {
                return NotFound();
            }

            var tVSeries = _db.TvSeries
                .FirstOrDefault(m => m.Id == id);
            if (tVSeries == null)
            {
                return NotFound();
            }

            return View(tVSeries);
        }

        // GET: TVSeries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TVSeries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SeasonCount,Id,Title,Duration,Description,VisualizationCount")] TVSeries tVSeries)
        {
            if (ModelState.IsValid)
            {
                _db.Add(tVSeries);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tVSeries);
        }

        // GET: TVSeries/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _db.TvSeries == null)
            {
                return NotFound();
            }

            var tVSeries = _db.TvSeries.Find(id);
            if (tVSeries == null)
            {
                return NotFound();
            }
            return View(tVSeries);
        }

        // POST: TVSeries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SeasonCount,Id,Title,Duration,Description,VisualizationCount")] TVSeries tVSeries)
        {
            if (id != tVSeries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(tVSeries);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TVSeriesExists(tVSeries.Id))
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
            return View(tVSeries);
        }

        // GET: TVSeries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.TvSeries == null)
            {
                return NotFound();
            }

            var tVSeries =_db.TvSeries
                .FirstOrDefault(m => m.Id == id);
            if (tVSeries == null)
            {
                return NotFound();
            }

            return View(tVSeries);
        }

        // POST: TVSeries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_db.TvSeries == null)
            {
                return Problem("Entity set 'BoolflixDbContext.TvSeries'  is null.");
            }
            var tVSeries = _db.TvSeries.Find(id);
            if (tVSeries != null)
            {
                _db.TvSeries.Remove(tVSeries);
            }
            
            _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TVSeriesExists(int id)
        {
          return _db.TvSeries.Any(e => e.Id == id);
        }
    }
}
