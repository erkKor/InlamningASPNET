using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Helpers.Repositories;
using WebApp.Helpers.Services;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddAuthorization();
builder.Services.AddScoped<AdressRepository>();
builder.Services.AddScoped<UserAdressRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<ProductCategoriesRepository>();
builder.Services.AddScoped<ContactFormRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AdressService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<ContactFormService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
	x.SignIn.RequireConfirmedAccount = false;
	x.Password.RequiredLength = 8;
	x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<DataContext>()
//.AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
.AddRoleManager<RoleManager<IdentityRole>>();




builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = "/login";
	x.LogoutPath = "/";
	x.AccessDeniedPath = "/denied";
});


//builder.Services.AddAuthorization(options =>
//{
//	options.AddPolicy("AdminOnly", policy =>
//		policy.RequireRole("Admin"));
//});

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
