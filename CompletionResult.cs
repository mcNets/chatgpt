using System.Net;

namespace ChatGpt
{
    internal class CompletionResult
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Unused;
        public CompletionSuccessModel? SuccessModel { get; set; }
        public CompletionErrorModel? ErrorModel { get; set; }
        public bool Success { get; set; } = false;
    }
}
