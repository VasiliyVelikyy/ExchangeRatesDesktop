using ExchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.Helper
{
    internal class FindRate
    {
        string rateName;
        public FindRate(string rateName)
        {
            this.rateName = rateName;
        }
        public bool RatePredicate(Exchange exchange)
        {
            return exchange.RateName== rateName;
        }
    }
}
