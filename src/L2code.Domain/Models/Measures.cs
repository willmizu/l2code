using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace L2code.Domain.Models
{
    [DataContract]
    public class Measures
    {
        [JsonPropertyName("altura")]
        public int Height { get; set; }

        [JsonPropertyName("largura")]
        public int Width { get; set; }

        [JsonPropertyName("comprimento")]
        public int Length { get; set; }

        public decimal Volume()
        {
            return Length * Width * Height;
        }
    }
}