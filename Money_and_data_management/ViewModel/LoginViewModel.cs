using System;
using Common.Enums;
using Common.Helpers;
using Models.User;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IPageService pageService;
        private IUserService userService;
        private User user;

        public CommandHelper RegisterCommand { get; set; }
        public CommandHelper LogInCommand { get; set; }
        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public LoginViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            userService = SimpleDI.Instance.UserService;
            user = new User();

            RegisterCommand = new CommandHelper(RegisterAction);
            LogInCommand = new CommandHelper(LogInAction);
        }

        private void LogInAction()
        {
            User.Validate(EPages.LOG);
            if (User.IsValid && userService.ValidateLogInUser(User.Email,User.Password))
            {
                //pageService.ChangePage(EPages.REG); idi na glavni meni
            }
            else
            {
                User.ValidationErrors["Email"] = "User with this email doesn't exist.";
                User.ValidationPropertyChange();
            }
        }

        private void RegisterAction()
        {
            pageService.ChangePage(EPages.REG);
        }
    }
}
