using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace NerdStore.Enterprise.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/api/v1/[action]/")]
    public class BaseController:ControllerBase
    {

        [NonAction]
        public IActionResult JsonOk(object message)
        {
            try
            {
                return new JsonResult(message);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }

        }

    }
}
