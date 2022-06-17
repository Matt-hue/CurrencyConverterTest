using CurrencyConverter.Models.Audit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurrencyConverter.Controllers
{
    public class Audit : Controller
    {
        private readonly IConversionLogRepositoryGet _conversionLogRepository;

        public Audit(IConversionLogRepositoryGet repositoryGet)
        {
            _conversionLogRepository = repositoryGet;
        }

        public async Task<IActionResult> ConversionLog(ConversionLogViewModel model)
        {
            Expression<Func<Data.ConversionLog, bool>> filter = log => model.Start.Ticks <= log.Created.Ticks && log.Created.Ticks <= model.End.Ticks;

            model.ConversionLogs = await _conversionLogRepository.GetAllAsync(filter);
            return View(model);
        }
    }
}
