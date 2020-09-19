using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public class RecipeItem
    {
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string ImageUrl { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Type Type { get; set; }
        public List<Step> Steps { get; set; } = new List<Step>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public int? PrepTime { get; set; }
        public int? TotalTime { get; set; }
        public int? Servings { get; set; }

        public bool HasAdditionalInformation => !string.IsNullOrEmpty(Introduction) || Ingredients.Any();
    }
}
