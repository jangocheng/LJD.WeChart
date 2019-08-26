using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LJD.WeChart.Controllers.WeChartApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeChartLoginController : ControllerBase
    {
        [HttpPost]
        public JsonResult Login()
        {
            return new JsonResult("");
        }
    }
}