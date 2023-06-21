using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Dto
{
    public class TicketDto
    {
        public TicketDto()
        {
        }

        public TicketDto(Ticket ticket)
        {
            Id = ticket.Id;
            Name = ticket.Name;
            Description = ticket.Description;
            Priority = ticket.Priority;
            Status = ticket.Status;
            DueDate = ticket.DueDate;
            EstimatedTime = ticket.EstimatedTime.Hours;
            TicketUrl = $"{ticket.Project?.Company?.Uri}/project/{ticket.Project?.Uri}/ticket/{ticket.Id}/manage";
            if (ticket.Assignee != null)
            {
                Assignee = new UserDto(ticket.Assignee);
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; } = Status.ToDo;

        public UserDto Assignee { get; set; }

        public DateTime DueDate { get; set; } = DateTime.Today;

        public int EstimatedTime { get; set; }

        public string TicketUrl { get; set; }
    }
}
