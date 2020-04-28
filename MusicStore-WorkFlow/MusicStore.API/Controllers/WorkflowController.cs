using Jexoy.API.BusinessLayer;
using Jexoy.API.BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Jexoy.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkflowController : Controller
    {
        [HttpGet]
        public JsonResult WorkFlow()
        {
            try
            {
                WorkflowService __workflowService = new WorkflowService();

                RootObject data = __workflowService.BuildOperator();

                return Json(JsonConvert.SerializeObject(data));
            }
            catch
            {
                return null;
            }
        }

    }
}
