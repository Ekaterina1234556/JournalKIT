using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalKIT;
using JournalKIT.Models;

namespace JournalKIT.Controllers
{
    public class BonusController : Controller
    {
        private readonly KitContext _context;

        public BonusController(KitContext context)
        {
            _context = context;
        }

        // GET: Bonus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bonus.ToListAsync());
        }

        // GET: Bonus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bonu == null)
            {
                return NotFound();
            }

            return View(bonu);
        }

        // GET: Bonus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bonus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namebonus,Property")] Bonu bonu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bonu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bonu);
        }

        // GET: Bonus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus.FindAsync(id);
            if (bonu == null)
            {
                return NotFound();
            }
            return View(bonu);
        }

        // POST: Bonus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namebonus,Property")] Bonu bonu)
        {
            if (id != bonu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bonu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonuExists(bonu.Id))
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
            return View(bonu);
        }

        // GET: Bonus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonu = await _context.Bonus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bonu == null)
            {
                return NotFound();
            }

            return View(bonu);
        }

        // POST: Bonus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bonu = await _context.Bonus.FindAsync(id);
            if (bonu != null)
            {
                _context.Bonus.Remove(bonu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BonuExists(int id)
        {
            return _context.Bonus.Any(e => e.Id == id);
        }
    }
}
