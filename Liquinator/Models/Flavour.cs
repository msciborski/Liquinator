using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.Models {
    public class Flavour {
        public int FlavourId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Shop { get; set; }
        public double? Amount { get; set; }

        public string Descriptor {
            get { return Name + "(" + Company + ")"; }
        }

        #region Constructors

        public Flavour() {

        }
        public Flavour(string name, string company, string shop, double? amount) {
            Name = name;
            Company = company;
            Shop = shop;
            Amount = amount;
        }
        public Flavour(int Id, string name, string company, string shop, double? amount) {
            Name = name;
            Company = company;
            Shop = shop;
            FlavourId = Id;
            Amount = amount;
        }

        public Flavour(string name) {

        }

        #endregion

    }
}
