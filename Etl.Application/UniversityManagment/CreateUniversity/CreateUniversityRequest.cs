using System.Text.Json.Serialization;

namespace Etl.Application.UniversityManagment.CreateUniversity
{
    public record CreateUniversityRequest
    {
        [JsonPropertyName("web_pages")]
        public List<string> WebPages { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }
}
