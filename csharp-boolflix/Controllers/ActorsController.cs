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
    public class ActorsController : Controller
    {
        private BoolflixDbContext _db;

        public ActorsController()
        {
            _db = new BoolflixDbContext();
        }

        // GET: Actors
        public IActionResult Index()
        {
              return View(_db.Actors.ToList());
        }

        // GET: Actors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null || _db.Actors == null)
            {
                return NotFound();
            }

            var actor =_db.Actors
                .FirstOrDefault(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Surname")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                _db.Add(actor);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || _db.Actors == null)
            {
                return NotFound();
            }

            var actor = _db.Actors.Find(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Surname")] Actor actor)
        {
            if (id != actor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(actor);
                    _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Id))
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
            return View(actor);
        }

        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || _db.Actors == null)
            {
                return NotFound();
            }

            var actor = _db.Actors
                .FirstOrDefault(m => m.Id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_db.Actors == null)
            {
                return Problem("Entity set 'BoolflixDbContext.Actors'  is null.");
            }
            var actor = _db.Actors.Find(id);
            if (actor != null)
            {
                _db.Actors.Remove(actor);
            }
            
            _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
          return _db.Actors.Any(e => e.Id == id);
        }
    }
}
