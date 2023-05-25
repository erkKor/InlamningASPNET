using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels
{
    public class AddProductVM
    {
        [Display(Name = "Product Name*")]
        [Required(ErrorMessage = "You must enter a product name")]
        [MinLength(2, ErrorMessage = "Product name must be atleast 2 characters")]
        public string Name { get; set; } = null!;

        [Display(Name = "Product Price*")]
        [Required(ErrorMessage = "You must enter a price")]
        public decimal Price { get; set; }

        [Display(Name = "Product Description*")]
        [Required(ErrorMessage = "You must enter a description")]
        [MinLength(2, ErrorMessage = "Product description must be atleast 2 characters")]
        public string Description { get; set; } = null!;

        [Display(Name = "Product Image URL (optional)")]
        public string? ImageUrl { get; set; }
        public int[] SelectedCategoryId { get; set; } = null!;


		public static implicit operator ProductEntity(AddProductVM model)
		{
			return new ProductEntity
			{
				Name = model.Name,
				Description = model.Description,
				Price = model.Price,
                ImageUrl = model.ImageUrl,
			};
		}
	}
}
