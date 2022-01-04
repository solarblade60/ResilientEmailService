using RupaHealth.MappingExtensions;
using RupaHealth.Models.Parameters;
using System.ComponentModel.DataAnnotations;

namespace RupaHealth.Services
{
    public class ValidationService: IValidationService
    {
        public bool IsValidEmailFields(EmailParams data)
        {
            var emailData = data.ToEmailDto();

            if (emailData.FromEmailAddress == null)
            {
                return false;
            }

            if (!(new EmailAddressAttribute().IsValid(emailData.FromEmailAddress)))
            {
                return false;
            }

            if (emailData.ToEmailAddress == null)
            {
                return false;
            }

            if(!(new EmailAddressAttribute().IsValid(emailData.ToEmailAddress)))
            {
                return false;
            }

            return true;
        }
    }
}
