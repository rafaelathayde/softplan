namespace Softplan.Domain.Entities
{
    public class CategoryEntity : BaseEntity
    {   
        public CategoryEntity(int id, string description, double profitMargin)
        {
            Id = id;
            Description = description;
            ProfitMargin = profitMargin;
        }

        public string Description { get; private set; }
        public double ProfitMargin { get; private set; }
    }
}
