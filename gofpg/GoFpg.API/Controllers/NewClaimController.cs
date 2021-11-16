using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using GoFpg.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task Create()
        //{
        //    await CreateUserAsync();
        //    await CreateJobAsync();
        //}

        //private async Task<IActionResult> CreateUserAsync([Bind("Email,FirstName,LastName,PhoneNumber,Address")] NewClaimViewModel newClaim)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user1 = await _userHelper.GetUserAsync(newClaim.Email);
        //        if (user1 == null)
        //        {
        //            User user = await _converterHelper.ToMinUserAsync(newClaim, true);  
        //            user.UserType = UserType.User;
        //            await _userHelper.AddUserAsync(user, "123456");
        //            await _userHelper.AddUserToRoleAsync(user, user.UserType.ToString());
        //            string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
        //            await _userHelper.ConfirmEmailAsync(user, token);      
        //        }
        //        //return if already exists
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(newClaim);
        //}

        //private async Task<IActionResult> CreateJobAsync([Bind("Id,DateOfLoss,Damage,ScheduleDate,InsuranceCo,PolicyNumber,")] NewClaimViewModel newClaim)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(newClaim);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(newClaim);
        //}




        /// crear work order
        //post para crear claim
        //post para crear vehiculo
        //post para crear usuario
        /// firma y acepta work order
        //enviar correo acepta claim & confirma correo
        //firma claim
        //enviar correo usuario creado

        /// editar workorder e informacion del trabajo
        //post para subir fotos
        //editar claim
        //editar vehiculo
        //editar usuario
        //editar informacion de instalacion(invoice, instalador, schedule, address)


        //fotos instalador
        //factura instalador

        //reporte calibracion
        //factura calibracion
        //fotos calibracion
    }
}

