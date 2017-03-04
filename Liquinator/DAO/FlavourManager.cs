using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquinator.Models;

namespace Liquinator.DAO {
    public class FlavourManager : DataWorker {
        public static List<Flavour> GetFlavours() {
            List<Flavour> flavours = new List<Flavour>();
            using (IDbConnection conn = Database.CreateOpenConnection()) {
                using (IDbCommand command = Database.CreateCommand("SELECT * FROM Flavours", conn)) {
                    using (IDataReader reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            int flavourId = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string company = reader.GetString(2);
                            string shop = reader.GetString(3);
                            double? amount = reader.GetDouble(4);
                            Flavour flavour = new Flavour(flavourId, name, company, shop, amount);
                            flavours.Add(flavour);
                        }

                    }
                }
            }
            return flavours;
        }
    }
}
