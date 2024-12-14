namespace MVCDemo.Data.ViewMoel;

public class ErrorViewModel
{
    public string? RequestId
    {
        get; set;
    }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
