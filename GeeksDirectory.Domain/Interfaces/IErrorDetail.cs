namespace GeeksDirectory.Domain.Interfaces
{
    public interface IErrorDetail
    {
        string Message { get; set; }

        string? Target { get; set; }
    }
}
