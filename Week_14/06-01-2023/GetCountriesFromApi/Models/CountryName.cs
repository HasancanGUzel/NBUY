using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class CountryName:Translation
    {
        [JsonPropertyName("nativeName")]
        public Dictionary<string,Translation>? NativeName { get; set; }
    }
}