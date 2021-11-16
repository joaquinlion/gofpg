using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Models;
using System;
using System.Threading.Tasks;
using System.Globalization;

namespace GoFpg.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public async Task<Detail> ToDetailAsync(DetailViewModel model, bool isNew)
        {
            return new Detail
            {
                Id = isNew ? 0 : model.Id,
                History = await _context.Histories.FindAsync(model.HistoryId),
                LaborPrice = model.LaborPrice,
                Procedure = await _context.Procedures.FindAsync(model.ProcedureId),
                Remarks = model.Remarks,
                SparePartsPrice = model.SparePartsPrice
            };
        }

        public DetailViewModel ToDetailViewModel(Detail detail)
        {
            return new DetailViewModel
            {
                HistoryId = detail.History.Id,
                Id = detail.Id,
                LaborPrice = detail.LaborPrice,
                ProcedureId = detail.Procedure.Id,
                Procedures = _combosHelper.GetComboProcedures(),
                Remarks = detail.Remarks,
                SparePartsPrice = detail.SparePartsPrice
            };
        }

        //public async Task<InsuranceClaim> ToMinInsuranceClaimAsync(NewClaimViewModel newClaimViewModel, bool isNew)
        //{
        //    return new InsuranceClaim
        //    {
        //        DateOfLoss = newClaimViewModel.DateOfLoss,
        //        Damage = newClaimViewModel.Damage,
        //        ScheduleDate = newClaimViewModel.ScheduleDate,
        //        Id = isNew ? 0 : newClaimViewModel.Id,

        //    };
        //}

        //public async Task<User> ToMinUserAsync(NewClaimViewModel newClaimViewModel, bool isNew)
        //{
        //    return new User
        //    {
        //        Address = newClaimViewModel.Address,
        //        Email = newClaimViewModel.Email,
        //        FirstName = newClaimViewModel.FirstName,
        //        Id = newClaimViewModel.Id,
        //        LastName = newClaimViewModel.LastName,
        //        PhoneNumber = newClaimViewModel.PhoneNumber,
        //        UserName = newClaimViewModel.Email,
        //        UserType = UserType.User,
        //    };
        //}

        //public async Task<Vehicle> ToMinVehicleAsync(NewClaimViewModel newClaimViewModel, bool isNew)
        //{
        //    return new Vehicle
        //    {
        //        //Id = isNew ? Guid.NewGuid() : newClaimViewModel.Id,
        //        VinNumber = newClaimViewModel.VinNumber.ToUpper(),
        //    };
        //}

        public NewClaimViewModel ToNewClaimViewModel(InsuranceClaim insuranceClaim, User user)
        {
            return new NewClaimViewModel
            {
                Id = insuranceClaim.Id,
                DateOfLoss = insuranceClaim.DateOfLoss,
                Damage = insuranceClaim.Damage,
                ScheduleDate = insuranceClaim.ScheduleDate,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                InsuranceCo = insuranceClaim.InsuranceCo,
                PolicyNumber = insuranceClaim.PolicyNumber,
            };
        }

        public async Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew)
        {
            return new User
            {
                Address = model.Address,
                Document = model.Document,
                DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                Id = model.Id,
                ImageId = imageId,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                UserName = model.Email,
                UserType = model.UserType,
            };
        }

        public UserViewModel ToUserViewModel(User user)
        {
            return new UserViewModel
            {
                Address = user.Address,
                Document = user.Document,
                //DocumentTypeId = user.DocumentType.Id,
                DocumentTypes = _combosHelper.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                ImageId = user.ImageId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }

        public async Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew)
        {
            return new Vehicle
            {
                Brand = await _context.Brands.FindAsync(model.BrandId),
                Color = model.Color,
                Id = isNew ? 0 : model.Id,
                VinNumber = model.VinNumber.ToUpper(),
                Line = model.Line,
                Model = model.Model,
                Plaque = model.Plaque.ToUpper(),
                Remarks = model.Remarks,
                VehicleType = await _context.VehicleTypes.FindAsync(model.VehicleTypeId)
            };
        }

        public VehicleViewModel ToVehicleViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                BrandId = vehicle.Brand.Id,
                Brands = _combosHelper.GetComboBrands(),
                Color = vehicle.Color,
                Id = vehicle.Id,
                VinNumber = vehicle.VinNumber.ToUpper(),
                Line = vehicle.Line,
                Model = vehicle.Model,
                Plaque = vehicle.Plaque.ToUpper(),
                Remarks = vehicle.Remarks,
                UserId = vehicle.User.Id,
                VehiclePhotos = vehicle.VehiclePhotos,
                VehicleTypeId = vehicle.VehicleType.Id,
                VehicleTypes = _combosHelper.GetComboVehicleTypes()
            };
        }
    }
}
