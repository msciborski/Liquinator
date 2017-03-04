using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.DAO {
    public sealed class DatabaseFactory {
        //DatabaseFactorSectionHandler get section name "DatabaseFactoryConfiguration", which exist in app.config
        public static DatabaseFactorySectionHandler SectionHandler =
            (DatabaseFactorySectionHandler)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

        private DatabaseFactory() {

        }

        /// <summary>
        /// returns type of defined database(in our case SQLDatabase.cs). ConstructInfo  
        /// </summary>
        /// <returns>Database Object</returns>
        public static Database CreationDatabase() {
            if (SectionHandler.Name.Length == 0) {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of app.config.");
            }
            try {
                //W naszym przypadku zostanie stworzone coś takiego: Database createdObject = 
                Type database = Type.GetType(SectionHandler.Name);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                Database createdObject = (Database)constructor.Invoke(null);
                createdObject.ConnectionString = SectionHandler.ConnectionString;
                return createdObject;
            } catch (Exception e) {
                throw new Exception("Error init database " + SectionHandler.Name + ". " + e.Message);
            }
        }
    }
}
