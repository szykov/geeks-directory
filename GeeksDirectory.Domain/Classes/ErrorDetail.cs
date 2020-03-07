using GeeksDirectory.Domain.Interfaces;

namespace GeeksDirectory.Domain.Classes
{
    public class ErrorDetail : IErrorDetail
    {
        public string Message { get; set; }

        public string? Target { get; set; }

        public ErrorDetail(string message)
        {
            this.Message = message;
        }

        public ErrorDetail(string message, string target)
        {
            this.Message = message;
            this.Target = target;
        }
    }
}
