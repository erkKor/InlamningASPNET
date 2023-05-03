using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
	public class LoginController : Controller
	{
		private readonly AuthenticationService _auth;

        public LoginController(AuthenticationService auth)
        {
            _auth = auth;
        }

        public IActionResult Index(string ReturnUrl = null!)
		{

			var viewModel = new LoginVM();
			if (ReturnUrl != null)
				viewModel.ReturnUrl = ReturnUrl;

			return View(viewModel);
		}



		[HttpPost]
		public async Task<IActionResult> Index(LoginVM model)
		{
			if(ModelState.IsValid)
			{
				if (await _auth.LoginAsync(model))
					return LocalRedirect(model.ReturnUrl);

                ModelState.AddModelError("", "Incorrect email or password");
            }

			
			return View(model);
		}
	}
}
