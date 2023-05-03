using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels
{
	public class CardGridItemVM
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;
		public string Description { get; set; } = null!;
		public decimal Price { get; set; }
		public string ImageUrl { get; set; } = null!;

    }
}
