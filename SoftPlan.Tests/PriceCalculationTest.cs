using AutoMapper;
using Moq;
using Softplan.Aplication.Service;
using Softplan.Domain.Dto.PriceCalculation;
using Softplan.Domain.Entities;
using Softplan.Domain.Interfaces.Repositories;
using Softplan.Domain.Interfaces.Services;
using SoftPlan.Tests.Map;
using Xunit;

namespace SoftPlan.Tests
{
    public class PriceCalculationTest
    {
        private Mock<ICategoryService> mockService = new Mock<ICategoryService>();
        private Mock<ICategoryRepository> mockCategoryRepository = new Mock<ICategoryRepository>();

        public PriceCalculationTest()
        {
            new AutomapperTests();
        }

        [Fact]
        public async void Calcular_Categoria()
        {
            var categoryDto = new CategoryEntity(1, "Toda e qualquer outra categoria informada", 0.15);

            mockCategoryRepository.Setup(p => p.SelectById(1)).ReturnsAsync(categoryDto);
            CategoryService categoryService = new CategoryService(AutomapperTests._mapper, mockCategoryRepository.Object);

            PriceCalculationService priceCalculationService = new PriceCalculationService(categoryService);
            
            var _priceCalculationDto = new PriceCalculationDto() { 
             IdCategory = 1,
             Price = 100
            };

            var _result = await priceCalculationService.Calculate(_priceCalculationDto);

            Assert.Equal(15, _result.Price);
           
        }

        [Fact]
        public async void Calcular_Categoria_Default()
        {
            var categoryDto = new CategoryEntity(5, "Toda e qualquer outra categoria informada", 0.15);
            mockCategoryRepository.Setup(p => p.SelectDefaultCategory()).ReturnsAsync(categoryDto);

            CategoryService categoryService = new CategoryService(AutomapperTests._mapper, mockCategoryRepository.Object);

            PriceCalculationService priceCalculationService = new PriceCalculationService(categoryService);

            var _priceCalculationDto = new PriceCalculationDto()
            {
                IdCategory = 1,
                Price = 100
            };

            var _result = await priceCalculationService.Calculate(_priceCalculationDto);

            Assert.Equal(15, _result.Price);

        }
    }
}
