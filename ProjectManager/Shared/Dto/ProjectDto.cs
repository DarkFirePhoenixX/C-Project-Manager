using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Dto
{
    public sealed class ProjectDto
    {
        public ProjectDto()
        {
        }

        public ProjectDto(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Status = project.Status;
            DueDate = project.DueDate;
            Uri = project.Uri;
            if (project.Company != null)
            {
                Company = new CompanyDto(project.Company);
            }

            if (project.Users != null)
            {
                NumOfUsers = project.Users.Count;
                Users = project.Users.Select(u => new UserDto(u)).ToList();
            }

            if (project.Tickets == null)
            {
                return;
            }

            foreach (Ticket ticket in project.Tickets)
            {
                switch (ticket.Status)
                {
                    case Status.ToDo:
                        ToDoTickets += 1;
                        break;
                    case Status.InProgress:
                        InProgressTickets += 1;
                        break;
                    case Status.Completed:
                        CompletedTickets += 1;
                        break;
                }
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Status Status { get; set; } = Status.ToDo;

        public DateTime DueDate { get; set; } = DateTime.Today;

        public string Uri { get; set; }

        public CompanyDto Company { get; set; }

        public int ToDoTickets { get; set; }

        public int InProgressTickets { get; set; }

        public int CompletedTickets { get; set; }

        public int NumOfUsers { get; set; }
        public ICollection<UserDto>? Users { get; set; }
    }
}
