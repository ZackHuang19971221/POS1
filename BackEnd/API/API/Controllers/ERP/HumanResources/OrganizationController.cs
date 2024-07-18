using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.ERP.HumanResources
{
    [ApiExplorerSettings(GroupName = "ERP")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrganizationController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            return "";
        }
    }
}
