namespace Core.Exceptions.Auth;

public class InvalidLoginException: Exception
{
    public InvalidLoginException(): base("Invalid email or password")
    {
    }
}