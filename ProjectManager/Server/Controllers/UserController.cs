using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Shared.Dto;
using ProjectManager.Shared.Interfaces;


namespace ProjectManager.Server.Controllers {
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        public UserController(IUser userModel) {
            UserModel = userModel;
        }

        [Inject]
        protected IUser UserModel { get; set; }

                [HttpGet]
        public async Task<IActionResult> Get() {
            try
            {
                UserDto user = await UserModel.Get();
                return Ok(user);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id) {
            UserDto user = await UserModel.Get(id);
            return Ok(user);
        }

                [HttpGet("project/{projectUri}")]
        public async Task<IActionResult> GetUsersByProject(String projectUri) {
            return Ok(await UserModel.GetUsersByProject(projectUri));
        }

                [HttpGet("company/{companyId:guid}")]
        public async Task<IActionResult> GetUsersByCompany(Guid companyId) {
            try
            {
                return Ok(await UserModel.GetUsersByCompany(companyId));
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserDto userDto) {
            try
            {
                UserDto user = await UserModel.Update(userDto);
                return Ok(user);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpDelete]
        public async Task<IActionResult> Delete() {
            try
            {
                Boolean deleted = await UserModel.Delete();
                return Ok(deleted);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpPut("company")]
        public async Task<IActionResult> ModifyCompany([FromBody] UserInvite userInvite) {
            try
            {
                UserCompanyDto userCompany = await UserModel.SetUserCompany(userInvite);
                return Ok(userCompany);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpPost("company")]
        public async Task<IActionResult> LeaveCompany([FromBody] Guid companyId) {
            try
            {
                CompanyDto company = await UserModel.LeaveCompany(companyId);
                return Ok(company);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }

                [HttpPut("project")]
        public async Task<IActionResult> ModifyProject([FromBody] Tuple<Guid, String> userProject) {
            (Guid projectId, String userId) = userProject;
            try
            {
                UserDto userCompany = await UserModel.ModifyProject(projectId, userId);
                return Ok(userCompany);
            }
            catch (InvalidDataException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
