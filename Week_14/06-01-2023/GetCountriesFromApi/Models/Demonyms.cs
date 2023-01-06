using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class Demonyms
    {
        [JsonPropertyName("fra")]
        public Demonym? FrenchDemonym { get; set; }

        [JsonPropertyName("eng")]
        public Demonym? EnglishDemonym { get; set; }

    }

    public class Demonym
    {
        [JsonPropertyName("f")]
        public string F { get; set; }

        [JsonPropertyName("m")]
        public string M { get; set; }
    }
}