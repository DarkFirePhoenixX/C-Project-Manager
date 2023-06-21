using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Shared.Entities
{
    public class User : IdentityUser
    {
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 and at max 25 characters long")]
        public string? Name { get; set; }

        public ICollection<Project>? Projects { get; set; } = new List<Project>();

        public virtual ICollection<UserCompany>? Companies { get; set; } = new List<UserCompany>();
    }
}
