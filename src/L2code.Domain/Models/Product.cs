using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace L2code.Domain.Models
{
    [DataContract]
    public class Product
    {
        [JsonPropertyName("produto_id")]
        public string ProductId { get; set; }

        [JsonPropertyName("dimensões")]
        public Measures Measures { get; set; }
    }
}