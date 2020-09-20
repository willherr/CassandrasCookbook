using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CassandrasCookbook.Shared.Recipe
{
    public class Step
    {
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
        public string Instructions { get; set; }

        [JsonIgnore]
        public bool IsValid { get; set; } = true;
        public void SetIsValid() => IsValid = !string.IsNullOrEmpty(Instructions);

    }
}
