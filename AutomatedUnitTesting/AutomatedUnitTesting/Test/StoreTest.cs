using AutomatedUnitTesting.Entities;
using AutomatedUnitTesting.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace AutomatedUnitTesting.Test
{
    /// <summary>
    /// Summary description for StoreTest
    /// </summary>
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void AddStoreTest()
        {
            TestDBContext context = new TestDBContext();

            var dbSet = context.Set<Store>();

            dbSet.Add(new Store
            {
                Alias = "Kakariko",
                ID = Guid.NewGuid()
            });

            context.SaveChanges();

            var store = dbSet.Where(s => s.Alias == "Kakariko").FirstOrDefault();

            Assert.IsTrue(store != null);
        }
    }
}
