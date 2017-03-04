using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.Models {
    public class Recipe {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int RecipeId { get; set; }

        public List<RecipeFlavour> RecipeElements;


        public Recipe(string recipeName) {
            RecipeElements = new List<RecipeFlavour>();
            Date = DateTime.Now;
            Name = recipeName;
        }
        public Recipe(string recipeName, DateTime date) {
            RecipeElements = new List<RecipeFlavour>();
            Date = date;
            Name = recipeName;
        }
    }
}
