using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.DAO {
    public class SqlDatabase : Database {
        public override IDbConnection CreateConnection() {
            return new SqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand() {
            return new SqlCommand();
        }

        public override IDbConnection CreateOpenConnection() {
            SqlConnection connection = (SqlConnection)CreateConnection();
            connection.Open();
            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection conn) {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.Connection = (SqlConnection)conn;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue) {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}
