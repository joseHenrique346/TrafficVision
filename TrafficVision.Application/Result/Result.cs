namespace TrafficVision.Application;

public sealed class Result<TContent>
{
    public bool IsSuccess { get; private set; }
    public TContent Content { get; private set; }
    public List<string> ListMessageErrors { get; private set; } = [];

    public Result() { }

    public void Failure(string message)
    {
        IsSuccess = false;
        ListMessageErrors.Add(message);
    }

    public Result<TContent> Success(TContent content)
    {
        IsSuccess = true;
        Content = content;
        return this;
    }

    public Result<TContent> ExternalError(string message)
    {
        IsSuccess = false;
        ListMessageErrors.Add(message);
        return this;
    }

    public Result<TContent> InternalError(string message)
    {
        IsSuccess = false;
        ListMessageErrors.Add(message);
        return this;
    }

    public static Result<TContent> FailureFromList(List<string> errors)
    {
        var result = new Result<TContent>();
        result.ListMessageErrors.AddRange(errors);
        result.IsSuccess = false;
        return result;
    }

}
