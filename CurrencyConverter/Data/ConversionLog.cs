using CurrencyConverter.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Data
{
    public class ConversionLog
    {
        //parameterless constructor for EfCore
        protected ConversionLog() { }
        public ConversionLog(CurrencyCode fromCode, double fromAmount, CurrencyCode toCode, double toAmount, double rate)
        {
            Created = DateTime.UtcNow;
            FromCode = fromCode;
            FromAmount = fromAmount;
            ToCode = toCode;
            ToAmount = toAmount;
            Rate = rate;
        }

        public int Id { get; set; }
        public DateTime Created { get; protected set;  }

        public CurrencyCode FromCode { get; set; }
        public double FromAmount { get; set; }

        public CurrencyCode ToCode { get; set; }
        public double ToAmount { get; set; }

        public double Rate { get; set; }
    }
}
