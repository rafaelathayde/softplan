using AutoMapper;
using Softplan.Domain.Dto.Category;
using Softplan.Domain.Dto.Product;
using Softplan.Domain.Entities;

namespace Softplan.Domain.Maps
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<CategoryEntity, CategoryDto>();            
            CreateMap<ProductEntity, ProductDto>().ForMember(a => a.CategoryDescription, c => c.MapFrom( i => i.Category.Description));      
        }
    }
}
