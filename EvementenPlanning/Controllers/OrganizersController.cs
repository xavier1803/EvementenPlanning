﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvementenPlanning.Models;
using EvementenPlanning.Models.Classes;

namespace EvementenPlanning.Controllers
{
    public class OrganizersController : Controller
    {
        private readonly EventplanningContext _context;

        public OrganizersController(EventplanningContext context)
        {
            _context = context;
        }

        // GET: Organizers
        public async Task<IActionResult> Index()
        {
              return _context.Organizers != null ? 
                          View(await _context.Organizers.ToListAsync()) :
                          Problem("Entity set 'EventplanningContext.Organizers'  is null.");
        }

        // GET: Organizers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Organizers == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // GET: Organizers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,OrganizationIndustry")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Organizers == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer == null)
            {
                return NotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,OrganizationIndustry")] Organizer organizer)
        {
            if (id != organizer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizerExists(organizer.Id))
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
            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Organizers == null)
            {
                return NotFound();
            }

            var organizer = await _context.Organizers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizer == null)
            {
                return NotFound();
            }

            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Organizers == null)
            {
                return Problem("Entity set 'EventplanningContext.Organizers'  is null.");
            }
            var organizer = await _context.Organizers.FindAsync(id);
            if (organizer != null)
            {
                _context.Organizers.Remove(organizer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizerExists(int id)
        {
          return (_context.Organizers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
