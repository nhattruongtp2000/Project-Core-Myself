using DI.DI.Interace;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<IActionResult> Index()
        {
            var a =await _contactRepository.GetContact();
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            
            return View(a);
        }

        [HttpPost]
        public async Task<ActionResult> Feedback(string UserName,string PhoneNumber, string Email, string Content)
        {
            var a = await _contactRepository.Feedback(UserName, PhoneNumber, Email, Content);
            if (a > 0)
            {
                TempData["Success"] = "Gửi thành công. Cảm ơn bạn đã góp ý!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

