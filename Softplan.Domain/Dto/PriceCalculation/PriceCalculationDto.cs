namespace Softplan.Domain.Dto.PriceCalculation
{
    public class PriceCalculationDto
    {
        public PriceCalculationDto() { }
        public PriceCalculationDto(int idCategory, double price) {
            IdCategory = idCategory;
            Price = price;
        }

        public int IdCategory { get; set; }
        public double Price { get; set; }
    }
}
