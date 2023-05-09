namespace WebApp.Models.ViewModels
{
    public class UserVM
    {
        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string? StreetName { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Company { get; set; }
        public string? ImageUrl { get; set; }

        public string RoleName { get; set; } = null!;
        public IList<string> RoleNames { get; set; } = null!;
    }
}
