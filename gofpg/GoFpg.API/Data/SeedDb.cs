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
            await CheckVehiclesTypeAsync();
            await CheckBrandsAsync();
            await CheckDocumentTypesAsync();
            await CheckProceduresAsync();
            await CheckRolesAsync();
            await CheckUsersAsync ("1010", "Luis", "Salazar", "luis@mail.com", "311 322 4620", "Calle Sol", UserType.Admin);
            await CheckUsersAsync("1020", "Juan", "Zuluaga", "zulu@mail.com", "311 322 4620", "Calle Sol", UserType.User);
            await CheckUsersAsync("1030", "Joaquin", "Leon", "joaquin@mail.com", "311 322 4620", "Calle Sol", UserType.Sales);

        }

        private async Task CheckUsersAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    Address = address,
                    Document = document,
                    DocumentType = _context.DocumentTypes.FirstOrDefault(x => x.Description == "Cédula"),
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

        private async Task CheckDocumentTypesAsync()
        {
            if (!_context.DocumentTypes.Any())
            {
                _context.DocumentTypes.Add(new DocumentType { Description = "Drivers License" });
                _context.DocumentTypes.Add(new DocumentType { Description = "Passport" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckBrandsAsync()
        {
            if (!_context.Brands.Any())
            {               
                _context.Brands.Add(new Brand { Description = "Toyota" });
                _context.Brands.Add(new Brand { Description = "Lexus" });
                _context.Brands.Add(new Brand { Description = "Ford" });
                _context.Brands.Add(new Brand { Description = "Dodge" });
                _context.Brands.Add(new Brand { Description = "Jeep" });
                _context.Brands.Add(new Brand { Description = "Hyundai" });
                _context.Brands.Add(new Brand { Description = "Kia" });
                _context.Brands.Add(new Brand { Description = "Honda" });
                _context.Brands.Add(new Brand { Description = "Acura" });
                _context.Brands.Add(new Brand { Description = "Nissan" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckVehiclesTypeAsync()
        {
            if (!_context.VehicleTypes.Any())
            {
                _context.VehicleTypes.Add(new VehicleType { Description = "4 Door Sedan" });
                _context.VehicleTypes.Add(new VehicleType { Description = "4 Door SUV" });
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door SUV" });
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door Hatchback" });
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door Coupe" });
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door Convertible" });
                _context.VehicleTypes.Add(new VehicleType { Description = "4 Door Hatchback" });
                _context.VehicleTypes.Add(new VehicleType { Description = "4 Door Crew Cab" });
                
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door Standard Cab" });
                _context.VehicleTypes.Add(new VehicleType { Description = "2 Door Extended Cab" });
                await _context.SaveChangesAsync();
            }
        }
    }
}

    

