using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Dto
{
    public class UserInvite
    {
        public string Email { get; set; }

        public Guid CompanyId { get; set; }

        public UserRole? Role { get; set; } = UserRole.User;
    }
}
