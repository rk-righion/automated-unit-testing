using AutomatedUnitTesting.Infrastructure.Configuration;
using System.Data.Entity;

namespace AutomatedUnitTesting.Infrastructure
{
    public class TestDBContext : DbContext
    {
        public TestDBContext()
            : base("TestDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StoreConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new SkuConfiguration());
        }
    }
}
