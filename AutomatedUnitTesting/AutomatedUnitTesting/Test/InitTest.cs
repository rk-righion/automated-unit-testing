using AutomatedUnitTesting.Infrastructure;
using AutomatedUnitTesting.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data.Entity;
using System.IO;

namespace AutomatedUnitTesting.Test
{
    [TestClass]
    public class InitTest
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Empty));

            //use this database file name (in current bin folder)
            var testDatabase = new TestDatabase("UnitTestDB");
            testDatabase.CreateDatabase();

            //if we're using Entity Framework Code First, run all the migrations.
            var migrate = new MigrateDatabaseToLatestVersion<TestDBContext, Configuration>();
            var dbContext = new TestDBContext();
            migrate.InitializeDatabase(dbContext);
        }

        [TestMethod]
        public void DbExistsTest()
        {
            try
            {
                TestDBContext context = new TestDBContext();

                Assert.IsTrue(context.Database.Exists());
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
    }
}
