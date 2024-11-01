﻿using System;
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
    public class JournalofdutiesController : Controller
    {
        private readonly KitContext _context;

        public JournalofdutiesController(KitContext context)
        {
            _context = context;
        }

        // GET: Journalofduties
        public async Task<IActionResult> Index()
        {
            var kitContext = _context.Journalofduties.Include(j => j.Groupstudent).Include(j => j.Student1).Include(j => j.Student2);
            return View(await kitContext.ToListAsync());
        }

        // GET: Journalofduties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalofduty = await _context.Journalofduties
                .Include(j => j.Groupstudent)
                .Include(j => j.Student1)
                .Include(j => j.Student2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalofduty == null)
            {
                return NotFound();
            }

            return View(journalofduty);
        }

        // GET: Journalofduties/Create
        public IActionResult Create()
        {
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id");
            ViewData["Student1id"] = new SelectList(_context.Students, "Id", "Id");
            ViewData["Student2id"] = new SelectList(_context.Students, "Id", "Id");
            return View();
        }

        // POST: Journalofduties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dateduty,Groupstudentid,Student1id,Student2id")] Journalofduty journalofduty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(journalofduty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", journalofduty.Groupstudentid);
            ViewData["Student1id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student1id);
            ViewData["Student2id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student2id);
            return View(journalofduty);
        }

        // GET: Journalofduties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalofduty = await _context.Journalofduties.FindAsync(id);
            if (journalofduty == null)
            {
                return NotFound();
            }
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", journalofduty.Groupstudentid);
            ViewData["Student1id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student1id);
            ViewData["Student2id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student2id);
            return View(journalofduty);
        }

        // POST: Journalofduties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dateduty,Groupstudentid,Student1id,Student2id")] Journalofduty journalofduty)
        {
            if (id != journalofduty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(journalofduty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalofdutyExists(journalofduty.Id))
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
            ViewData["Groupstudentid"] = new SelectList(_context.Groupstudents, "Id", "Id", journalofduty.Groupstudentid);
            ViewData["Student1id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student1id);
            ViewData["Student2id"] = new SelectList(_context.Students, "Id", "Id", journalofduty.Student2id);
            return View(journalofduty);
        }

        // GET: Journalofduties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalofduty = await _context.Journalofduties
                .Include(j => j.Groupstudent)
                .Include(j => j.Student1)
                .Include(j => j.Student2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (journalofduty == null)
            {
                return NotFound();
            }

            return View(journalofduty);
        }

        // POST: Journalofduties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var journalofduty = await _context.Journalofduties.FindAsync(id);
            if (journalofduty != null)
            {
                _context.Journalofduties.Remove(journalofduty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JournalofdutyExists(int id)
        {
            return _context.Journalofduties.Any(e => e.Id == id);
        }
    }
}
