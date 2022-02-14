using gofpg.Common.Models;
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
    public class QuotesController : Controller
    {
        private readonly DataContext _context;
        private readonly IBlobHelper _blobHelper;
        private readonly IMailHelper _mailHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;

        public QuotesController(DataContext context, IBlobHelper blobHelper, IMailHelper mailHelper, ICombosHelper combosHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _blobHelper = blobHelper;
            _mailHelper = mailHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
        }

        // GET: Quotes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quotes
                .Include(x => x.GlassType)
                .ToListAsync());
        }

        // GET: Quotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // GET: Quotes/Create
        public IActionResult Create()
        {

            DetailedQuoteViewModel quote = new DetailedQuoteViewModel
            {
                GlassTypes = _combosHelper.GetComboGlassTypes()
                
            };
            return View(quote);
        }

        // POST: Quotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,FirstName,LastName,Address,Address2,City,Zip,State,PhoneNumber,VinNumber,Year,Make,Model,Doors,BodyClass,VehicleType,LaneDeparture,LaneKeep,GlassTypeId,GlassTypes,InsuranceCompany,DateOfLoss,BilledTo")] DetailedQuoteViewModel quote)
        {
            if (ModelState.IsValid)
            {
                Quote quotef = await _converterHelper.ToQuoteAsync(quote);

                //return RedirectToAction(nameof(Index));
                string fName = quotef.FirstName;
                string lName = quotef.LastName;
                string phoneNum = quotef.PhoneNumber;
                string saddress = quotef.Address;
                string aaddress = quotef.Address2;
                string city = quotef.City;
                string state = quotef.State;
                string zip = quotef.Zip;
                string vin = quotef.VinNumber.ToUpper();
                int year = quotef.Year;
                string make = quotef.Make;
                string model = quotef.Model;
                string door = quotef.Doors;
                string vehtyp = quotef.BodyClass;
                string ldws = quotef.LaneDeparture;
                string lka = quotef.LaneKeep;
                string insco = quotef.InsuranceCompany;
                string glass = quotef.GlassType.Description.ToString();
                DateTime dol = quotef.DateOfLoss;
                _context.Add(quotef);
                await _context.SaveChangesAsync();

                ////TODO
                //if (insco == "Geico")
                //{
                //    return RedirectToAction("Privacy", "Home");
                //}

                Response response = _mailHelper.SendMail("service@gofpg.com", "Quote Request", null,
                        $"{glass + " " + insco + " " + year + " " + ldws + lka}" + "<br />" +
                        $"Name: {fName + " " + lName}" + "<br />" +
                        $"Phone: {phoneNum}" + "<br />" +
                        $"{saddress + " " + aaddress + " " + city + " " + state + " " + zip}" + "<br />" +
                        $"VIN: {vin}" + "<br />" +
                        $"{year + " " + make + " " + model + " " + door + " doors " + vehtyp}" + "<br />" +
                        $"DOL: {dol:MM/dd/yyyy}");
                if (response.IsSuccess)
                {
                    ViewBag.Message = "A has been sent to the email address provided for account confirmation.";
                    
                    Response mensajito = _mailHelper.SendMail("7542096532@tmomail.net", $"{insco}" + "\r\n",
                        $"{glass + " " + year}" + "\r\n" +
                        $"{ldws + lka}" + "\r\n" +
                        $"{saddress + " " + aaddress + " " + city + " " + state + " " + zip}" + "\r\n" +
                        $"{phoneNum}" + "\r\n" +
                        $"{fName + " " + lName}" + "\r\n" +
                        $"{vin}" + "\r\n" +
                        $"{year + " " + make + " " + model}", null);
                    if (mensajito.IsSuccess)
                    {
                        ViewBag.Message = "A has been sent to the email address provided for account confirmation.";
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, mensajito.Message);
                }
                ModelState.AddModelError(string.Empty, response.Message);

                //Response responsec = _mailHelper.SendMail(quote.Email, "Florida Prime Glass - Quote Request Confirmation", 
                //        $"<h1>Florida Prime Glass - Quote Request Confirmation</h1>" +
                //        $"Para habilitar el usuario, " +
                //        $"por favor hacer clic en el siguiente enlace: </br></br><a href = \"\">Confirmar Email</a>");
                //if (responsec.IsSuccess)
                //{
                //    ViewBag.Message = "A has been sent to the email address provided for account confirmation.";
                //    return View(quote);
                //}
                //ModelState.AddModelError(string.Empty, responsec.Message);
            }
            quote.GlassTypes = _combosHelper.GetComboGlassTypes();
            return View(quote);
        }

        // GET: Quotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote quote = await _context.Quotes.FindAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,FirstName,LastName,Address,Address2,City,Zip,State,PhoneNumber,VinNumber,Year,Make,Model,Doors,BodyClass,VehicleType,LaneDeparture,LaneKeep,GlassType,InsuranceCompany,DateOfLoss,BilledTo")] Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuoteExists(quote.Id))
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
            return View(quote);
        }

        // GET: Quotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote quote = await _context.Quotes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Quote quote = await _context.Quotes.FindAsync(id);
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return _context.Quotes.Any(e => e.Id == id);
        }

        public IActionResult QuickQuote()
        {
            Quote model = new Quote();
            //{
            //    DocumentTypes = _combosHelper.GetComboDocumentTypes()
            //};

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuickQuote([Bind("FirstName,PhoneNumber")] Quote quote)
        {
            string fName = quote.FirstName;
            string phoneNum = quote.PhoneNumber;

            Response response = _mailHelper.SendMail("7542096532@tmomail.net", "Call Quote",
                    $"\r\n" +
                    $"{phoneNum}" + "\r\n" +
                    $"{fName}", null);

            if (response.IsSuccess)
            {
                ViewBag.Message = "A has been sent to the email address provided for account confirmation.";
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, response.Message);

            return RedirectToAction("Index", "Home");
        }

    }
}
