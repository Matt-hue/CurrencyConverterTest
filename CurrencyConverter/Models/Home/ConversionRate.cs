using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Home
{
    public class ConversionRate
    {
        public ConversionRate(CurrencyCode from, CurrencyCode to, double rate)
        {
            From = from;
            To = to;
            Rate = rate;
        }

        public CurrencyCode From { get; }
        public CurrencyCode To { get; }
        public double Rate { get; }

        public Currency Convert(double amount)
        {
            double convertedAmount = amount * Rate;
            var currency = new Currency(this.To, convertedAmount);

            return currency;
        }
    }
}
