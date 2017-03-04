using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.DAO {
    public class DataWorker {
        private static Database _database = null;

        static DataWorker() {
            try {
                _database = DatabaseFactory.CreationDatabase();
            } catch (Exception e) {
                throw e;
            }
        }

        public static Database Database {
            get { return _database; }
        }
    }
}
