using System;
using Common.Enums;
using Common.Helpers;
using Models.User;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class RegisterViewModel : BaseViewModel
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

        public RegisterViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            userService = SimpleDI.Instance.UserService;
            user = new User();

            RegisterCommand = new CommandHelper(RegisterAction);
            LogInCommand = new CommandHelper(LogInAction);
        }

        private void LogInAction()
        {
            pageService.ChangePage(EPages.LOG);
        }

        private void RegisterAction()
        {
            User.Validate(EPages.REG);
            if (User.IsValid)
            {
                if (userService.ValidateRegistrationUser(User))
                {
                    pageService.ChangePage(EPages.LOG);
                }
                else
                {
                    User.ValidationErrors["Email"] = "Email is used, try another.";
                    User.ValidationPropertyChange();
                }
            }
        }
    }
}
