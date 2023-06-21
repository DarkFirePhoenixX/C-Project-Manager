using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Dto
{
    public class UserProductivityDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public UserRole UserRole { get; set; }

        public int NumOfProjects { get; set; } = 0;

        public int NumOfTodoTickets { get; set; } = 0;

        public int NumOfInProgressTickets { get; set; } = 0;

        public int NumOfCompletedTickets { get; set; } = 0;
    }
}
