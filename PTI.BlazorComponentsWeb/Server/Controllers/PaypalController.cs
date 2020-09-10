using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PTI.BlazorComponentsWeb.Shared.Paypal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PTI.BlazorComponentsWeb.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaypalController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> UserSubscribed(OnApprovedData model)
        {
            return Ok();
        }
    }
}
