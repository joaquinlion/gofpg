using System;
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
    public class GlassTypesController : Controller
    {
        private readonly DataContext _context;

        public GlassTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: GlassTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Glasstypes.ToListAsync());
        }

        // GET: GlassTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glassType = await _context.Glasstypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glassType == null)
            {
                return NotFound();
            }

            return View(glassType);
        }

        // GET: GlassTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GlassTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] GlassType glassType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(glassType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(glassType);
        }

        // GET: GlassTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glassType = await _context.Glasstypes.FindAsync(id);
            if (glassType == null)
            {
                return NotFound();
            }
            return View(glassType);
        }

        // POST: GlassTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] GlassType glassType)
        {
            if (id != glassType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(glassType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlassTypeExists(glassType.Id))
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
            return View(glassType);
        }

        // GET: GlassTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var glassType = await _context.Glasstypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (glassType == null)
            {
                return NotFound();
            }

            return View(glassType);
        }

        // POST: GlassTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var glassType = await _context.Glasstypes.FindAsync(id);
            _context.Glasstypes.Remove(glassType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlassTypeExists(int id)
        {
            return _context.Glasstypes.Any(e => e.Id == id);
        }
    }
}
