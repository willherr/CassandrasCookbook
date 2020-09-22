using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        [JsonIgnore]
        public int? PrepTimeMinutes => PrepTime % 60 > 0 ? PrepTime % 60 : null;
        [JsonIgnore]
        public int? PrepTimeHours => PrepTime / 60 > 0 ? PrepTime / 60 : null;
        [JsonIgnore]
        public int? TotalTimeMinutes => TotalTime % 60 > 0 ? TotalTime % 60 : null;
        [JsonIgnore]
        public int? TotalTimeHours => TotalTime / 60 > 0 ? TotalTime / 60 : null;
        [JsonIgnore]
        public bool HasAdditionalInformation => !string.IsNullOrEmpty(Introduction) || Ingredients.Any();
        [JsonIgnore]
        public bool IsValid => 
            !string.IsNullOrEmpty(Title) 
            && !string.IsNullOrEmpty(ImageUrl) 
            && PrepTime.HasValue
            && TotalTime.HasValue
            && Servings.HasValue
            && Type != Type.All
            && (!Steps.Any() || Steps.All(step => step.IsValid))
            && (!Ingredients.Any() || Ingredients.All(ingredient => ingredient.IsValid));
    }
}
