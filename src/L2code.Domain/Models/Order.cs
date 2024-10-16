using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace L2code.Domain.Models
{
    [DataContract]
    public class Order
    {
        [JsonPropertyName("pedido_id")]
        public int OrderId { get; set; }

        [JsonPropertyName("produtos")]
        public List<Product> Products { get; set; }
    }
}