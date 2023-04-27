namespace WebApp.Models.Entities
{
	public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public ICollection<ProductCategoryEntity> Category { get; set; } = null!;
    }
}
