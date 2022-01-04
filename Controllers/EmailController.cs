using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RupaHealth.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RupaHealth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {

        private readonly ILogger<EmailController> _logger;
        private readonly IEmailService _emailService;

        public EmailController(ILogger<EmailController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> PostEmail([FromBody] EmailParams data)
        {
            var wasSuccessful = await _emailService.HandleEmail(data);

            if (!wasSuccessful)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
