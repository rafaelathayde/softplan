using System;

namespace Softplan.Domain.Dto.Product
{
    public class ProductDto
    {
        public int IdCategory { get; set; }
        public string Description { get; set; }
        public double CostPrice { get; set; }
        public double SalePrice { get; set; }
        public DateTime CreateAt { get; set; }
        public string CategoryDescription { get; set; }
    }
}
