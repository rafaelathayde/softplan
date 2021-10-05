using AutoMapper;
using Moq;
using Softplan.Aplication.Service;
using Softplan.Domain.Dto.Category;
using Softplan.Domain.Dto.Product;
using Softplan.Domain.Entities;
using Softplan.Domain.Enum;
using Softplan.Domain.Interfaces.Repositories;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Notification;
using SoftPlan.Tests.Map;
using SoftPlan.Tests.Repositories;
using System.Linq;
using Xunit;


namespace SoftPlan.Tests
{
    public class ProductTests
    {
        private Mock<IProductRepository> mockIProductRepository = new Mock<IProductRepository>();        
        private Mock<IPriceCalculationService> mockIPriceCalculationService = new Mock<IPriceCalculationService>();
        private Mock<ICategoryRepository> mockICategoryRepository = new Mock<ICategoryRepository>();
        private NotificationContext notificationContext;

        public ProductTests()
        {
            new AutomapperTests();
            notificationContext = new NotificationContext();
        }

        [Fact]
        public async void Produto_Cadastrar_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 1,
                Description = "Teste",
                CostPrice = 100
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);           

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            Assert.NotNull(_result);
            Assert.Equal("O produto foi salvo com sucesso", _result.Message);
        }

        [Fact]
        public async void Produto_Cadastrar_Softplayer_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 1,
                Description = "Teste Softplayer",
                CostPrice = 100
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            Assert.NotNull(_result);
            Assert.Equal((int)CategoryEnum.Softplan, ((ProductEntity)_result.Data).IdCategory);
            Assert.Equal("O produto foi salvo com sucesso", _result.Message);
        }

        [Fact]
        public async void Produto_Cadastrar_Sem_descricao_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 1,
                Description = string.Empty,
                CostPrice = 100
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            var _notificacao = notificationContext.Notifications.Where(a => a.Message == "O preenchimento da descrição é obrigatório.").FirstOrDefault();

            Assert.NotNull(_notificacao);
            Assert.Equal("O preenchimento da descrição é obrigatório.", _notificacao.Message);
        }

        [Fact]
        public async void Produto_Cadastrar_descricao_maior50_caracteres_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 1,
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                CostPrice = 100
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            var _notificacao = notificationContext.Notifications.Where(a => a.Message == "O tamanho máximo da descrição é de 50 caracteres.").FirstOrDefault();

            Assert.NotNull(_notificacao);
            Assert.Equal("O tamanho máximo da descrição é de 50 caracteres.", _notificacao.Message);
        }

        [Fact]
        public async void Produto_Cadastrar_custo_menor_igual_zero_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 1,
                Description = "Produto Novo Valor Zero.",
                CostPrice = 0
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            var _notificacao = notificationContext.Notifications.Where(a => a.Message == "O preenchimento do preço de custo é obrigatório.").FirstOrDefault();

            Assert.NotNull(_notificacao);
            Assert.Equal("O preenchimento do preço de custo é obrigatório.", _notificacao.Message);
        }

        [Fact]
        public async void Produto_Cadastrar_Softplayer_sem_categoria_Post()
        {
            var productCreateDto = new ProductCreateDto()
            {
                IdCategory = 0,
                Description = "Teste Softplayer",
                CostPrice = 100
            };

            var _categoryService = new CategoryService(AutomapperTests._mapper, new FakeCategoryRepository());

            var _priceCalculationService = new PriceCalculationService(_categoryService);

            mockIProductRepository.Setup(p => p.Insert(It.IsAny<ProductEntity>())).Verifiable();

            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, _priceCalculationService);

            var _result = await productService.Create(productCreateDto);

            Assert.NotNull(_result);
            Assert.Equal((int)CategoryEnum.Softplan, ((ProductEntity)_result.Data).IdCategory);
            Assert.Equal("O produto foi salvo com sucesso", _result.Message);

        }
        [Fact]
        public async void Produto_Sem_Categoria_Post()
        {
            var productCreateDto = new ProductCreateDto() {
                IdCategory = 0,
                Description = "Teste",
                CostPrice = 100
            };

            //mockIProductRepository.Setup(p => p.Insert(productCreateDto)).ReturnsAsync(productEntity);
            ProductService productService = new ProductService(AutomapperTests._mapper, mockIProductRepository.Object, notificationContext, mockIPriceCalculationService.Object);

            await productService.Create(productCreateDto);
            var _notificacao = notificationContext.Notifications.Where(a => a.Message == "O preenchimento da categoria é obrigatório.").FirstOrDefault();

            Assert.NotNull(_notificacao);
            Assert.Equal("O preenchimento da categoria é obrigatório.", _notificacao.Message);
        }

    }
}
