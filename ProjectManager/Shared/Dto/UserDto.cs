using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Dto
{
    public class UserDto
    {
        public UserDto() { }
        public UserDto(User user, bool expand = true)
        {
            Id = user.Id;
            Name = user.Name;
            UserName = user.UserName;
            Email = user.Email;

            if (!expand)
            {
                return;
            }

            if (user.Companies == null)
            {
                return;
            }

            foreach (UserCompany userCompany in user.Companies)
            {
                UserCompany?.Add(new UserCompanyDto(userCompany));
            }
        }

        public string? Id { get; set; }

        public string? Name { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string? Password { get; set; }

        public ICollection<UserCompanyDto>? UserCompany { get; set; } = new List<UserCompanyDto>();
    }
}
