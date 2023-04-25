using System.Text.Json.Serialization;

namespace ChatGpt;

internal class CompletionErrorModel {
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("param")]
    public object? Param { get; set; }

    [JsonPropertyName("code")]
    public object? Code { get; set; }
}
