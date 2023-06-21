using ProjectManager.Client.Shared;
using ProjectManager.Shared.Dto;

namespace ProjectManager.Client.Services
{
    public interface INavService
    {
        public Toast? Toast { get; set; }

        public UserDto? CurrentUser { get; }

        public bool Fetched { get; }

        public Stack<CompanyDto> CompanyList { get; }

        public event Action OnChange;

        public CompanyDto GetCurrentCompany();
        public bool IsAdmin(bool redirect = false);
        public string TitleCase(string text);
        public void SetCurrentCompany(string newCompanyUri, bool reload);
        public string CurrentUrl();
        public CompanyDto GetCompanyByUri(string uri);
        public void NavigateToProjects(bool reload);
        public void NavigateToHome(bool reload);
        public void Reload();
    }

    public struct NavRoutes
    {
        public string Name { get; init; }

        public string Href { get; init; }

        public string HrefWithCompany { get; set; }

        public bool Selected { get; set; }

        public bool AdminOnly { get; set; }
    }

    public class Notification : IEquatable<Notification>
    {
        public string? Title { get; init; }

        public string? Message { get; init; }

        public string? Color { get; init; }

        public bool Equals(Notification? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Title == other.Title && Message == other.Message && Color == other.Color;
        }

#pragma warning disable CS8765
        public override bool Equals(object obj)
#pragma warning restore CS8765
        {
            return Equals(obj as Notification);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public readonly struct Breadcrumb
    {
        public string Name { get; init; }

        public string Url { get; init; }
    }
}
