using Microsoft.AspNetCore.Identity;

namespace SellCar.Domain.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime MembershipDate { get; set; }
    }
}
