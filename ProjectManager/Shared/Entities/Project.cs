using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Shared.Entities
{
    public class Project
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 and at max 25 characters long")]
        public string Name { get; set; }

        public Status Status { get; set; } = Status.ToDo;

        public DateTime DueDate { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Uri must be at least 5 and at max 25 characters long")]
        public string Uri { get; set; }

        [Required]
        public Company? Company { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? CompletedAt { get; set; } = null;

        public virtual ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<User>? Users { get; set; } = new List<User>();
    }
}
