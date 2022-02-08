using GoFpg.API.Data.Entities;
using GoFpg.API.Models;
using System;
using System.Threading.Tasks;

namespace GoFpg.API.Helpers
{
    public interface IConverterHelper
    {
        Task<User> ToUserAsync(UserViewModel model, Guid imageId, bool isNew);

        UserViewModel ToUserViewModel(User user);

        Task<Quote> ToQuoteAsync(DetailedQuoteViewModel model);

        DetailedQuoteViewModel ToDetailedQuoteViewModel(Quote user);

        Task<Vehicle> ToVehicleAsync(VehicleViewModel model, bool isNew);

        VehicleViewModel ToVehicleViewModel(Vehicle vehicle);

        Task<Detail> ToDetailAsync(DetailViewModel model, bool isNew);

        DetailViewModel ToDetailViewModel(Detail detail);

        Task<User> ToMinUserAsync(NewClaimViewModel newClaimViewModel, bool isNew);

        Task<InsuranceClaim> ToMinInsuranceClaimAsync(NewClaimViewModel newClaimViewModel, bool isNew);

        //Task<Vehicle> ToMinVehicleAsync(NewClaimViewModel newClaimViewModel, bool isNew);
        NewClaimViewModel ToNewClaimViewModel(InsuranceClaim insuranceClaim, User user);
    }
}
