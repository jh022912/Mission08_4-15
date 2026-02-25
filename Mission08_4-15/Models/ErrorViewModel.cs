namespace Mission08_4_15.Models;

/// <summary>
/// View model for the error page displayed when an unhandled exception occurs.
/// Uses the standard ASP.NET Core error display pattern.
/// </summary>
public class ErrorViewModel
{
    // Unique identifier for the request (helps with debugging/support)
    public string? RequestId { get; set; }

    // Whether to display the RequestId to the user
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}