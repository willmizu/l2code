using L2code.Domain.Models;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace L2code.Domain.Request
{
    [DataContract]
    public class OrderRequest
    {
        [JsonPropertyName("pedidos")]
        public List<Order> Orders { get; set; }
    }
}