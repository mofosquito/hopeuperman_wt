using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Data;
using Data.Models;

namespace hopeuperman_adminPanel.Controllers
{
    public class AdminDatasController : Controller
    {
        private readonly hopeupermanDbContext _context;

        public AdminDatasController(hopeupermanDbContext context)
        {
            _context = context;
        }

        // GET: AdminDatas
        public async Task<IActionResult> Index()
        {
              return _context.AdminData != null ? 
                          View(await _context.AdminData.ToListAsync()) :
                          Problem("Entity set 'hopeupermanDbContext.AdminData'  is null.");
        }

        // GET: AdminDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminData == null)
            {
                return NotFound();
            }

            var adminData = await _context.AdminData
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminData == null)
            {
                return NotFound();
            }

            return View(adminData);
        }

        // GET: AdminDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdminId,AdminUsername,AdminPassword,AdminEmail")] AdminData adminData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminData);
        }

        // GET: AdminDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminData == null)
            {
                return NotFound();
            }

            var adminData = await _context.AdminData.FindAsync(id);
            if (adminData == null)
            {
                return NotFound();
            }
            return View(adminData);
        }

        // POST: AdminDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdminId,AdminUsername,AdminPassword,AdminEmail")] AdminData adminData)
        {
            if (id != adminData.AdminId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminDataExists(adminData.AdminId))
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
            return View(adminData);
        }

        // GET: AdminDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminData == null)
            {
                return NotFound();
            }

            var adminData = await _context.AdminData
                .FirstOrDefaultAsync(m => m.AdminId == id);
            if (adminData == null)
            {
                return NotFound();
            }

            return View(adminData);
        }

        // POST: AdminDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminData == null)
            {
                return Problem("Entity set 'hopeupermanDbContext.AdminData'  is null.");
            }
            var adminData = await _context.AdminData.FindAsync(id);
            if (adminData != null)
            {
                _context.AdminData.Remove(adminData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminDataExists(int id)
        {
          return (_context.AdminData?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
