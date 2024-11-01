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
    public class BonusstudentsController : Controller
    {
        private readonly KitContext _context;

        public BonusstudentsController(KitContext context)
        {
            _context = context;
        }

        // GET: Bonusstudents
        public async Task<IActionResult> Index()
        {
            var kitContext = _context.Bonusstudents.Include(b => b.Bonus).Include(b => b.Student);
            return View(await kitContext.ToListAsync());
        }

        // GET: Bonusstudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonusstudent = await _context.Bonusstudents
                .Include(b => b.Bonus)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bonusstudent == null)
            {
                return NotFound();
            }

            return View(bonusstudent);
        }

        // GET: Bonusstudents/Create
        public IActionResult Create()
        {
            ViewData["Bonusid"] = new SelectList(_context.Bonus, "Id", "Id");
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Bonusstudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Studentid,Bonusid")] Bonusstudent bonusstudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bonusstudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Bonusid"] = new SelectList(_context.Bonus, "Id", "Id", bonusstudent.Bonusid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", bonusstudent.Studentid);
            return View(bonusstudent);
        }

        // GET: Bonusstudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonusstudent = await _context.Bonusstudents.FindAsync(id);
            if (bonusstudent == null)
            {
                return NotFound();
            }
            ViewData["Bonusid"] = new SelectList(_context.Bonus, "Id", "Id", bonusstudent.Bonusid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", bonusstudent.Studentid);
            return View(bonusstudent);
        }

        // POST: Bonusstudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Studentid,Bonusid")] Bonusstudent bonusstudent)
        {
            if (id != bonusstudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bonusstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonusstudentExists(bonusstudent.Id))
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
            ViewData["Bonusid"] = new SelectList(_context.Bonus, "Id", "Id", bonusstudent.Bonusid);
            ViewData["Studentid"] = new SelectList(_context.Students, "Id", "Id", bonusstudent.Studentid);
            return View(bonusstudent);
        }

        // GET: Bonusstudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bonusstudent = await _context.Bonusstudents
                .Include(b => b.Bonus)
                .Include(b => b.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bonusstudent == null)
            {
                return NotFound();
            }

            return View(bonusstudent);
        }

        // POST: Bonusstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bonusstudent = await _context.Bonusstudents.FindAsync(id);
            if (bonusstudent != null)
            {
                _context.Bonusstudents.Remove(bonusstudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BonusstudentExists(int id)
        {
            return _context.Bonusstudents.Any(e => e.Id == id);
        }
    }
}
