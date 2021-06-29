using Data.Data;
using Data.DB;
using Data.Utilities.Constants;
using DI.DI.Interace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace DI.DI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly Iden2Context _iden2Context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountRepository(Iden2Context iden2Context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager )
        {
            _iden2Context = iden2Context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public async Task<int> CountAccess()
        {
            var datetime = DateTime.Now;
            var year = datetime.Date;

            var json = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token); //get Token
            if (_iden2Context.Accesses.All(x => x.DateAcess != year))   //tìm xem có tồn tại collumn trong bảng hay không bằng cách tìm year
            {
                var x = new Access()
                {
                    DateAcess = year,
                    NumberOfAccess = 1
                };
                await _iden2Context.Accesses.AddAsync(x);
                return await _iden2Context.SaveChangesAsync();
            }

            var access =  _iden2Context.Accesses.FirstOrDefault(x => x.DateAcess == year);


            if (json != null)
            {
                access.NumberOfAccess = access.NumberOfAccess + 1;  // nếu không null + thêm 1 access
            }
            else if (access != null)
            {
                access.NumberOfAccess = access.NumberOfAccess + 1;  // nếu không null + thêm 1 access
            }
            //Cập nhật thông tin
          
            return await _iden2Context.SaveChangesAsync();
        }

        public async Task<int> EditUser(UserVm request)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var IdUser = user.Id;
            var a =await _iden2Context.Users.Where(x => x.Id == IdUser).FirstOrDefaultAsync();
            a.UserName = request.UserName;
            a.Address = request.Address;
            a.Email = request.Email;
            a.PhoneNumber = request.PhoneNumber;

            return await _iden2Context.SaveChangesAsync();
        }

        public async Task<string> GetId()
        {
            var user =await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var IdUser = user.Id;
            return IdUser;
        }

        public async Task<UserVm> GetUser()
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var a = new UserVm() 
            { 
            Address=user.Address,
            Email=user.Email,
            PhoneNumber=user.PhoneNumber,
            UserName=user.UserName                   
            };
            return a;
        }

        public async Task<int> Login(LoginVm request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Pass, request.RememberMe, false);
            if (result.Succeeded)
            {
                return 1;
            }
            return 0;
        }

        public async Task<int> Register(RegisterVm request)
        {
            var user = new AppUser()
            {
                UserName = request.UserName,
                Email = request.UserName + "@gmail.com"

            };
            
                var result = await _userManager.CreateAsync(user, request.Pass);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                return 1;
                }
            return 0;
        }
    }
}
