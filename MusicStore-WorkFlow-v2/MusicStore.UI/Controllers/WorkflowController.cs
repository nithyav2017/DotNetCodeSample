using MusicStore.API.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MusicStore.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkflowController : Controller
    {
        
        [HttpGet]
        public ActionResult WorkFlow()
        {
            try
            {
                WorkflowService __workflowService = new WorkflowService();
                JObject data = __workflowService.BuildMusicStoreOperator();
                var result = JsonConvert.SerializeObject(data);
                result = result.Replace("[", "").Replace("]", "").Replace("},{", ",");
                return Json(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
