﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFpg.API.Data;
using GoFpg.API.Data.Entities;

namespace GoFpg.API.Controllers
{
    public class PartsController : Controller
    {
        private readonly DataContext _context;

        public PartsController(DataContext context)
        {
            _context = context;
        }

        // GET: Parts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parts.ToListAsync());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PartNo,PartDescription,Price")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PartNo,PartDescription,Price")] Part part)
        {
            if (id != part.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartExists(part.Id))
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
            return View(part);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.Parts.FindAsync(id);
            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.Parts.Any(e => e.Id == id);
        }
    }
}
