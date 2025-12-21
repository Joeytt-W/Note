using System.Text.Json.Serialization;

namespace WebApp.Data
{
    /// <summary>
    /// api返回错误的响应
    /// </summary>
    public class ErrorResponse
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("errors")]
        public Dictionary<string,List<string>>? Errors { get; set; } 
    }
}
