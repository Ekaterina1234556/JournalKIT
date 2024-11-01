using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JournalKIT;

namespace JournalKIT.Controllers
{
    public class TegsController : Controller
    {
        private readonly KitContext _context;

        public TegsController(KitContext context)
        {
            _context = context;
        }

        // GET: Tegs
        public async Task<IActionResult> Index()
        {
            var kitContext = _context.Tegs.Include(t => t.Activity);
            return View(await kitContext.ToListAsync());
        }

        // GET: Tegs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teg = await _context.Tegs
                .Include(t => t.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teg == null)
            {
                return NotFound();
            }

            return View(teg);
        }

        // GET: Tegs/Create
        public IActionResult Create()
        {
            ViewData["Activityid"] = new SelectList(_context.Activities, "Id", "Id");
            return View();
        }

        // POST: Tegs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Activityid,Nameteg")] Teg teg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Activityid"] = new SelectList(_context.Activities, "Id", "Id", teg.Activityid);
            return View(teg);
        }

        // GET: Tegs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teg = await _context.Tegs.FindAsync(id);
            if (teg == null)
            {
                return NotFound();
            }
            ViewData["Activityid"] = new SelectList(_context.Activities, "Id", "Id", teg.Activityid);
            return View(teg);
        }

        // POST: Tegs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Activityid,Nameteg")] Teg teg)
        {
            if (id != teg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TegExists(teg.Id))
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
            ViewData["Activityid"] = new SelectList(_context.Activities, "Id", "Id", teg.Activityid);
            return View(teg);
        }

        // GET: Tegs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teg = await _context.Tegs
                .Include(t => t.Activity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teg == null)
            {
                return NotFound();
            }

            return View(teg);
        }

        // POST: Tegs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teg = await _context.Tegs.FindAsync(id);
            if (teg != null)
            {
                _context.Tegs.Remove(teg);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TegExists(int id)
        {
            return _context.Tegs.Any(e => e.Id == id);
        }
    }
}
