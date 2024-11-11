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
    public class GroupstudentsController : Controller
    {
        private readonly KitContext _context;

        public GroupstudentsController(KitContext context)
        {
            _context = context;
        }

        // GET: Groupstudents
        public async Task<IActionResult> Index()
        {
            var kitContext = _context.Groupstudents.Include(g => g.Specialty).Include(g => g.Tutor);
            return View(await kitContext.ToListAsync());
        }

        // GET: Groupstudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupstudent = await _context.Groupstudents
                .Include(g => g.Specialty)
                .Include(g => g.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupstudent == null)
            {
                return NotFound();
            }

            return View(groupstudent);
        }

        // GET: Groupstudents/Create
        public IActionResult Create()
        {
            ViewData["Specialtyid"] = new SelectList(_context.Specialties, "Id", "Namespecialty");
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Nametutor");
            return View();
        }

        // POST: Groupstudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Namegroup,Creategroup,Tutorid,Specialtyid")] Groupstudent groupstudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupstudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Specialtyid"] = new SelectList(_context.Specialties, "Id", "Namespecialty", groupstudent.Specialtyid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Nametutor", groupstudent.Tutorid);
            return View(groupstudent);
        }

        // GET: Groupstudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupstudent = await _context.Groupstudents.FindAsync(id);
            if (groupstudent == null)
            {
                return NotFound();
            }
            ViewData["Specialtyid"] = new SelectList(_context.Specialties, "Id", "Namespecialty", groupstudent.Specialtyid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Nametutor", groupstudent.Tutorid);
            return View(groupstudent);
        }

        // POST: Groupstudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Namegroup,Creategroup,Tutorid,Specialtyid")] Groupstudent groupstudent)
        {
            if (id != groupstudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupstudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupstudentExists(groupstudent.Id))
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
            ViewData["Specialtyid"] = new SelectList(_context.Specialties, "Id", "Namespecialty", groupstudent.Specialtyid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Nametutor", groupstudent.Tutorid);
            return View(groupstudent);
        }

        // GET: Groupstudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupstudent = await _context.Groupstudents
                .Include(g => g.Specialty)
                .Include(g => g.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groupstudent == null)
            {
                return NotFound();
            }

            return View(groupstudent);
        }

        // POST: Groupstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupstudent = await _context.Groupstudents.FindAsync(id);
            if (groupstudent != null)
            {
                _context.Groupstudents.Remove(groupstudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupstudentExists(int id)
        {
            return _context.Groupstudents.Any(e => e.Id == id);
        }
    }
}
