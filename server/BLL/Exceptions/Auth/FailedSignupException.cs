namespace BLL.Exceptions.Auth;

public class FailedSignupException: Exception
{
    public FailedSignupException(string message): base($"Failed to sign you up: {message}")
    {
    }
}