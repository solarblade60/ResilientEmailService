using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RupaHealth.MappingExtensions;
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
        private readonly IValidationService _validationService;

        public EmailController(ILogger<EmailController> logger, IEmailService emailService, IValidationService validationService)
        {
            _logger = logger;
            _emailService = emailService;
            _validationService = validationService;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult> PostEmail([FromBody] EmailParams data)
        {
            //Validate email input fields

            if (!_validationService.IsValidEmailFields(data))
            {
                return BadRequest();
            }

            var isSuccess = await _emailService.ResilientEmailDeliveryService(data.ToEmailDto());

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
