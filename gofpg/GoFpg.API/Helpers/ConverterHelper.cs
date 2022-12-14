using GoFpg.API.Data;
using GoFpg.API.Data.Entities;
using GoFpg.API.Models;
using System;
using System.Threading.Tasks;

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

        public async Task<InsuranceClaim> ToMinInsuranceClaimAsync(NewClaimViewModel newClaimViewModel, bool isNew)
        {
            return new InsuranceClaim
            {
                Id = isNew ? 0 : newClaimViewModel.Id,
                RODate = newClaimViewModel.RODate,
                DateOfLoss = newClaimViewModel.DateOfLoss,
                Damage = newClaimViewModel.Damage,
                Repair = newClaimViewModel.Repair,
                ScheduleDate = newClaimViewModel.ScheduleDate,
                //scheduletime
                InsuranceCo = newClaimViewModel.InsuranceCo,
                PolicyNumber = newClaimViewModel.PolicyNumber,
                ReferralNumber = newClaimViewModel.ReferralNumber,
                AltContactName = newClaimViewModel.AltContactName,
                AltPhoneNumber = newClaimViewModel.AltPhoneNumber,
                VinNumber = newClaimViewModel.VinNumber,
                Tag = newClaimViewModel.Tag,
                Mileage = newClaimViewModel.Mileage,
            };
        }

        public async Task<User> ToMinUserAsync(NewClaimViewModel newClaimViewModel, bool isNew)
        {
            return new User
            {
                Id = newClaimViewModel.Id,
                Email = newClaimViewModel.Email,
                FirstName = newClaimViewModel.FirstName,
                LastName = newClaimViewModel.LastName,
                PhoneNumber = newClaimViewModel.PhoneNumber,
                Address = newClaimViewModel.Address,
                Address2 = newClaimViewModel.Address2,
                City = newClaimViewModel.City,
                State = newClaimViewModel.State,
                Zip = newClaimViewModel.Zip,
                UserName = newClaimViewModel.Email,
                UserType = UserType.User,
            };
        }

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
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                //Document = model.Document,
                //DocumentType = await _context.DocumentTypes.FindAsync(model.DocumentTypeId),
                Email = model.Email,
                FirstName = model.FirstName,
                Id = isNew ? 0 : model.Id,
                //Id = model.Id,
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
                Address2 = user.Address2,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                //Document = user.Document,
                //DocumentTypeId = user.DocumentType.Id,
                //DocumentTypes = _combosHelper.GetComboDocumentTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                ImageId = user.ImageId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserType = user.UserType,
            };
        }

        public async Task<Quote> ToQuoteAsync(DetailedQuoteViewModel model)
        {
            return new Quote
            {
                Address = model.Address,
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Email = model.Email,
                FirstName = model.FirstName,
                QuoteId = model.Id,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                VinNumber = model.VinNumber.ToUpper(),
                Year = model.Year,
                Make = model.Make,
                Model = model.Model,
                Doors = model.Doors,
                VehicleType = model.VehicleType,
                LaneDeparture = model.LaneDeparture,
                LaneKeep = model.LaneKeep,
                InsuranceCompany = model.InsuranceCompany,
                GlassType = await _context.GlassTypes.FindAsync(model.GlassTypeId),
                BodyClass = model.BodyClass,
                DateOfLoss = model.DateOfLoss,
            };
        }

        public DetailedQuoteViewModel ToDetailedQuoteViewModel(Quote user)
        {
            return new DetailedQuoteViewModel
            {
                Address = user.Address,
                Address2 = user.Address2,
                City = user.City,
                State = user.State,
                Zip = user.Zip,
                GlassTypeId = user.GlassType.Id,
                GlassTypes = _combosHelper.GetComboGlassTypes(),
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.QuoteId,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                VinNumber = user.VinNumber.ToUpper(),
                Year = user.Year,
                Make = user.Make,
                Model = user.Model,
                Doors = user.Doors,
                VehicleType = user.VehicleType,
                LaneDeparture = user.LaneDeparture,
                LaneKeep = user.LaneKeep,
                InsuranceCompany = user.InsuranceCompany,
                BodyClass = user.BodyClass,
                DateOfLoss = user.DateOfLoss,
            };
        }
        public async Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew)
        {
            return new Vehicle
            {
                Color = model.Color,
                Id = isNew ? 0 : model.Id,
                VinNumber = model.VinNumber.ToUpper(),
                Year = model.Year,
                Make = model.Make,
                Model = model.Model,
                Tag = model.Tag.ToUpper(),
                BodyClass = model.BodyClass,
                Doors = model.Doors,
                VehicleType = model.VehicleType,
                LaneKeep = model.LaneKeep,
                LaneDeparture = model.LaneDeparture,
                Remarks = model.Remarks,
            };
        }

        public VehicleViewModel ToVehicleViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                Color = vehicle.Color,
                Id = vehicle.Id,
                VinNumber = vehicle.VinNumber.ToUpper(),
                Year = vehicle.Year,
                Model = vehicle.Model,
                Tag = vehicle.Tag.ToUpper(),
                Remarks = vehicle.Remarks,
                UserId = vehicle.User.Id,
                VehiclePhotos = vehicle.VehiclePhotos,
            };
        }

        public async Task<RepairOrder> ToRepairOrderAsync(RepairOrderViewModel rOrder, Guid invoiceImageId, Guid policyImageId, bool isNew)
        {
            return new RepairOrder
            {
                RepairOrderId = isNew ? 0 : rOrder.Id,
                BillTo = rOrder.BillTo,
                HasReferral = rOrder.HasReferral,
                HasApproval = rOrder.HasApproval,
                HasPictures = rOrder.HasPictures,
                HasSignature = rOrder.HasSignature,
                HasCalibration = rOrder.HasCalibration,
                ReferralNumber = rOrder.ReferralNumber,
                ArePartsAvailable = rOrder.ArePartsAvailable,
                CalibrationDone = rOrder.CalibrationDone,
                InstallDate = rOrder.InstallDate,
                ScheduledDate = rOrder.ScheduledDate,
                IsInstalled = rOrder.IsInstalled,
                IsScheduled = rOrder.IsScheduled,
                //TagImageId = tagImageId,
                //VinImageId = vinImageId,
                //DamageImageId = rOrder.DamageImageId,
                //FullDamageImageId = rOrder.FullDamageImageId,
                //InteriorImageId = rOrder.InteriorImageId,
                //InstalledImageId = rOrder.InstalledImageId,
                //Installed2ImageId = rOrder.Installed2ImageId,
                InvoiceImageId = invoiceImageId,
                //ReportId = rOrder.ReportId,
                PolicyImageId = policyImageId,
                Mileage = rOrder.Mileage,
                InstallerName = rOrder.InstallerName,
                Procedure = rOrder.Procedure,
                PartNumber = rOrder.PartNumber,
                PolicyNumber = rOrder.PolicyNumber,
            };
        }
        public RepairOrder ToRepairOrderAsync(RepairOrderViewModel rOrder, ImageIds imageIds, bool isNew)
        {
            return new RepairOrder
            {
                RepairOrderId = isNew ? 0 : rOrder.Id,
                BillTo = rOrder.BillTo,
                HasReferral = rOrder.HasReferral,
                HasApproval = rOrder.HasApproval,
                HasPictures = rOrder.HasPictures,
                HasSignature = rOrder.HasSignature,
                HasCalibration = rOrder.HasCalibration,
                ReferralNumber = rOrder.ReferralNumber,
                ArePartsAvailable = rOrder.ArePartsAvailable,
                CalibrationDone = rOrder.CalibrationDone,
                InstallDate = rOrder.InstallDate,
                ScheduledDate = rOrder.ScheduledDate,
                IsInstalled = rOrder.IsInstalled,
                IsScheduled = rOrder.IsScheduled,
                Mileage = rOrder.Mileage,
                InstallerName = rOrder.InstallerName,
                Procedure = rOrder.Procedure,
                PartNumber = rOrder.PartNumber,
                PolicyNumber = rOrder.PolicyNumber,
                TagImageId = imageIds.TagImageId,
                VinImageId = imageIds.VinImageId,
                DamageImageId = imageIds.DamageImageId,
                FullDamageImageId = imageIds.FullDamageImageId,
                InteriorImageId = imageIds.InteriorImageId,
                InstalledImageId = imageIds.InstalledImageId,
                Installed2ImageId = imageIds.Installed2ImageId,
                InvoiceImageId = imageIds.InvoiceImageId,
                ReportId = imageIds.ReportId,
                SignedROImageId = imageIds.SignedROImageId,
                PolicyImageId = imageIds.PolicyImageId,
            };
        }

        public RepairOrderViewModel ToRepairOrderViewModel(RepairOrder rOrder, ImageIds imageIds)
        {
            return new RepairOrderViewModel
            {
                Id = rOrder.RepairOrderId,
                BillTo = rOrder.BillTo,
                HasReferral = rOrder.HasReferral,
                HasApproval = rOrder.HasApproval,
                HasPictures = rOrder.HasPictures,
                HasSignature = rOrder.HasSignature,
                HasCalibration = rOrder.HasCalibration,
                ReferralNumber = rOrder.ReferralNumber,
                ArePartsAvailable = rOrder.ArePartsAvailable,
                CalibrationDone = rOrder.CalibrationDone,
                InstallDate = rOrder.InstallDate,
                ScheduledDate = rOrder.ScheduledDate,
                IsInstalled = rOrder.IsInstalled,
                IsScheduled = rOrder.IsScheduled,
                Mileage = rOrder.Mileage,
                InstallerName = rOrder.InstallerName,
                Procedure = rOrder.Procedure,
                PartNumber = rOrder.PartNumber,
                PolicyNumber = rOrder.PolicyNumber,
                TagImageId = imageIds.TagImageId,
                VinImageId = imageIds.VinImageId,
                DamageImageId = imageIds.DamageImageId,
                FullDamageImageId = imageIds.FullDamageImageId,
                InteriorImageId = imageIds.InteriorImageId,
                InstalledImageId = imageIds.InstalledImageId,
                Installed2ImageId = imageIds.Installed2ImageId,
                InvoiceImageId = imageIds.InvoiceImageId,
                ReportId = imageIds.ReportId,
                SignedROImageId = imageIds.SignedROImageId,
                PolicyImageId = imageIds.PolicyImageId,
            };
        }
    }
}
