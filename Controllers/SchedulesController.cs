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
    public class SchedulesController : Controller
    {
        private readonly KitContext _context;

        public SchedulesController(KitContext context)
        {
            _context = context;
        }

        // GET: Schedules
        public async Task<IActionResult> Index()
        {
            var kitContext = _context.Schedules.Include(s => s.Groupstudent).Include(s => s.Lessons).Include(s => s.Timelessons).Include(s => s.Tutor);
            return View(await kitContext.ToListAsync());
        }

        // GET: Schedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Groupstudent)
                .Include(s => s.Lessons)
                .Include(s => s.Timelessons)
                .Include(s => s.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // GET: Schedules/Create
        public IActionResult Create()
        {
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id");
            ViewData["Lessonsid"] = new SelectList(_context.Lessons, "Id", "Id");
            ViewData["Timelessonsid"] = new SelectList(_context.Timelessons, "Id", "Id");
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Id");
            return View();
        }

        // POST: Schedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Groupstudentid,Datelessons,Timelessonsid,Tutorid,Lessonsid")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", schedule.Groupstudentid);
            ViewData["Lessonsid"] = new SelectList(_context.Lessons, "Id", "Id", schedule.Lessonsid);
            ViewData["Timelessonsid"] = new SelectList(_context.Timelessons, "Id", "Id", schedule.Timelessonsid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Id", schedule.Tutorid);
            return View(schedule);
        }

        // GET: Schedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", schedule.Groupstudentid);
            ViewData["Lessonsid"] = new SelectList(_context.Lessons, "Id", "Id", schedule.Lessonsid);
            ViewData["Timelessonsid"] = new SelectList(_context.Timelessons, "Id", "Id", schedule.Timelessonsid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Id", schedule.Tutorid);
            return View(schedule);
        }

        // POST: Schedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Groupstudentid,Datelessons,Timelessonsid,Tutorid,Lessonsid")] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheduleExists(schedule.Id))
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
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", schedule.Groupstudentid);
            ViewData["Lessonsid"] = new SelectList(_context.Lessons, "Id", "Id", schedule.Lessonsid);
            ViewData["Timelessonsid"] = new SelectList(_context.Timelessons, "Id", "Id", schedule.Timelessonsid);
            ViewData["Tutorid"] = new SelectList(_context.Tutors, "Id", "Id", schedule.Tutorid);
            return View(schedule);
        }

        // GET: Schedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules
                .Include(s => s.Groupstudent)
                .Include(s => s.Lessons)
                .Include(s => s.Timelessons)
                .Include(s => s.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }

            return View(schedule);
        }

        // POST: Schedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.Id == id);
        }
    }
}
