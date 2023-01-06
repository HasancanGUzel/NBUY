using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class Flag
    {
        [JsonPropertyName("png")]
        public string Png { get; set; }

        [JsonPropertyName("svg")]

        public string Svg { get; set; }
    }
}
