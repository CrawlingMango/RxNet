using Microsoft.AspNetCore.Mvc;
using Sample.Rx.Buffer.Api.Services;

namespace Sample.Rx.Buffer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly AlertService _alertService;

        public AlertController(AlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet("ping")]
        public ActionResult<string> Ping() 
        {
            _alertService.Alert("<error-message>");
            return Ok($"Pong");
        }
    }
}
