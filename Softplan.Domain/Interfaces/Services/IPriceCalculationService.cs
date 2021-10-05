using Softplan.Domain.Dto.PriceCalculation;
using System;
using System.Threading.Tasks;

namespace Softplan.Domain.Interfaces.Services
{
    public interface IPriceCalculationService
    {
        Task<ReturnPriceCalculationDto> Calculate(PriceCalculationDto priceCalculationDto);
    }
}
