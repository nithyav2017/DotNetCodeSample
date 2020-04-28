using MusicStore.API.BusinessLayer;
using MusicStore.UI.DataLayer;
using MusicStore.UI.DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MusicStore.API.Controllers
{
    [Route("api/[controller]")]
    public class WorkflowController : Controller
    {
        MusicStoreTableServices __musicStore = new MusicStoreTableServices();

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
