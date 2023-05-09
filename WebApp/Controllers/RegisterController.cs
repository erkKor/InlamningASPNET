using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AuthenticationService _auth;

        public RegisterController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterVM model)
        {
            if(ModelState.IsValid)
            {
                if (await _auth.UserExistsAsync(x => x.Email == model.Email))
                    ModelState.AddModelError("", "User with the same email adress already exists.");

                if (await _auth.RegisterUserAsync(model))
                    return RedirectToAction("Index", "Login");
                        
            }
 
            return View(model); 
        }
    }
}
