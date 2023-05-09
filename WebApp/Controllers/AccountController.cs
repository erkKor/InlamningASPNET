using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApp.Helpers.Services;

namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserService _userService;

		public AccountController(UserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
        {
            string? email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
            var user = await _userService.GetUserByEmailAsync(email!);

            return View(user);
        }
    }
}
