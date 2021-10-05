using FluentValidation;
using Softplan.Domain.Dto.Product;

namespace Softplan.Domain.Validations.Product
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("O preenchimento da descrição é obrigatório.")
                .Length(0, 50).WithMessage("O tamanho máximo da descrição é de 50 caracteres.");

            RuleFor(x => x.CostPrice).NotNull().WithMessage("Informe o valor do produto.")
                .GreaterThan(0).WithMessage("O preenchimento do preço de custo é obrigatório.");            

            RuleFor(x => x.IdCategory).NotNull().Must(IsValidateCategory).WithMessage("O preenchimento da categoria é obrigatório.");
        }

        private bool IsValidateCategory(ProductCreateDto productCreateDto, int a)
        {
            if (productCreateDto == null || productCreateDto.Description.ToUpper().Contains("SOFTPLAYER"))
                return true;

            if(productCreateDto.IdCategory == 0)
                return false;

            return true;
        }
    }
}