using EntTorgMaster.Infrastructure;
using EntTorgMaster.Services;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;
using EntTorgMaster.Helpers;

namespace EntTorgMaster.Models
{
    public class LoginModel : OwningComponentBase
    {
        [Inject] ILocalStorageService LocalStorageService { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        [Inject] UserService _userService { get; set; }
        private UserService userService;
        public LoginModel()
        {
            //userService = (UserService)ScopedServices.GetRequiredService<UserService>();
            LoginDate = new();
        }

        protected override void Dispose(bool disposing)
        {
            _userService.Dispose();
            base.Dispose(disposing);
        }

        public LoginViewModel LoginDate { get; set; }

        protected async Task LoginAync()
        {
            string login = LoginDate.UserName.ToLower();
            string password = LoginDate.Password.CreateMD5().ToLower();
            var user = (await _userService.GetUsers())
                .Where(u => u.Login.ToLower() == login & u.Password == password)
                .FirstOrDefault();
            if (user != null)
            {
                var token = new SecurityToken
                {
                    UserId= user.Id,
                    UserName = LoginDate.UserName,
                    AccessToken = LoginDate.Password,
                    Role = user.Role.ToString(),
                    ExpireAt = DateTime.UtcNow.AddDays(1)
                };
                await LocalStorageService.SetAsync<SecurityToken>(nameof(SecurityToken), token);
                NavigationManager.NavigateTo("/", true);
            }
        }
    }

    public class LoginViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "length")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class SecurityToken
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public string Role { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
