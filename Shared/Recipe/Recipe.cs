using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public class RecipeItem
    {
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string ImageUrl { get; set; }
        public Type Type { get; set; }
        public IEnumerable<(int number, Step step)> Steps { get; set; } = new List<(int, Step)>();
        public IEnumerable<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public bool HasAdditionalInformation => !string.IsNullOrEmpty(Introduction) || Ingredients.Any();
    }
}
