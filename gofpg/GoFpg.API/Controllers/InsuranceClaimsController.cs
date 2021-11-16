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
    public class InsuranceClaimsController : Controller
    {
        private readonly DataContext _context;

        public InsuranceClaimsController(DataContext context)
        {
            _context = context;
        }

        // GET: InsuranceClaims
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsuranceClaims.ToListAsync());
        }

        // GET: InsuranceClaims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceClaim = await _context.InsuranceClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return View(insuranceClaim);
        }

        // GET: InsuranceClaims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsuranceClaims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //VINImageId,DLImageId,InsCardImageId
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateOfLoss,Damage,ScheduleDate,InsuranceCo,PolicyNumber,")] InsuranceClaim insuranceClaim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insuranceClaim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insuranceClaim);
        }

        // GET: InsuranceClaims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceClaim = await _context.InsuranceClaims.FindAsync(id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }
            return View(insuranceClaim);
        }

        // POST: InsuranceClaims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateOfLoss,Damage,ScheduleDate,InsuranceCo,PolicyNumber,VINImageId,DLImageId,InsCardImageId")] InsuranceClaim insuranceClaim)
        {
            if (id != insuranceClaim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insuranceClaim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsuranceClaimExists(insuranceClaim.Id))
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
            return View(insuranceClaim);
        }

        // GET: InsuranceClaims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuranceClaim = await _context.InsuranceClaims
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insuranceClaim == null)
            {
                return NotFound();
            }

            return View(insuranceClaim);
        }

        // POST: InsuranceClaims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuranceClaim = await _context.InsuranceClaims.FindAsync(id);
            _context.InsuranceClaims.Remove(insuranceClaim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsuranceClaimExists(int id)
        {
            return _context.InsuranceClaims.Any(e => e.Id == id);
        }
    }
}
