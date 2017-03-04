using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.DAO {
    public abstract class Database {

        public string ConnectionString;

        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection conn);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);
    }
}
