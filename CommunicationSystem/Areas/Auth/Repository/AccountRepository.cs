
using Azure.Identity;
using CommunicationSystem.Areas.Auth.Models;
using CommunicationSystem.Areas.Auth.ViewModels;

namespace CommunicationSystem.Repository
{
    public interface IAccount
    {
        public Task<bool> CreateUserAsync(UserDTO user);
        public Task<string> AuthenticateUser(UserDTO user);
        public Task<ProfileViewModel?> GetUserProfile(string? name);
    }
    public class AccountRepository : IAccount
    {
        private readonly IEngineer _engineer;
        private readonly IOwner _owner;
        private readonly UserManager<AppUser> _userManager; 
        private readonly SignInManager<AppUser> _signInManager;
        public AccountRepository(
            IEngineer engineer,
            IOwner owner,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _engineer = engineer;
            _owner = owner;
            _signInManager = signInManager;
        }
        public async Task<string> AuthenticateUser(UserDTO user)
        {
            var response = string.Empty;
            var login_user = await _userManager.FindByEmailAsync(user.Email);
            if (login_user is not null)
            {
                if (await _userManager.CheckPasswordAsync(login_user, user.Password))
                {
                    await _signInManager.SignInAsync(login_user,false);
                    var userRoles = await _userManager.GetRolesAsync(login_user);
                    foreach (var userRole in userRoles)
                    {
                        if (userRole is "Engineer")
                        {
                            response = userRole.ToLower();
                        }
                        else
                        {
                            response = userRole.ToLower();
                        }
                    }

                }
                else
                {
                    response = "invalid login attempt";
                }
            }
            return response;

        }
        public async Task<bool> CreateUserAsync(UserDTO user)
        {
            var status = false;
            var new_user = new AppUser
            {
                Email = user.Email,
                UserName = user.Email
            };
            if (user.IsEngineer)
            {
                var result = await _userManager.CreateAsync(new_user, user.Password);
                if (result.Succeeded)
                {
                    var created_user = await _userManager.FindByEmailAsync(user.Email);
                    var engineer_info = new Engineer
                    {
                        FullName = user.FullName,
                        YearOfExperience = user.YearOfExperience,
                        WorkShopAddress = user.WorkShopAddress,
                        FacebookHandle = user.FacebookHandle,
                        InstagramHandle = user.InstagramHandle,
                        TwitterHandle = user.TwitterHandle,
                        Id = created_user.Id,
                        ImageURL = user.ImageURL
                    };
                    await _engineer.ModifyEngineer(engineer_info);
                    await _userManager.AddToRoleAsync(new_user, "Engineer");
                    status = true;
                }
                else
                {
                    status = false;
                    foreach (var error in result.Errors)
                    {


                    }
                }
            }
            else
            {
                var result = await _userManager.CreateAsync(new_user, user.Password);
                if (result.Succeeded)
                {
                    var created_user = await _userManager.FindByEmailAsync(user.Email);
                    var owner_info = new Owner
                    {
                        FullName = user.FullName,
                        Id = created_user.Id,
                        Address = user.Address
                    };
                    await _owner.ModifyOwner(owner_info);
                    await _userManager.AddToRoleAsync(new_user, "Owner");
                    status = true;
                }
                else
                {
                    status = false;
                    foreach (var error in result.Errors)
                    {


                    }
                }
            }
            return status;
        }

        public async Task<ProfileViewModel?> GetUserProfile(string? name)
        {
            var user = await _userManager.FindByEmailAsync(name);
            var result = new ProfileViewModel
            {
                enginner = await _engineer.GetEngineer(user.Id),
                owner = await _owner.GetOwner(user.Id)
            };
            return result;
        }
    }
}
