using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_consumer.Subscribers
{
    public interface IProductPriceChangedEventHandler
    {
        Task Start();
        Task Stop();
    }
}

    
