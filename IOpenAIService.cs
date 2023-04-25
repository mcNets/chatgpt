namespace ChatGpt
{
    internal interface IOpenAIService
    {
        Task<CompletionResult> SendMessageAsync(CompletionModel question, string url, string apiKey);
    }
}