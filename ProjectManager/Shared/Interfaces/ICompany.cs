using ProjectManager.Shared.Dto;

namespace ProjectManager.Shared.Interfaces
{
    public interface ICompany
    {
        Task<List<CompanyDto>> List();
        Task<CompanyDto> Get(Guid companyId);
        Task<CompanyDto> Create(CompanyDto company);
        Task<CompanyDto> Update(Guid companyId, CompanyDto company);
        Task<bool> Delete(Guid companyId);
        Task<CompanyDto> ModifyUser(Guid companyId, UserCompanyDto user);
    }
}
