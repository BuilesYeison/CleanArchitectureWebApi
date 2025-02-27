using Application.Interfaces.Services;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class AppMessageService : IMessageService
    {
        private readonly ILogger<AppMessageService> _logger;

        public AppMessageService(ILogger<AppMessageService> logger)
        {
            _logger = logger;
        }

        public async Task SendMessageAsync(string recipient, string subject, string body)
        {
            // simulation
            await Task.Delay(500);
            _logger.LogInformation($"📧 Email enviado a {recipient}: {subject}");
        }
    }
}
