using System.Text.Json.Serialization;

namespace ChatGpt;

internal class CompletionSuccessModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("choices")]
    public CompletionChoice[]? Choices { get; set; }

    [JsonPropertyName("usage")]
    public CompletionUsage? Usage { get; set; }
}

public class CompletionUsage
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")] 
    public int CompletionTokens { get; set; }

    [JsonPropertyName("total_tokens")] 
    public int TotalTokens { get; set; }
}

public class CompletionChoice
{
    [JsonPropertyName("text")] 
    public string? Text { get; set; }

    [JsonPropertyName("index")] 
    public int Index { get; set; }

    [JsonPropertyName("logprobs")] 
    public object? LogProbs { get; set; }

    [JsonPropertyName("finish_reason")] 
    public string? FinishReason { get; set; }
}
