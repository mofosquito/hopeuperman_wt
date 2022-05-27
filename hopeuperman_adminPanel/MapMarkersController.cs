using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Models;

namespace hopeuperman_adminPanel
{
    public class MapMarkersController : Controller
    {
        private readonly hopeupermanDbContext _context;

        public MapMarkersController(hopeupermanDbContext context)
        {
            _context = context;
        }

        // GET: MapMarkers
        public async Task<IActionResult> Index()
        {
            var hopeupermanDbContext = _context.MapMarkers.Include(m => m.Admin);
            return View(await hopeupermanDbContext.ToListAsync());
        }

        // GET: MapMarkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MapMarkers == null)
            {
                return NotFound();
            }

            var mapMarkers = await _context.MapMarkers
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (mapMarkers == null)
            {
                return NotFound();
            }

            return View(mapMarkers);
        }

        // GET: MapMarkers/Create
        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_context.AdminData, "AdminId", "AdminId");
            return View();
        }

        // POST: MapMarkers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MarkerId,Longitude,Latitude,MainLangauge,Dialect,AudioFile,Tag,AdminId")] MapMarkers mapMarkers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapMarkers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdminId"] = new SelectList(_context.AdminData, "AdminId", "AdminId", mapMarkers.AdminId);
            return View(mapMarkers);
        }

        // GET: MapMarkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MapMarkers == null)
            {
                return NotFound();
            }

            var mapMarkers = await _context.MapMarkers.FindAsync(id);
            if (mapMarkers == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.AdminData, "AdminId", "AdminId", mapMarkers.AdminId);
            return View(mapMarkers);
        }

        // POST: MapMarkers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarkerId,Longitude,Latitude,MainLangauge,Dialect,AudioFile,Tag,AdminId")] MapMarkers mapMarkers)
        {
            if (id != mapMarkers.MarkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapMarkers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapMarkersExists(mapMarkers.MarkerId))
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
            ViewData["AdminId"] = new SelectList(_context.AdminData, "AdminId", "AdminId", mapMarkers.AdminId);
            return View(mapMarkers);
        }

        // GET: MapMarkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MapMarkers == null)
            {
                return NotFound();
            }

            var mapMarkers = await _context.MapMarkers
                .Include(m => m.Admin)
                .FirstOrDefaultAsync(m => m.MarkerId == id);
            if (mapMarkers == null)
            {
                return NotFound();
            }

            return View(mapMarkers);
        }

        // POST: MapMarkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MapMarkers == null)
            {
                return Problem("Entity set 'hopeupermanDbContext.MapMarkers'  is null.");
            }
            var mapMarkers = await _context.MapMarkers.FindAsync(id);
            if (mapMarkers != null)
            {
                _context.MapMarkers.Remove(mapMarkers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapMarkersExists(int id)
        {
          return (_context.MapMarkers?.Any(e => e.MarkerId == id)).GetValueOrDefault();
        }
    }
}
