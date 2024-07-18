using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ERP
{
    [ApiExplorerSettings(GroupName = "ERP")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet("GetCompanyData", Name = "GetCompanyData")]
        public async Task<string> GetCompanyData()
        {
            return "";
        }

        [HttpPut("UpdateCompanyData", Name = "UpdateCompanyData")]
        public async Task UpdateCompanyData()
        {
            // Implementation
        }

        [HttpGet("GetBranches", Name = "GetBranchesList")]
        public async Task<List<string>> GetBranches()
        {
            return new List<string>();
        }

        [HttpGet("GetBranch", Name = "GetBranch")]
        public async Task<string> GetBranch()
        {
            return "";
        }

        [HttpPost("AddBranch", Name = "AddBranch")]
        public async Task AddBranch()
        {
            // Implementation
        }

        [HttpPut("UpdateBranch", Name = "UpdateBranch")]
        public async Task UpdateBranch()
        {
            // Implementation
        }

        [HttpDelete("DeleteBranch", Name = "DeleteBranch")]
        public async Task DeleteBranch()
        {
            // Implementation
        }
    }
}
