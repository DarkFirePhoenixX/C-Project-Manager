using ProjectManager.Shared.Entities;

namespace ProjectManager.Shared.Interfaces
{
    public interface IUtility
    {
        Task<User?> GetUser();
    }
}
