using Microsoft.AspNetCore.Mvc;
using Softplan.Domain.Dto.Product;
using Softplan.Domain.Interfaces.Services;
using Softplan.Domain.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Api.Controllers
{
    [Route("api/Product")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        public ProductController(NotificationContext notificationContext, IProductService productService) : base(notificationContext) => _productService = productService;

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            return Result(await _productService.GetAll());
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto productCreateDto)
        {   
            return Result(await _productService.Create(productCreateDto));
        }

    }
}
