using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GoFpg.API.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            await CheckProceduresAsync();
            await CheckGlassTypesAsync();
            await CheckPartsAsync();
            await CheckRolesAsync();
            await CheckUsersAsync("Luis", "Salazar", "luis@mail.com", "311 322 4620", "Calle Sol", "Apt. 2", "33034", "Fl", UserType.Admin);
            await CheckUsersAsync("Juan", "Zuluaga", "zulu@mail.com", "311 322 4620", "Calle Sol", "Apt. 2", "33034", "Fl", UserType.User);
            await CheckUsersAsync("Joaquin", "Leon", "joaquin@mail.com", "311 322 4620", "Calle Sol", "Apt. 2", "33034", "Fl", UserType.Sales);

        }

        

        private async Task CheckUsersAsync(string firstName, string lastName, string email, string phoneNumber, string address, string address2, string zip, string state, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Address2 = address2,
                    Zip = zip,
                    State = state,
                    //Document = document,

                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    UserType = userType
                };
                await _userHelper.AddUserAsync(user, "123456");

                await _userHelper.AddUserToRoleAsync(user, UserType.Admin.ToString());

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);


            }
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Sales.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { Price = 350, ProcedureCode = "LDI", Description = "LDWS & LKA Calibration" });
                _context.Procedures.Add(new Procedure { Price = 40, ProcedureCode = "WRI", Description = "Windshield Replacement" });
                _context.Procedures.Add(new Procedure { Price = 150, ProcedureCode = "LDC", Description = "LDWS & LKA Calibration C" });
                _context.Procedures.Add(new Procedure { Price = 125, ProcedureCode = "WRC", Description = "Windshield Replacement C" });
                _context.Procedures.Add(new Procedure { Price = 125, ProcedureCode = "BRC", Description = "Back Glass Replacement" });
                _context.Procedures.Add(new Procedure { Price = 125, ProcedureCode = "DRC", Description = "Door Window Replacement" });
                _context.Procedures.Add(new Procedure { Price = 125, ProcedureCode = "QRC", Description = "Quarter Window Replacement" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckGlassTypesAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.GlassTypes.Add(new GlassType { Description = "Windshield" });
                _context.GlassTypes.Add(new GlassType { Description = "Back Glass" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckPartsAsync()
        {
            if (!_context.Parts.Any())
            {
                _context.Parts.Add(new Part { Price = 15, PartNo = "WSK", PartDescription = "Windshield Urethane Adhesive" });
                _context.Parts.Add(new Part { Price = 20, PartNo = "HMK", PartDescription = "High Modulus Urethane Adhesive" });
                _context.Parts.Add(new Part { Price = 15, PartNo = "FCK", PartDescription = "Fast Cure Urethane Adhesive" });
                await _context.SaveChangesAsync();
            }
        }



    }
}



