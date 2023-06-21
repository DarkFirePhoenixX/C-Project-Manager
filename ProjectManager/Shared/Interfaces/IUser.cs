using ProjectManager.Shared.Dto;

namespace ProjectManager.Shared.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Get();
        public Task<UserDto> Get(string id);
        public Task<List<UserDto>> GetUsersByProject(string projectUri);
        public Task<List<UserDto>> GetUsersByCompany(Guid companyId);
        public Task<UserDto> Update(UserDto user);
        public Task<bool> Delete();
        public Task<UserCompanyDto> SetUserCompany(UserInvite userInvite);
        public Task<CompanyDto> LeaveCompany(Guid companyId);
        public Task<UserDto> ModifyProject(Guid projectId, string userId);
    }
}
