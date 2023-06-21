using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProjectManager.Shared.Dto;
using ProjectManager.Shared.Interfaces;

namespace ProjectManager.Client.Services {
    public class UserService : IUser {
        private const String EntityName = "user";
        private readonly HttpClient _http;

        public UserService(HttpClient http) {
            _http = http;
        }

                                                public async Task<UserDto> Get() {
            UserDto? user = await _http.GetFromJsonAsync<UserDto>("api/user/") ?? throw new ApplicationException($"Error while getting {EntityName}");
            return user;
        }

                                                        public async Task<UserDto> Get(String id) {
            UserDto? user = await _http.GetFromJsonAsync<UserDto?>($"api/user/{id}/") ?? throw new ApplicationException($"Error while getting {EntityName}");
            return user;
        }

                                                        public async Task<List<UserDto>> GetUsersByCompany(Guid companyId) {
            List<UserDto>? users = await _http.GetFromJsonAsync<List<UserDto>>($"api/user/company/{companyId}/") ?? throw new ApplicationException($"Error while getting {EntityName}");
            return users;
        }

                                                        public async Task<UserDto> Update(UserDto user) {
            HttpResponseMessage response = await _http.PutAsJsonAsync("api/user/", user);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error while updating ${EntityName}, Reason: {response.ReasonPhrase}");

            UserDto? updatedUser = await response.Content.ReadFromJsonAsync<UserDto>() ?? throw new ApplicationException($"Error while updating ${EntityName}");
            return updatedUser;
        }

                                                public async Task<Boolean> Delete() {
            HttpResponseMessage response = await _http.DeleteAsync("api/user/");
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error while deleting ${EntityName}, Reason: {response.ReasonPhrase}");
            return await response.Content.ReadFromJsonAsync<Boolean>();
        }

                                                                public async Task<UserCompanyDto> SetUserCompany(UserInvite userInvite) {
            HttpResponseMessage response = await _http.PutAsJsonAsync("api/user/company/", userInvite);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error while updating User Company, Reason: {response.ReasonPhrase}");

            UserCompanyDto? updateUserCompany = await response.Content.ReadFromJsonAsync<UserCompanyDto>() ?? throw new ApplicationException("Error while updating User Company");
            return updateUserCompany;
        }

                                                        public async Task<CompanyDto> LeaveCompany(Guid companyId) {
            HttpResponseMessage response = await _http.PostAsJsonAsync("api/user/company/", companyId);
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error while leaving company, Reason: {response.ReasonPhrase}");

            CompanyDto? company = await response.Content.ReadFromJsonAsync<CompanyDto>() ?? throw new ApplicationException($"Could not retrieved the ${EntityName}");
            return company;
        }

                                                                public async Task<UserDto> ModifyProject(Guid projectId, String userId) {
            HttpResponseMessage response = await _http.PutAsJsonAsync("api/user/project/", new Tuple<Guid, String>(projectId, userId));
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Error while updating User Project, Reason: {response.ReasonPhrase}");

            UserDto? user = await response.Content.ReadFromJsonAsync<UserDto>() ?? throw new ApplicationException("Error while updating User Project");
            return user;
        }

                                                        public async Task<List<UserDto>> GetUsersByProject(String projectUri) {
            List<UserDto>? users = await _http.GetFromJsonAsync<List<UserDto>>($"api/user/project/{projectUri}");
            return users ?? throw new ApplicationException($"Error while getting {EntityName}");
        }
    }
}
