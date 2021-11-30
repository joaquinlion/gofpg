using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using GoFpg.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GoFpg.API.Controllers
{
    public class NewClaimController : Controller
    {

        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IBlobHelper _blobHelper;

        public NewClaimController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper, IConverterHelper converterHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _blobHelper = blobHelper;
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

            InsuranceClaim insuranceClaim = await _context.InsuranceClaims

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewClaimViewModel newClaim)

        {
            if (ModelState.IsValid)
            {
                User user1 = await _userHelper.GetUserAsync(newClaim.Email);
                if (user1 == null)
                {
                    User user = await _converterHelper.ToMinUserAsync(newClaim, true);
                    user.UserType = UserType.User;
                    await _userHelper.AddUserAsync(user, "123456");
                    await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());
                    string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                    await _userHelper.ConfirmEmailAsync(user, token);
                }

                InsuranceClaim newro = await _converterHelper.ToMinInsuranceClaimAsync(newClaim, true);
                _context.Add(newro);
                await _context.SaveChangesAsync();
                //return if already exists
                return RedirectToAction(nameof(Details));
            }
            return View(newClaim);
        }


    }
}

