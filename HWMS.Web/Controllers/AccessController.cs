using System;
using Microsoft.AspNetCore.Mvc;

namespace HWMS.Web.Controllers
{

    public class AccessController : ControllerBase
    {
        public AccessController()
        {

        }
        [Route("/api/Access/Login")]
        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}