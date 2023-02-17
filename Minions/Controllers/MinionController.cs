using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Minions.Data;
using Minions.Models;

namespace Minions.Controllers
{
    public class MinionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Minions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Minion.ToListAsync());
        }

        // GET: Minions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Minion == null)
            {
                return NotFound();
            }

            var minion = await _context.Minion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minion == null)
            {
                return NotFound();
            }

            return View(minion);
        }

        // GET: Minions/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Minions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Minion minion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minion);
        }

        // GET: Minions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Minion == null)
            {
                return NotFound();
            }

            var minion = await _context.Minion.FindAsync(id);
            if (minion == null)
            {
                return NotFound();
            }
            return View(minion);
        }

        // POST: Minions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Minion minion)
        {
            if (id != minion.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinionExists(minion.ID))
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
            return View(minion);
        }

        // GET: Minions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Minion == null)
            {
                return NotFound();
            }

            var minion = await _context.Minion
                .FirstOrDefaultAsync(m => m.ID == id);
            if (minion == null)
            {
                return NotFound();
            }

            return View(minion);
        }

        // POST: Minions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Minion == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Minion'  is null.");
            }
            var minion = await _context.Minion.FindAsync(id);
            if (minion != null)
            {
                _context.Minion.Remove(minion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinionExists(int id)
        {
          return _context.Minion.Any(e => e.ID == id);
        }
    }
}
