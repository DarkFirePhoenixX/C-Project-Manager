using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Shared.Entities
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 and at max 25 characters long")]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be at least 5 and at max 25 characters long")]
        public string Uri { get; set; }

        public virtual ICollection<Project>? Projects { get; set; } = new List<Project>();

        public virtual ICollection<UserCompany>? Users { get; set; } = new List<UserCompany>();
    }
}
