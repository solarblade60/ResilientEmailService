using RupaHealth.Models.Parameters;

namespace RupaHealth
{
    public partial interface IValidationService
    {
        bool IsValidEmailFields(EmailParams data);
    }
}
