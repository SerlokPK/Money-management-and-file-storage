namespace Services.Interface
{
    public interface IUserService
    {
        bool ValidateLogInUser(string email, string password);
        bool ValidateRegistrationUser(Models.User.User user);
        Models.User.User GetCurrentUser();
        void UpdateUserDetails(Models.User.User user);
    }
}
