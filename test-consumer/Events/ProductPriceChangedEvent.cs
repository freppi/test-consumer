using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;

namespace test_consumer.Events
{
    [Queue("product-prices", ExchangeName = "ProductExchange")]
    public class ProductPriceChangedEvent
    {
        public Guid EventId { get; set; }
        public int ProductId { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
    }
}
