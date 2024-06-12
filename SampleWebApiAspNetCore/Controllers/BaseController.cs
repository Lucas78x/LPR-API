using Microsoft.AspNetCore.Mvc;

namespace SampleWebApiAspNetCore.Controllers.v1
{
    public abstract class BaseController : ControllerBase
    {
        protected string GetToken()
        {
            return HttpContext.Request.Headers["Authorization"]
                .FirstOrDefault(x => x.StartsWith("Bearer"))?
                .Substring("Bearer ".Length)
                .Trim();
        }
    }
}
