using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AdressId))]
public class UserAdressEntity
{
	public string UserId { get; set; } = null!;
	public AppUser User { get; set; } = null!;

	public int AdressId { get; set; } 
	public AdressEntity Adress { get; set; } = null!;
}
