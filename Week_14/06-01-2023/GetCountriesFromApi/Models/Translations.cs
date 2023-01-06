using System.Text.Json.Serialization;

namespace GetCountriesFromApi.Models
{
    public class Translation
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]

        public string Official { get; set; }
    }

    public class TranslationLanguage
    {
        public static readonly string Arabic = "arb";
        public static readonly string Breton = "bre";
        public static readonly string Czech = "ces";
        public static readonly string Welsh = "cym";
        public static readonly string Germany = "deu";
        public static readonly string Estonian = "est";
        public static readonly string Finnish = "fin";
        public static readonly string French = "fra";
        public static readonly string Crotian = "hrv";
        public static readonly string Hungarian = "hun";
        public static readonly string Italian = "ita";
        public static readonly string Japanase = "jpn";
        public static readonly string Korean = "kor";
        public static readonly string Dutch = "nld";
        public static readonly string Persian = "per";
        public static readonly string Polish = "pol";
        public static readonly string Russian = "rus";
        public static readonly string Slovak = "slk";
        public static readonly string Spanish = "spa";
        public static readonly string Swedish = "swe";
        public static readonly string Turkish = "tur";
        public static readonly string Urdu = "urd";
        public static readonly string Chinese = "zho";
        public static readonly string English = "eng";
    }
}