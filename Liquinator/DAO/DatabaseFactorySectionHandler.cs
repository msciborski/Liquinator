using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.DAO {
    /// <summary>
    /// Class DataBaseFactorySectionHandler take configuartion section and take care of it. It's sealed, cuz we don't want to let inhertiance
    /// Dzięki tej klasie, refleksja jest możliwa. Nie trzeba robić tysiąca ifów, switch etc. Bo w clasie Database, pobierzemy sobie DataBaseFactorySectionConfiguarion z app.config i odtworzymy sobie obiekt w czasie runtime. 
    /// </summary>
    public sealed class DatabaseFactorySectionHandler : ConfigurationSection {
        [ConfigurationProperty("Name")]
        public string Name {
            get { return (string)base["Name"]; }
        }

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName {
            get { return (string)base["ConnectionStringName"]; }
        }

        public string ConnectionString {
            get {
                try {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                } catch (Exception e) {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found in app.config. " + e.Message);
                }
            }
        }
    }
}
