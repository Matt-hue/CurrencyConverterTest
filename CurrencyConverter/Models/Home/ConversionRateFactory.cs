using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Home
{
    public class ConversionRateFactory
    {
        private static Dictionary<Tuple<CurrencyCode, CurrencyCode>, double> rates =
            new Dictionary<Tuple<CurrencyCode, CurrencyCode>,double>()
            {
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.USD, CurrencyCode.EUR), 1.11},
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.EUR, CurrencyCode.USD), (1/1.11)},

                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.USD, CurrencyCode.GPB), 1.12},
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.GPB, CurrencyCode.USD), (1/1.12)},

                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.USD, CurrencyCode.AUD), 1.13 },
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.AUD, CurrencyCode.USD), (1/1.13)},

                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.EUR, CurrencyCode.GPB), 1.14},
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.GPB, CurrencyCode.EUR), (1/1.14)},

                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.EUR, CurrencyCode.AUD), 1.15},
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.AUD, CurrencyCode.EUR), (1/1.15)},

                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.GPB, CurrencyCode.AUD), 1.16},
                { new Tuple<CurrencyCode, CurrencyCode>(CurrencyCode.AUD, CurrencyCode.GPB), (1/1.16)},
            };

        public static ConversionRate Create(CurrencyCode fromCode, CurrencyCode toCode)
        {
            rates.TryGetValue(new Tuple<CurrencyCode, CurrencyCode>(fromCode, toCode), out double rate);

            var conversionRate = new ConversionRate(fromCode, toCode, rate);

            return conversionRate;
        }

    }
}
