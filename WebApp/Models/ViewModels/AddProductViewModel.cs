using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels
{
    public class AddProductViewModel
    {
        [Display(Name = "Product Name*")]
        [Required(ErrorMessage = "You must enter a product name")]
        public string Name { get; set; } = null!;

        [Display(Name = "Product Price*")]
        [Required(ErrorMessage = "You must enter a price")]
        public decimal Price { get; set; }

        [Display(Name = "Product Description*")]
        [Required(ErrorMessage = "You must enter a description")]
        public string Description { get; set; } = null!;
        public int[] SelectedCategoryId { get; set; } = null!;


		public static implicit operator ProductEntity(AddProductViewModel model)
		{
			return new ProductEntity
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
			};
		}
	}
}
