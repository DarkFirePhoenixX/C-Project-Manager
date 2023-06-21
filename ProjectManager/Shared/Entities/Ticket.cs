using System.ComponentModel.DataAnnotations;

namespace ProjectManager.Shared.Entities
{
    public class Ticket
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Name must be at least 3 and at max 25 characters long")]
        public string Name { get; set; }

        [Required]
        [MaxLength]
        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public Status Status { get; set; } = Status.ToDo;

        [Required]
        public User? Assignee { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public TimeSpan EstimatedTime { get; set; }

        [Required]
        public Project? Project { get; set; }
    }
}
