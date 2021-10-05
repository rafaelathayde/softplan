using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.Domain.Entities;

namespace Softplan.Data.Maps
{
    class CategoryMap : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category");

            builder.HasKey(prop => prop.Id);

           builder
          .Property(entity => entity.Id)
          .HasColumnName("idcategory")
          .HasColumnType("int")
          .IsRequired();

           builder
          .Property(entity => entity.Description)
          .HasColumnName("description")
          .HasColumnType("varchar(50)")
          .IsRequired();

            builder
           .Property(entity => entity.ProfitMargin)
           .HasColumnName("profit_margin")
           .HasColumnType("float")
           .IsRequired();

            builder.HasData(new CategoryEntity(1,"Brinquedos", 0.25));
            builder.HasData(new CategoryEntity(2,"Bebidas", 0.30));
            builder.HasData(new CategoryEntity(3,"Informática", 0.10));
            builder.HasData(new CategoryEntity(4,"Softplan", 0.05));
            builder.HasData(new CategoryEntity(5,"Toda e qualquer outra categoria informada", 0.15));            
        }
    }
}