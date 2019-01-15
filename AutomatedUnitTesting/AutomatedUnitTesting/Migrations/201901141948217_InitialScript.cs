namespace AutomatedUnitTesting.Migrations
{
    using System;
    using System.Configuration;
    using System.Data.Entity.Migrations;
    using System.IO;

    public partial class InitialScript : DbMigration
    {
        public override void Up()
        {
            string path = ConfigurationManager.AppSettings["ScriptPath"] ?? string.Empty;
            DirectoryInfo d = new DirectoryInfo(path);
            
            foreach (var file in d.GetFiles("*.sql"))
            {
                SqlFile(file.FullName);
            }
        }
        
        public override void Down()
        {
        }
    }
}
