using RupaHealth.Models.Dtos;
using System.Threading.Tasks;

namespace RupaHealth
{
    public partial interface IEmailService
    {
        Task<bool> ResilientEmailDeliveryService(EmailDto data);
    }
}
