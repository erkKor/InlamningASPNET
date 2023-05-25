using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.Contexts
{
	public class DataContext : IdentityDbContext<AppUser>
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}
		public DbSet<AdressEntity> Adresses { get; set; }
		public DbSet<UserAdressEntity> UserAdresses { get; set; }
		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
		public DbSet<ContactFormEntity> ContactFormMessages { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<CategoryEntity>().HasData
			(
				new CategoryEntity { Id = 1, CategoryName = "New" },
				new CategoryEntity { Id = 2, CategoryName = "Popular" },
				new CategoryEntity { Id = 3, CategoryName = "Featured" }
			);
			builder.Entity<IdentityRole>().HasData
			(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER" }
			);
		}
	}
}