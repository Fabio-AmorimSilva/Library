namespace Library.Core.Result;

public class ResultResponse<T>
{
    public T Data { get; protected init; } = default!;
    protected List<string>? Errors { get; } = [];

    protected ResultResponse()
    {
    }
}