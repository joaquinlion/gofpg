using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using GoFpg.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

            RepairOrder repairOrder = await _context.RepairOrders
                .FirstOrDefaultAsync(m => m.RepairOrderId == id);
            if (repairOrder == null)
            {
                return NotFound();
            }

            return View(repairOrder);
        }

        // GET: RepairOrders/Create
        public IActionResult Create() 
        {
            RepairOrderViewModel model = new RepairOrderViewModel();

            return View(model);
        }

        // POST: RepairOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RepairOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                //ImageIds imageIds = await UploadBlobs(model);
                Guid invoiceImageId = Guid.Empty;
                Guid policyImageId = Guid.Empty;

                //if (model.PartImageFile  model.PolicyImageFile != null)
                if (model?.PolicyImageFile != null)
                {
                    policyImageId = await _blobHelper.UploadBlobAsync(model.PolicyImageFile, "stories");
                }
                if (model?.PartImageFile != null)
                {
                    invoiceImageId = await _blobHelper.UploadBlobAsync(model.PartImageFile, "stories");
                }

                RepairOrder rOrder = await _converterHelper.ToRepairOrderAsync(model, invoiceImageId, policyImageId, true);
                //RepairOrder rOrder = _converterHelper.ToRepairOrderAsync(model, imageIds, true);
                _context.Add(rOrder);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }

        private async Task<ImageIds> UploadBlobs(RepairOrderViewModel model)
        {
            //TODO: subir el resto de las imagenes
            //TODO: subir todas las imagnees al mismo tiempo(lrivas)
            //TODO: debe soportar que se suban la mayoria de las fotos, aun si hay crash
            ImageIds ids = new();
            if (model?.PolicyImageFile != null)
            {
                ids.PolicyImageId = await _blobHelper.UploadBlobAsync(model.PolicyImageFile, "stories");
            }
            if (model?.PartImageFile != null)
            {
                ids.InvoiceImageId = await _blobHelper.UploadBlobAsync(model.PartImageFile, "stories");
            }
            if (model?.TagImageFile != null)
            {
                ids.TagImageId = await _blobHelper.UploadBlobAsync(model.TagImageFile, "stories");
            }
            if (model?.VinImageFile != null)
            {
                ids.VinImageId = await _blobHelper.UploadBlobAsync(model.VinImageFile, "stories");
            }
            if (model?.DamageImageFile != null)
            {
                ids.DamageImageId = await _blobHelper.UploadBlobAsync(model.DamageImageFile, "stories");
            }
            if (model?.FullGlassImageFile != null)
            {
                ids.FullDamageImageId = await _blobHelper.UploadBlobAsync(model.FullGlassImageFile, "stories");
            }
            if (model?.InteriorImageFile != null)
            {
                ids.InteriorImageId = await _blobHelper.UploadBlobAsync(model.InteriorImageFile, "stories");
            }
            if (model?.InstalledImageFile != null)
            {
                ids.InstalledImageId = await _blobHelper.UploadBlobAsync(model.InstalledImageFile, "stories");
            }
            if (model?.Installed2ImageFile != null)
            {
                ids.Installed2ImageId = await _blobHelper.UploadBlobAsync(model.Installed2ImageFile, "stories");
            }
            if (model?.ReportFile != null)
            {
                ids.ReportId = await _blobHelper.UploadBlobAsync(model.ReportFile, "stories");
            }
            if (model?.SignedROFile != null)
            {
                ids.SignedROImageId = await _blobHelper.UploadBlobAsync(model.SignedROFile, "stories");
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

            RepairOrder repairOrder = await _context.RepairOrders.FindAsync(id);
            if (repairOrder == null)
            {
                return NotFound();
            }
            return View(repairOrder);
        }

        // POST: RepairOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BillTo,PolicyNumber,HasReferral,ReferralNumber,PartNumber,ArePartsAvailable,HasApproval,InvoiceImageId,ScheduledDate,IsScheduled,InstallerName,Procedure,HasPictures,HasSignature,Mileage,InstallDate,IsInstalled,HasCalibration,CalibrationDone,Email,FirstName,LastName,Address,Address2,City,Zip,State,PhoneNumber,VinNumber,Year,Make,Model,Doors,BodyClass,VehicleType,LaneDeparture,LaneKeep,InsuranceCompany,DateOfLoss,BilledTo")] RepairOrder repairOrder)
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
            return View(repairOrder);
        }

        // GET: RepairOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RepairOrder repairOrder = await _context.RepairOrders
                .FirstOrDefaultAsync(m => m.RepairOrderId == id);
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
            RepairOrder repairOrder = await _context.RepairOrders.FindAsync(id);
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
