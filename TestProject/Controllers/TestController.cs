using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Controllers
{
  
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        public IActionResult Get()
        {

            return BadRequest();

        }

    }
}
