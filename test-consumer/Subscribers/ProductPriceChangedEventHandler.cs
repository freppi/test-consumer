using EasyNetQ;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_consumer.Events;

namespace test_consumer.Subscribers
{
    public class ProductPriceChangedEventHandler : IProductPriceChangedEventHandler
    {
        private readonly ILogger<ProductPriceChangedEventHandler> _logger;
        private readonly IBus _bus;
        private IDisposable _subscriber;

        public ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEventHandler> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task Start()
        {
            _logger.LogInformation("Starting subscriber");
            if (_bus.IsConnected)
            {
                _subscriber = _bus.SubscribeAsync<String>("productprice.changed.event", msg => Responder(msg));
            }
            else
                throw new Exception("EventBus couldn't establish a connection.");
            
        }

        public async Task Stop()
        {
            _subscriber.Dispose();
        }

        private async Task Responder(String @event)
        {
            var data = System.Text.Json.JsonSerializer.Deserialize<ProductPriceChangedEvent>(@event);
            _logger.LogInformation($"NEW EVENT WITH ID {data.EventId}");
            _logger.LogInformation($"EVENT DATA: ProductId: {data.ProductId}, NewPrice: {data.NewPrice}, OldPrice: {data.OldPrice}");
        }
    }
}
