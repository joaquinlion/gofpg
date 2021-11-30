using GoFpg.API.Data.Entities;
using GoFpg.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace GoFpg.API.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<User> GetUserAsync(int id);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<IdentityResult> DeleteUserAsync(User user);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);

        Task<SignInResult> ValidatePasswordAsync(User user, string password);
    }
}
