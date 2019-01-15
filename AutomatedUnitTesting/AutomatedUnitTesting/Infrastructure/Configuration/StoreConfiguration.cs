using AutomatedUnitTesting.Entities;
using System.Data.Entity.ModelConfiguration;

namespace AutomatedUnitTesting.Infrastructure.Configuration
{
    class StoreConfiguration : EntityTypeConfiguration<Store>
    {
        public StoreConfiguration()
        {
            ToTable("Store");

            HasKey(p => p.ID);
            Property(p => p.Alias).IsRequired();
            
        }
    }
}
