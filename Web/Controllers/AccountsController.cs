using DI.DI.Interace;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel.ViewModels;

namespace Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IAccountRepository _IaccountRepository;

        public AccountsController(IAccountRepository IaccountRepository)
        {
            _IaccountRepository = IaccountRepository;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm request)
        {
            var x = await _IaccountRepository.Register(request);
            if (ModelState.IsValid)
            {
                if (x == 1)
                {
                    return RedirectToAction("Indexx", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login attemp");
            }
            return View(request);
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm request)
        {
            var x = await _IaccountRepository.Login(request);
            if (ModelState.IsValid)
            {
                if (x == 1)
                {
                    return RedirectToAction("Indexx", "Home");

                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(request);
        }

        public async Task<IActionResult> GetUser()
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }

            var c = await _IaccountRepository.GetUser();
            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> GetUser(UserVm     request)
        {
            var c = await _IaccountRepository.EditUser(request);
            if (c == 1)
            {
                TempData["Success"] = "Edit Success";
                return RedirectToAction("GetUser");
            }
            return View();
            
        }
    }
}
