using GeeksDirectory.SharedTypes.Interfaces;

namespace GeeksDirectory.SharedTypes.Classes
{
    public class ModelValidationError : IErrorDetail
    {
        public string Message { get; set; }

        public string Target { get; set; }

        public ModelValidationError(string message, string target)
        {
            this.Message = message;
            this.Target = target;
        }
    }
}
