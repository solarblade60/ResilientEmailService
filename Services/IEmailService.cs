using RupaHealth.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RupaHealth
{
    public partial interface IEmailService
    {
        Task<bool> HandleEmail(EmailParams data);
    }
}
