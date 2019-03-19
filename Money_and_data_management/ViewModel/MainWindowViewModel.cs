using Common.Enums;
using Common.Helpers;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageService pageService;
        private IUserService userService;
        private IWorkstationService workstationService;

        private BaseViewModel currentViewModel;
        private readonly LoginViewModel loginViewModel = new LoginViewModel();
        private readonly RegisterViewModel registerViewModel = new RegisterViewModel();
        private readonly WorkstationViewModel workstationViewModel = new WorkstationViewModel();
        private readonly AccountViewModel accountViewModel = new AccountViewModel();
        public MainWindowViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            userService = SimpleDI.Instance.UserService;
            workstationService = SimpleDI.Instance.WorkstationService;

            pageService.PageChanged += PageService_PageChanged;
            currentViewModel = loginViewModel;
        }

        private void PageService_PageChanged(object sender, System.EventArgs e)
        {
            switch (pageService.CurrentPage)
            {
                case EPages.LOG:
                    CurrentViewModel = loginViewModel;
                    break;
                case EPages.REG:
                    CurrentViewModel = registerViewModel;
                    break;
                case EPages.WORKSTATION:
                    workstationViewModel.Workstations = workstationService.GetAllWorkstations(userService.GetCurrentUser().UserId);
                    CurrentViewModel = workstationViewModel;
                    break;
                case EPages.ACC:
                    accountViewModel.User = userService.GetCurrentUser();
                    CurrentViewModel = accountViewModel;
                    break;
                default:
                    break;
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
    }
}
