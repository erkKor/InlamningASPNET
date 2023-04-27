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
		public DbSet<ProductCategoryEntity> ProductCategories { get; set; }



		//protected override void OnModelCreating(ModelBuilder builder)
		//{

		//	var roleId = Guid.NewGuid().ToString();
		//	var userId = Guid.NewGuid().ToString();	
			

		//	base.OnModelCreating(builder);

		//	builder.Entity<IdentityRole>().HasData(new IdentityRole
		//	{
		//		Id = roleId,
		//		Name = "Admin",
		//		NormalizedName = "ADMIN"
		//	});


		//	var passwordHasher = new PasswordHasher<AppUser>();

		//	builder.Entity<AppUser>().HasData(new AppUser
		//	{
		//		Id = userId,
		//		UserName = " ",
		//		FirstName = " ",
		//		LastName = "Adminlastname",
		//		Email = "admin@domain.com",
		//		PasswordHash = passwordHasher.HashPassword(null!, "Admin123!"),
				
		//	});

		//	builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
		//	{
		//		RoleId = roleId,
		//		UserId = userId,
		//	});
		//}
	}
}
