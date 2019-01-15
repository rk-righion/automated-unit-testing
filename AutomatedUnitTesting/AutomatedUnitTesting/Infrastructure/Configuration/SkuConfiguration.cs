using AutomatedUnitTesting.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutomatedUnitTesting.Infrastructure.Configuration
{
    class SkuConfiguration : EntityTypeConfiguration<Sku>
    {
        public SkuConfiguration()
        {
            ToTable("Sku");

            HasKey(p => p.ID);
            Property(p => p.PartNumber).IsRequired();
            Property(p => p.ListPrice).IsRequired();
            Property(p => p.FinalPrice).IsRequired();            
        }
    }
}
