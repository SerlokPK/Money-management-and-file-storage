using Common.Enums;
using Common.Helpers;
using Models.User;
using Services;
using Services.Interface;
using System;

namespace Money_and_data_management.ViewModel
{
    public class AccountViewModel : BaseViewModel
    {
        private IPageService pageService;
        private IUserService userService;
        private User user;
        public CommandHelper<string> ChangePageCommand { get; set; }
        public CommandHelper UpdateCommand { get; set; }

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }
        public AccountViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            userService = SimpleDI.Instance.UserService;

            UpdateCommand = new CommandHelper(UpdateAction);
            ChangePageCommand = new CommandHelper<string>(ChangePageAction);
        }

        private void UpdateAction()
        {
            User.Validate(EPages.ACC);
            if (User.IsValid)
            {
                userService.UpdateUserDetails(User);
                pageService.ChangePage(EPages.WORKSTATION);
            }
        }

        private void ChangePageAction(string page)
        {
            Enum.TryParse(page, out EPages pageName);
            pageService.ChangePage(pageName);
        }
    }
}
