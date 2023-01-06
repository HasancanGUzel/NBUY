using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class Idd
    {
        [JsonPropertyName("root")]
        public string Root { get; set; }

        [JsonPropertyName("suffixes")]
        public string[] Suffixes { get; set; }
    }
}