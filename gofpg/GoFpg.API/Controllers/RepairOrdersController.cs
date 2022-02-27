using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Models;
using GoFpg.API.Helpers;

namespace GoFpg.API.Controllers
{
    public class RepairOrdersController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public RepairOrdersController(DataContext context, IBlobHelper blobHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
        }

        // GET: RepairOrders
        public async Task<IActionResult> Index()
        {
            return View(await _context.RepairOrders
                .ToListAsync());
        }

        // GET: RepairOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // GET: RepairOrders/Create
        public IActionResult Create()
        {
            RepairOrderViewModel model = new RepairOrderViewModel
            {
                //DocumentTypes = _combosHelper.GetComboDocumentTypes()
            };
            return View(model);
        }

        // POST: RepairOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairOrderViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(repairOrder);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(repairOrder);

            if (ModelState.IsValid)
            {
                ImageIds imageIds = await UploadBlobs(model);
                //Guid invoiceImageId = Guid.Empty;
                //Guid policyImageId = Guid.Empty;

                ////if (model.PartImageFile  model.PolicyImageFile != null)
                //if (model?.PolicyImageFile != null)
                //{
                //    policyImageId = await _blobHelper.UploadBlobAsync(model.PolicyImageFile, "stories");
                //}
                //if (model?.PartImageFile != null)
                //{
                //    invoiceImageId = await _blobHelper.UploadBlobAsync(model.PartImageFile, "stories");
                //}

                //RepairOrder user = await _converterHelper.ToRepairOrderAsync(model, invoiceImageId, policyImageId, true);
                RepairOrder user =  _converterHelper.ToRepairOrderAsync(model, imageIds, true);
                _context.Add(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            //model.DocumentTypes = _combosHelper.GetComboDocumentTypes();
            return View(nameof(Index));
        }

        private async Task<ImageIds> UploadBlobs(RepairOrderViewModel model)
        {
            //TODO: subir el resto de las imagenes
            //TODO: subir todas las imagnees al mismo tiempo(lrivas)
            //TODO: debe soportar que se suban la mayoria de las fotos, aun si hay crash
            ImageIds ids = new ImageIds();
            if (model?.PolicyImageFile != null)
            {
                ids.PolicyImageId = await _blobHelper.UploadBlobAsync(model.PolicyImageFile, "stories");
            }
            if (model?.PartImageFile != null)
            {
                ids.InvoiceImageId = await _blobHelper.UploadBlobAsync(model.PartImageFile, "stories");
            }

            return ids;
        }
        // GET: RepairOrders/Edit/5
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
            return View(repairOrder);
        }

        // POST: RepairOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BillTo,PolicyNumber,HasReferral,ReferralNumber,PartNumber,ArePartsAvailable,HasApproval,InvoiceImageId,ScheduledDate,IsScheduled,InstallerName,Procedure,HasPictures,HasSignature,Mileage,InstallDate,IsInstalled,HasCalibration,CalibrationDone,Email,FirstName,LastName,Address,Address2,City,Zip,State,PhoneNumber,VinNumber,Year,Make,Model,Doors,BodyClass,VehicleType,LaneDeparture,LaneKeep,InsuranceCompany,DateOfLoss,BilledTo")] RepairOrder repairOrder)
        {
            if (id != repairOrder.Id)
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
                    if (!RepairOrderExists(repairOrder.Id))
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
            return View(repairOrder);
        }

        // GET: RepairOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var repairOrder = await _context.RepairOrders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // POST: RepairOrders/Delete/5
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
            return _context.RepairOrders.Any(e => e.Id == id);
        }
    }
}
