namespace Services.Interface
{
    public interface IUserService
    {
        bool ValidateLogInUser(string email, string password);
        bool ValidateRegistrationUser(Models.User.User user);
    }
}
