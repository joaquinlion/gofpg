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
    public class RepairOrders1Controller : Controller
    {
        private readonly DataContext _context;

        public RepairOrders1Controller(DataContext context)
        {
            _context = context;
        }

        // GET: RepairOrders1
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.RepairOrders.Include(r => r.Quote);
            return View(await dataContext.ToListAsync());
        }

        // GET: RepairOrders1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders
                .Include(r => r.Quote)
                .FirstOrDefaultAsync(m => m.RepairOrderId == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // GET: RepairOrders1/Create
        public IActionResult Create()
        {
            ViewData["RepairOrderId"] = new SelectList(_context.Quotes, "QuoteId", "Email");
            return View();
        }

        // POST: RepairOrders1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepairOrderId,BillTo,PolicyNumber,PolicyImageId,HasReferral,ReferralNumber,PartNumber,ArePartsAvailable,HasApproval,InvoiceImageId,ScheduledDate,IsScheduled,InstallerName,Procedure,TagImageId,DamageImageId,FullDamageImageId,VinImageId,InteriorImageId,HasPictures,HasSignature,Mileage,InstallDate,InstalledImageId,Installed2ImageId,IsInstalled,HasCalibration,ReportId,CalibrationDone,SignedROImageId")] RepairOrder repairOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RepairOrderId"] = new SelectList(_context.Quotes, "QuoteId", "Email", repairOrder.RepairOrderId);
            return View(repairOrder);
        }

        // GET: RepairOrders1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }
            ViewData["RepairOrderId"] = new SelectList(_context.Quotes, "QuoteId", "Email", repairOrder.RepairOrderId);
            return View(repairOrder);
        }

        // POST: RepairOrders1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepairOrderId,BillTo,PolicyNumber,PolicyImageId,HasReferral,ReferralNumber,PartNumber,ArePartsAvailable,HasApproval,InvoiceImageId,ScheduledDate,IsScheduled,InstallerName,Procedure,TagImageId,DamageImageId,FullDamageImageId,VinImageId,InteriorImageId,HasPictures,HasSignature,Mileage,InstallDate,InstalledImageId,Installed2ImageId,IsInstalled,HasCalibration,ReportId,CalibrationDone,SignedROImageId")] RepairOrder repairOrder)
        {
            if (id != repairOrder.RepairOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairOrderExists(repairOrder.RepairOrderId))
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
            ViewData["RepairOrderId"] = new SelectList(_context.Quotes, "QuoteId", "Email", repairOrder.RepairOrderId);
            return View(repairOrder);
        }

        // GET: RepairOrders1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders
                .Include(r => r.Quote)
                .FirstOrDefaultAsync(m => m.RepairOrderId == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // POST: RepairOrders1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var repairOrder = await _context.RepairOrders.FindAsync(id);
            _context.RepairOrders.Remove(repairOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairOrderExists(int id)
        {
            return _context.RepairOrders.Any(e => e.RepairOrderId == id);
        }
    }
}
