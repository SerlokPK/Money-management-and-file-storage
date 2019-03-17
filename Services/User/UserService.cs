using Services.Interface;
using System.Linq;

namespace Services.User
{
    public class UserService : BaseService, IUserService
    {
        public Models.User.User CurrentUser { get; set; }
        private bool CheckIfUserExist(string email, string password)
        {
            using (var context = GetContext())
            {
                return context.Users.Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool ValidateLogInUser(string email, string password)
        {
            if (CheckIfUserExist(email, password))
            {
                using (var context = GetContext())
                {
                    CurrentUser = context.Users.Where(x => x.Email == email && x.Password == password).Select(x => new Models.User.User
                    {
                        Email = x.Email,
                        FirstName = x.Name,
                        LastName = x.Lastname,
                        Password = x.Password,
                    }).Single();
                }
                return true;
            }
            return false;
        }
    }
}
