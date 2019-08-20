using GeeksDirectory.SharedTypes.Classes;

using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    public class ErrorResponse
    {
        public string Code { get; set; }

        public string Message { get; set; }

        public IEnumerable<ErrorException> Details { get; set; }
    }
}
