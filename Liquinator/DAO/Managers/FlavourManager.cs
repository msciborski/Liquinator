using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Liquinator.Models;

namespace Liquinator.DAO.Managers {
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
        public static void AddFlavour(Flavour flavour) {
            using (IDbConnection conn = Database.CreateOpenConnection()) {
                using (
                    IDbCommand command =
                        Database.CreateCommand(
                            @"INSERT INTO Flavours VALUES (@name, @company, @shop, @amount); SELECT SCOPE_IDENTITY()",
                            conn)) {
                    command.Parameters.Add(Database.CreateParameter("name", flavour.Name));
                    command.Parameters.Add(Database.CreateParameter("company", flavour.Company));
                    command.Parameters.Add(Database.CreateParameter("shop", flavour.Shop));
                    command.Parameters.Add(Database.CreateParameter("amount", flavour.Amount));
                    var id = command.ExecuteScalar();
                    flavour.FlavourId = Int32.Parse(id.ToString());
                }
            }
        }
        public static void UpdateFlavour(Flavour flavour) {
            using (IDbConnection conn = Database.CreateOpenConnection()) {
                using (
                    IDbCommand command =
                        Database.CreateCommand(
                            "UPDATE Flavours SET Name = @name, Company = @company, Shop = @shop, Amount = @amount WHERE FlavourId = @id",
                            conn)) {
                    command.Parameters.Add(Database.CreateParameter("id", flavour.FlavourId));
                    command.Parameters.Add(Database.CreateParameter("name", flavour.Name));
                    command.Parameters.Add(Database.CreateParameter("company", flavour.Company));
                    command.Parameters.Add(Database.CreateParameter("shop", flavour.Shop));
                    command.Parameters.Add(Database.CreateParameter("amount", flavour.Amount));
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
