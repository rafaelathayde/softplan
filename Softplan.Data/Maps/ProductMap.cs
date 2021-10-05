using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softplan.Domain.Entities;

namespace Softplan.Data.Maps
{
    public class ProductMap : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("product");

            builder
               .Property(entity => entity.Id)
               .HasColumnName("idproduct")
               .IsRequired();

            builder
               .Property(entity => entity.IdCategory)
               .HasColumnName("idcategory")
               .IsRequired();

            builder
               .Property(entity => entity.Description)
               .HasColumnName("description")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder
               .Property(entity => entity.CostPrice)
               .HasColumnName("cost_price")
               .HasColumnType("float")
               .IsRequired();

            builder
               .Property(entity => entity.SalePrice)
               .HasColumnName("sale_price")
               .HasColumnType("float")
               .IsRequired();

            builder
              .Property(entity => entity.CreateAt)
              .HasColumnName("createat")
              .HasColumnType("datetime")
              .IsRequired();

            builder.HasOne(e => e.Category)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction)
               .HasForeignKey(e => e.IdCategory);
        }
    }
}