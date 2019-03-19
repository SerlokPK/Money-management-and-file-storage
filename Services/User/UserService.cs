using Models.User;
using Services.Interface;
using System;
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
                if (string.IsNullOrEmpty(password))
                {
                    return context.Users.Any(u => u.Email == email);
                }
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
                        UserId = x.UserId,
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

        public bool ValidateRegistrationUser(Models.User.User user)
        {
            if (!CheckIfUserExist(user.Email, null))
            {
                using (var context = GetContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            int userId = context.Users.Any() ? context.Users.Max(x => x.UserId) + 1 : 1;
                            context.Users.Add(new DataBase.User
                            {
                                UserId = userId,
                                Email = user.Email,
                                Lastname = user.LastName,
                                Name = user.FirstName,
                                Password = user.Password,
                            });
                            context.SaveChanges();

                            context.Regulars.Add(new DataBase.Regular
                            {
                                UserId = userId,
                            });

                            context.SaveChanges();

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                        }
                    }
                }
                
                CurrentUser = user;
                return true;
            }
            return false;
        }

        public Models.User.User GetCurrentUser()
        {
            return CurrentUser;
        }

        public void UpdateUserDetails(Models.User.User user)
        {
            using (var context = GetContext())
            {
                var userToUpdate = context.Users.Where(x => x.Email == user.Email).Single();
                userToUpdate.Name = user.FirstName;
                userToUpdate.Lastname = user.LastName;
                userToUpdate.Password = user.Password;
                context.SaveChanges();
            }
        }
    }
}
