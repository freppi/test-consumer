using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using test_consumer.Subscribers;

namespace test_producer
{
    internal class ServiceContainer : IHostedService, IDisposable
    {
        private readonly ILogger<ServiceContainer> _logger;
        private readonly IProductPriceChangedEventHandler _productPriceChangedEventHandler;

        public ServiceContainer(ILogger<ServiceContainer> logger, IProductPriceChangedEventHandler productPriceChangedEventHandler)
        {
            _logger = logger;
            _productPriceChangedEventHandler = productPriceChangedEventHandler;
        }

        public void Dispose()
        {
            
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("STARTING SUBSCRIBERS");
            _productPriceChangedEventHandler.Start();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this._logger.LogInformation("STOPING SUBSCRIBERS");
            _productPriceChangedEventHandler.Stop();

            return Task.CompletedTask;
        }
    }
}
