using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace AutomatedUnitTesting.Test
{
    public class TestDatabase
    {
        private const string LocalDbMaster = @"Data Source=(LocalDB)\v11.0;Initial Catalog=master;Integrated Security=True";

        private readonly string _databaseName;

        public TestDatabase(string databaseName)
        {
            _databaseName = databaseName;
        }

        public void CreateDatabase(bool forceCleanup = false)
        {
            if (!forceCleanup)
            {
                var isDetached = DetachDatabase();

                if (!isDetached)
                    return; //reuse database
            }            

            var fileName = CleanupDatabase();

            using (var connection = new SqlConnection(LocalDbMaster))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = string.Format("CREATE DATABASE {0} ON (NAME = N'{0}', FILENAME = '{1}.mdf')", _databaseName, fileName);
                cmd.ExecuteNonQuery();
            }
        }

        private string CleanupDatabase()
        {
            var fileName = DatabaseFilePath();

            try
            {
                if (File.Exists(fileName + ".mdf")) File.Delete(fileName + ".mdf");
                if (File.Exists(fileName + "_log.ldf")) File.Delete(fileName + "_log.ldf");
            }
            catch
            {
                Console.WriteLine("Could not delete the files (open in Visual Studio?)");
            }

            return fileName;
        }
        private bool DetachDatabase()
        {

            using (var connection = new SqlConnection(LocalDbMaster))
            {
                connection.Open();

                var cmd = connection.CreateCommand();
                cmd.CommandText = String.Format("exec sp_detach_db '{0}'", _databaseName);

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not detach");
                    return false;
                }
            }
        }
        private string DatabaseFilePath()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _databaseName);
        }    
    }
}
