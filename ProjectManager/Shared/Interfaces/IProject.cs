using ProjectManager.Shared.Dto;

namespace ProjectManager.Shared.Interfaces
{
    public interface IProject
    {
        Task<List<ProjectDto>> List();
        Task<List<ProjectDto>> List(Guid companyId);
        Task<ProjectDto> Get(Guid projectId);
        Task<ProjectDto> Get(string companyUri, string projectUri);
        Task<ProjectDto> Create(ProjectDto project);
        Task<ProjectDto> Update(Guid projectId, ProjectDto project);
        Task<bool> Delete(Guid projectId);
        Task<ProjectDto> ModifyUser(Guid projectId, UserDto user);
    }
}
