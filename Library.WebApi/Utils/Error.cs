namespace Library.WebApi.Utils;

public sealed class Error
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = null!;

    public override string ToString()
        => JsonSerializer.Serialize(this);
}