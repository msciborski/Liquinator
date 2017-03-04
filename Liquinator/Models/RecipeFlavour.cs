﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liquinator.Models {
    public class RecipeFlavour {
        public int RecipeId { get; set; }
        public Flavour Flavour { get; set; }
        public double? PercentageAmount { get; set; }

        public RecipeFlavour(Flavour flavour, double? percentageAmount) {
            Flavour = flavour;
            PercentageAmount = percentageAmount;
        }
    }
}
