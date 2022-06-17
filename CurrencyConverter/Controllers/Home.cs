using CurrencyConverter.Data;
using CurrencyConverter.Models;
using CurrencyConverter.Models.Audit;
using CurrencyConverter.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    public class Home : Controller
    {
        private readonly IConversionLogRepositoryModify _conversionLogRepository;

        public Home(IConversionLogRepositoryModify repositoryModify)
        {
            _conversionLogRepository = repositoryModify;
        }

        [HttpGet]
        public IActionResult Index(IndexViewModel model)
        {
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConvertCurrency([FromForm] IndexViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ConversionRate conversionRate = ConversionRateFactory.Create(viewModel.FromCode, viewModel.ToCode);

                Currency Currency = conversionRate.Convert(Math.Round(viewModel.FromAmount, 2));

                viewModel.ToAmount = Currency.Amount;

                var log = new ConversionLog(viewModel.FromCode, viewModel.FromAmount, viewModel.ToCode, viewModel.ToAmount, conversionRate.Rate);

                await _conversionLogRepository.AddAsync(log);
                await _conversionLogRepository.SaveAsync();

                return RedirectToAction(nameof(Index), viewModel);
            }

            return View(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
