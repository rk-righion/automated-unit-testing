using AutomatedUnitTesting.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutomatedUnitTesting.Infrastructure.Configuration
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            ToTable("Product");

            HasKey(p => p.ID);
            Property(p => p.StoreID).IsRequired();
            Property(p => p.InternalCode).IsRequired();
            Property(p => p.Name).IsRequired();

            HasMany(p => p.Skus)
                .WithRequired()
                .HasForeignKey(p => p.ProductID);
        }
    }
}
