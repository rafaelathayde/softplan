using Softplan.Domain.Enum;
using System;

namespace Softplan.Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        public ProductEntity(int idCategory, string description, double costPrice)
        {
            IdCategory = (description.ToUpper().Contains("SOFTPLAYER") ? (int)CategoryEnum.Softplan : idCategory);
            Description = description;
            CostPrice = costPrice;            
            CreateAt = DateTime.Now;
        }

        public void ChangeSalePrice(double salePrice) => SalePrice  = CostPrice + salePrice;
        
        public int IdCategory { get; private set; }
        public string Description { get; private set; }
        public double CostPrice { get; private set; }
        public double SalePrice { get; private set; }        
        public DateTime CreateAt { get; private set; }
        public virtual CategoryEntity Category { get; private set; }
    }
}
