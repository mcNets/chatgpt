using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChatGpt;

internal class OpenAIService : IOpenAIService
{
    public async Task<CompletionResult> SendMessageAsync(CompletionModel question, string url, string apiKey)
    {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var options = new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            IgnoreReadOnlyProperties = true
        };

        var completionResult = new CompletionResult();

        try
        {
            var requestBody = JsonSerializer.Serialize(question, options);
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, content);

            completionResult.StatusCode = response.StatusCode;

            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode == false)
            {
                completionResult.Success = false;
                if (responseBody != null)
                {
                    completionResult.ErrorModel = JsonSerializer.Deserialize<CompletionErrorModel>(responseBody, options);
                }
            }
            else
            {
                completionResult.Success = true;
                completionResult.SuccessModel = JsonSerializer.Deserialize<CompletionSuccessModel>(responseBody, options);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"ERROR: {e.Message}");
            completionResult.Success = false;
        }

        return completionResult;
    }
}
