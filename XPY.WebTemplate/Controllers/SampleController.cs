﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceDetectorNET;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XPY.WebTemplate.Core.Authorization;
using XPY.WebTemplate.Services;

namespace XPY.WebTemplate.Controllers {
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class SampleController : Controller {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get([FromServices]DeviceDetector detector) {
            var os = detector.GetOs();
            return new string[] { os.Match.Name };
        }

        [HttpPost]
        public string Post([FromServices] SampleService jwt) {
            return jwt.JwtHelper.BuildToken("userId");
        }

    }
}