using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Dto.PriceCalculation;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Notification;
using System.Threading.Tasks;

namespace Softplan.Api.Controllers
{
    [Route("api/PriceCalculation")]
    public class PriceCalculationController : BaseController
    {   
        private readonly IPriceCalculationService _priceCalculationService;
        public PriceCalculationController(NotificationContext notificationContext, IPriceCalculationService priceCalculationService) : base(notificationContext) 
            => _priceCalculationService = priceCalculationService;

        [HttpGet("Calculation")]
        public async Task<IActionResult> CalculationAsync([FromQuery] PriceCalculationDto priceCalculationDto)
        {   
            return Result(await _priceCalculationService.Calculate(priceCalculationDto));
        }
    }
}
