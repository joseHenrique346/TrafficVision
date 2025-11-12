namespace TrafficVision.Application.Result;

public sealed class Result<TContent>
{
    public bool IsSuccess { get; private set; }
    public TContent Content { get; private set; }
    public List<string> ListMessageErrors { get; private set; } = [];

    public void Failure(string message)
    {
        IsSuccess = false;
        ListMessageErrors.Add(message);
    }

    public void Success(TContent content)
    {
        IsSuccess = true;
        Content = content;
    }
}
