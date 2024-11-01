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
    public class TimelessonsController : Controller
    {
        private readonly KitContext _context;

        public TimelessonsController(KitContext context)
        {
            _context = context;
        }

        // GET: Timelessons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Timelessons.ToListAsync());
        }

        // GET: Timelessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timelesson = await _context.Timelessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timelesson == null)
            {
                return NotFound();
            }

            return View(timelesson);
        }

        // GET: Timelessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Timelessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numberlessons,Startlessons,Endlessons")] Timelesson timelesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timelesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timelesson);
        }

        // GET: Timelessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timelesson = await _context.Timelessons.FindAsync(id);
            if (timelesson == null)
            {
                return NotFound();
            }
            return View(timelesson);
        }

        // POST: Timelessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numberlessons,Startlessons,Endlessons")] Timelesson timelesson)
        {
            if (id != timelesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timelesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimelessonExists(timelesson.Id))
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
            return View(timelesson);
        }

        // GET: Timelessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timelesson = await _context.Timelessons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timelesson == null)
            {
                return NotFound();
            }

            return View(timelesson);
        }

        // POST: Timelessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timelesson = await _context.Timelessons.FindAsync(id);
            if (timelesson != null)
            {
                _context.Timelessons.Remove(timelesson);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimelessonExists(int id)
        {
            return _context.Timelessons.Any(e => e.Id == id);
        }
    }
}
