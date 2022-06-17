using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Home
{
    public class IndexViewModel
    {
        [Display(Name = "From")]
        public CurrencyCode FromCode { get; set; } = CurrencyCode.USD;

        [Required]
        [Display(Name = "Amount")]
        [Range(0, double.MaxValue)]
        public double FromAmount { get; set; } = 1;

        public double ToAmount { get; set; }

        [Display(Name = "To")]
        public CurrencyCode ToCode { get; set; } = CurrencyCode.GPB;
    }

}
