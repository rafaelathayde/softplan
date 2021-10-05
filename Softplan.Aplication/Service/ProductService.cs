using AutoMapper;
using Softplan.Domain.Command;
using Softplan.Domain.Dto.PriceCalculation;
using Softplan.Domain.Dto.Product;
using Softplan.Domain.Entities;
using Softplan.Domain.Interfaces.Repositories;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Notification;
using Softplan.Domain.Validations.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Aplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IPriceCalculationService _priceCalculationService;
        private readonly NotificationContext _domainNotificationHandler;
        public ProductService(IMapper mapper, IProductRepository productRepository, 
            NotificationContext domainNotificationHandler,
            IPriceCalculationService priceCalculationService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _domainNotificationHandler = domainNotificationHandler;
            _priceCalculationService = priceCalculationService;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProductDto>>(await _productRepository.SelectAll());
        }

        public async Task<ProductDto> Get(int id)
        {
            return _mapper.Map<ProductDto>(await _productRepository.SelectById(id));
        }

        public async Task<GenericResult> Create(ProductCreateDto productCreateDto)
        {
            var validatorProduct = new ProductCreateDtoValidator().Validate(productCreateDto);            

            if (!validatorProduct.IsValid)
            {   
                _domainNotificationHandler.AddNotifications(validatorProduct.Errors.Select(e => new Notification(e.PropertyName, e.ErrorMessage)).ToList());
                return null;
            }
           
            var _product = new ProductEntity(productCreateDto.IdCategory, productCreateDto.Description, productCreateDto.CostPrice);

            var ReturnPriceCalculationDto = await _priceCalculationService.Calculate(new PriceCalculationDto(productCreateDto.IdCategory, productCreateDto.CostPrice));

            _product.ChangeSalePrice(ReturnPriceCalculationDto.Price);

            await _productRepository.Insert(_product);

            return new GenericResult(true, "O produto foi salvo com sucesso", _product);
        }
    }
}
