using Microsoft.AspNetCore.Identity;
using SellCar.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace SellCar.Domain.ViewModels.Roles
{
    public class RoleViewModel
    {
        [Required] public string Name { get; set; }
    }
    public class RoleDetails
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<User> Members { get; set; }
        public IEnumerable<User> NonMembers { get; set; }
    }
    public class RoleEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }

}
