using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public class Ingredient
    {
        public string Title { get; set; }
        public decimal? Amount { get; set; }
        public string UnitOfMeasure { get; set; }
        public string AdditionalNotes { get; set; }

        [JsonIgnore]
        public bool IsValid { get; set; } = true;
        public void SetIsValid() => IsValid = !string.IsNullOrEmpty(Title);
    }
}
