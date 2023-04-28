using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers.Services;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
	public class ContactsController : Controller
	{
		private readonly ContactFormService _contactFormService;

		public ContactsController(ContactFormService contactFormService)
		{
			_contactFormService = contactFormService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(ContactFormViewModel viewModel)
		{
			if(ModelState.IsValid)
			{
				await _contactFormService.AddContactMessageAsync(viewModel);
				ModelState.Clear();
				ViewBag.Success = true;
				return View();
			}

			return View(viewModel);
		}
	}
}
