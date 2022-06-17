using CurrencyConverter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Audit
{
    public class ConversionLogViewModel
    {
        public DateTime Start { get; set; } = DateTime.UtcNow.AddMinutes(-10);
        public DateTime End { get; set; } = DateTime.UtcNow.AddMinutes(10);

        public IEnumerable<ConversionLog> ConversionLogs { get; set; }
    }
}
