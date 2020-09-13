using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public class Ingredient
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public string AdditionalNotes { get; set; }
    }
}
