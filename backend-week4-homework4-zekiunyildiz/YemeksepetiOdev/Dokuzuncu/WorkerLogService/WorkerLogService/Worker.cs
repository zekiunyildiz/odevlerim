using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerLogService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient client;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            client = new HttpClient();
            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            client.Dispose();
            _logger.LogInformation("hizmet durduruldu...");
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = await client.GetAsync("https://www.zekiunyildiz.com/");
                if (result.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Web sitesi açýldý. Durum kodu {StatusCode}", result.StatusCode);
                }
                else
                {
                    _logger.LogError("Web sitesi kapandý. Durum kodu {StatusCode}", result.StatusCode);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
