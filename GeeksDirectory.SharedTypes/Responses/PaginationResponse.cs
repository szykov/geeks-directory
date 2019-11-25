namespace GeeksDirectory.SharedTypes.Responses
{
    public class PaginationResponse
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
