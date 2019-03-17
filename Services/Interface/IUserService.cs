namespace Services.Interface
{
    public interface IUserService
    {
        bool ValidateLogInUser(string email, string password);
    }
}
