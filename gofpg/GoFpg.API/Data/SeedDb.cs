using GoFpg.API.Data.Entities;
using GoFpg.API.Helpers;
using System;
using System.Collections.Generic;
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
            await CheckRolesAsync();
            await CheckUsersAsync ("Luis", "Salazar", "luis@mail.com", "311 322 4620", "Calle Sol", "Apt. 2", "33034", "Fl", UserType.Admin);
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
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "LDWS & LKA Calibration" });
                _context.Procedures.Add(new Procedure { Price = 10000, Description = "Windshield Replacement" });
                await _context.SaveChangesAsync();
            }
        }

        

        
    }
}

    

