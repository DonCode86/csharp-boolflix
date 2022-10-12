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
    public class FilmsController : Controller
    {
        private BoolflixDbContext _db;

        public FilmsController()
        {
            _db = new BoolflixDbContext();
        }


        // GET: Films
        public IActionResult Index()
        {
            var boolflixDbContext = _db.Films.Include(f => f.Pegi);
            return View(boolflixDbContext.ToList());
        }

        // GET: Films/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _db.Films == null)
            {
                return NotFound();
            }

            var film = _db.Films
                .Include(f => f.Pegi)
                .FirstOrDefault(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewData["PegiId"] = new SelectList(_db.Pegis, "Id", "Id");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Duration,PegiId,Id,Title,Description,VisualizationCount")] Film film)
        {
            if (ModelState.IsValid)
            {
                _db.Add(film);
                _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PegiId"] = new SelectList(_db.Pegis, "Id", "Id", film.PegiId);
            return View(film);
        }

        // GET: Films/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _db.Films == null)
            {
                return NotFound();
            }

            var film = _db.Films.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            ViewData["PegiId"] = new SelectList(_db.Pegis, "Id", "Id", film.PegiId);
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Duration,PegiId,Id,Title,Description,VisualizationCount")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(film);
                    _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            ViewData["PegiId"] = new SelectList(_db.Pegis, "Id", "Id", film.PegiId);
            return View(film);
        }

        // GET: Films/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.Films == null)
            {
                return NotFound();
            }

            var film = _db.Films
                .Include(f => f.Pegi)
                .FirstOrDefault(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_db.Films == null)
            {
                return Problem("Entity set 'BoolflixDbContext.Films'  is null.");
            }
            var film = _db.Films.Find(id);
            if (film != null)
            {
                _db.Films.Remove(film);
            }
            
            _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
          return _db.Films.Any(e => e.Id == id);
        }
    }
}
