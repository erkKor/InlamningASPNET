using WebApp.Helpers.Repositories;
using WebApp.Models.Entities;
using WebApp.Models.ViewModels;

namespace WebApp.Helpers.Services
{
	public class ContactFormService
	{
		private readonly ContactFormRepository _repository;

		public ContactFormService(ContactFormRepository repository)
		{
			_repository = repository;
		}

		public async Task AddContactMessageAsync(ContactFormViewModel viewModel)
		{
			ContactFormEntity contactFormEntity = viewModel;

			await _repository.AddAsync(contactFormEntity);
		}
	}
}
