using CurrencyConverter.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models.Audit
{
    public interface IConversionLogRepositoryGet : IRepositoryGet<ConversionLog>
    {

    }

    public interface IConversionLogRepositoryModify : IRepositoryModify<ConversionLog>
    {

    }
    public class ConversionLogRepository : Repository<ConversionLog>, IConversionLogRepositoryGet, IConversionLogRepositoryModify
    {
        public ConversionLogRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

    }
}
