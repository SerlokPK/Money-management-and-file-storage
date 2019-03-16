using Common.Enums;
using Common.Helpers;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageService pageService;

        private BaseViewModel currentViewModel;
        private readonly LoginViewModel loginViewModel = new LoginViewModel();
        private readonly RegisterViewModel registerViewModel = new RegisterViewModel();
        public MainWindowViewModel()
        {
            pageService = SimpleDI.Instance.PageService;

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
