using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace solution_stack_shared.models
{
    public class Review
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string ImageUrl { get; set; } = string.Empty;
        public int Stars { get; set; }
    }
}
