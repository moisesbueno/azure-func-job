using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace azure_func_job
{
    public class teste_timer
    {
        private readonly ILogger _logger;

        public teste_timer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<teste_timer>();
        }

        [Function("teste_timer")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
