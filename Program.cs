using Microsoft.Extensions.Configuration;

namespace ChatGpt;

internal class Program {

    static async Task Main(string[] args) {

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var service = new OpenAIService();

        while (true) {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.Write("Enter question: ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            var question = Console.ReadLine();
            if (question?.ToLower() == "exit")
                return;

            CompletionModel message = new CompletionModel();
            message.Prompt = question;
            message.Temperature = 0.8;
            message.MaxTokens = 1000;

            var url = config["OpenAi:Url"];
            if (string.IsNullOrEmpty(url)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("URL cannot have a null value.");
                return;
            }

            var apikey = config["OpenAi:ApiKey"];
            if (string.IsNullOrEmpty(apikey)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ApiKey missing");
                return;
            }

            var result = await service.SendMessageAsync(message, url, apikey);

            if (result.Success
                && result.SuccessModel != null
                && result.SuccessModel.Choices?.Count() > 0
                ) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Tokens:  {result.SuccessModel.Usage?.CompletionTokens}");
                Console.WriteLine(result.SuccessModel.Choices[0].Text);
            }
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: Status={result.StatusCode}");
            }
        }
    }
}