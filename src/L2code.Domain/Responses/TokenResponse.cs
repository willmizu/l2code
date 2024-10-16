using System.Text.Json.Serialization;

namespace L2code.Domain.Responses
{
    public class TokenResponse
    {
        public TokenResponse(int statusCode, string token = "")
        {
            StatusCode = statusCode;
            Token = token;
        }

        public string Token { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }
    }
}