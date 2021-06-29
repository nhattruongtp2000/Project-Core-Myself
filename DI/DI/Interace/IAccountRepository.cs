
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace DI.DI.Interace
{
    public interface IAccountRepository
    {
        Task<int> CountAccess();

        Task<int> Register(RegisterVm request);

        Task<int> Login(LoginVm request);

        Task<string> GetId();

        Task<UserVm> GetUser();

        Task<int> EditUser(UserVm request);



    }
}
