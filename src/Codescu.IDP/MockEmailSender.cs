using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Codescu.IDP
{
    public class MockEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
