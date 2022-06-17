using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Home
{
    public enum CurrencyCode
    {
        USD,
        EUR,
        GPB,
        AUD
    }
    public class Currency
    {
        public Currency(CurrencyCode currencyCode, double amount)
        {
            CurrencyCode = currencyCode;
            Amount = amount;
        }

        public CurrencyCode CurrencyCode { get; }
        public double Amount { get; }
    }

}
