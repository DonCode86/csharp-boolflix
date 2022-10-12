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
    public class EpisodesController : Controller
    {
        private BoolflixDbContext _db;

        public EpisodesController()
        {
            _db = new BoolflixDbContext();
        }

        // GET: Episodes
        public IActionResult Index()
        {
            var boolflixDbContext = _db.Episodes.Include(e => e.TVSerie);
            return View(boolflixDbContext.ToList());
        }

        // GET: Episodes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _db.Episodes == null)
            {
                return NotFound();
            }

            var episode = _db.Episodes
                .Include(e => e.TVSerie)
                .FirstOrDefault(m => m.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // GET: Episodes/Create
        public IActionResult Create()
        {
            ViewData["TVSeriesId"] = new SelectList(_db.TvSeries, "Id", "Id");
            return View();
        }

        // POST: Episodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("SeasonNumber,TVSeriesId,Id,Title,Duration,Description,VisualizationCount")] Episode episode)
        {
            if (ModelState.IsValid)
            {
                _db.Add(episode);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TVSeriesId"] = new SelectList(_db.TvSeries, "Id", "Id", episode.TVSeriesId);
            return View(episode);
        }

        // GET: Episodes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _db.Episodes == null)
            {
                return NotFound();
            }

            var episode = _db.Episodes.Find(id);
            if (episode == null)
            {
                return NotFound();
            }
            ViewData["TVSeriesId"] = new SelectList(_db.TvSeries, "Id", "Id", episode.TVSeriesId);
            return View(episode);
        }

        // POST: Episodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("SeasonNumber,TVSeriesId,Id,Title,Duration,Description,VisualizationCount")] Episode episode)
        {
            if (id != episode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(episode);
                    _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EpisodeExists(episode.Id))
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
            ViewData["TVSeriesId"] = new SelectList(_db.TvSeries, "Id", "Id", episode.TVSeriesId);
            return View(episode);
        }

        // GET: Episodes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.Episodes == null)
            {
                return NotFound();
            }

            var episode = _db.Episodes
                .Include(e => e.TVSerie)
                .FirstOrDefault(m => m.Id == id);
            if (episode == null)
            {
                return NotFound();
            }

            return View(episode);
        }

        // POST: Episodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_db.Episodes == null)
            {
                return Problem("Entity set 'BoolflixDbContext.Episodes'  is null.");
            }
            var episode = _db.Episodes.Find(id);
            if (episode != null)
            {
                _db.Episodes.Remove(episode);
            }
            
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool EpisodeExists(int id)
        {
          return _db.Episodes.Any(e => e.Id == id);
        }
    }
}
