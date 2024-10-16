using L2code.Domain.Models;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace L2code.Domain.Responses
{
    [DataContract]
    public class BoxResponse
    {
        [JsonIgnore]
        public Box Box { get; set; }

        [JsonPropertyName("caixa_id")]
        public string Name { get; set; }

        [JsonPropertyName("produtos")]
        public List<string> Products { get; set; } = new List<string>();

        public string Observacao { get; set; }
    }
}