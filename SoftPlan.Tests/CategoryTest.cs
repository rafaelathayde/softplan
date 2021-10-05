using Moq;
using Softplan.Aplication.Service;
using Softplan.Domain.Entities;
using Softplan.Domain.Interfaces.Repositories;
using SoftPlan.Tests.Map;
using SoftPlan.Tests.Repositories;
using Xunit;

namespace SoftPlan.Tests
{
    public class CategoryTest
    {   
        private Mock<ICategoryRepository> mockCategoryRepository = new Mock<ICategoryRepository>();

        public CategoryTest() {
            new AutomapperTests();
        }

        [Fact]
        public async void CategoryDefault()
        {
            var categoryDto = new CategoryEntity(5, "Toda e qualquer outra categoria informada", 0.15);

            CategoryService categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _result = await categoryService.Get(0);

            Assert.NotNull(_result);
            Assert.Equal(_result.Id, categoryDto.Id);
            Assert.Equal(_result.Description, categoryDto.Description);
            Assert.Equal(_result.ProfitMargin, categoryDto.ProfitMargin);
        }

        [Fact]        
        public async void Category()
        {
            var categoryDto = new CategoryEntity(3, "Toda e qualquer outra categoria informada", 0.15);
            
            mockCategoryRepository.Setup(p => p.SelectById(0)).ReturnsAsync(categoryDto);

            CategoryService categoryService = new CategoryService(AutomapperTests._mapper, mockCategoryRepository.Object);

            var _result = await categoryService.Get(3);

            Assert.Equal(3, categoryDto.Id);
        }
    }
}
