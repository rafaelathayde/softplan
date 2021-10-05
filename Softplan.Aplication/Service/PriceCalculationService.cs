using Softplan.Domain.Dto.PriceCalculation;
using Softplan.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Softplan.Aplication.Service
{
    public class PriceCalculationService : IPriceCalculationService
    {
        private readonly ICategoryService _categoryService;
        
        public PriceCalculationService(ICategoryService CategoryService) => 
            _categoryService = CategoryService;           
        

        public async Task<ReturnPriceCalculationDto> Calculate(PriceCalculationDto priceCalculationDto)
        {
            var returnPrice = new ReturnPriceCalculationDto() { Price = 0 };
            if (priceCalculationDto.Price <= 0)            
                return returnPrice;
             
            var _category = await _categoryService.Get(priceCalculationDto.IdCategory);

            returnPrice.Price = Convert.ToDouble(_category.ProfitMargin * priceCalculationDto.Price);

            return returnPrice;
        }
    }
}
