using Common.Enums;
using Common.Helpers;
using Services;
using Services.Interface;

namespace Money_and_data_management.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private IPageService pageService;

        public CommandHelper RegisterCommand { get; set; }
        public CommandHelper LogInCommand { get; set; }
        public LoginViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
            RegisterCommand = new CommandHelper(RegisterAction);
        }

        private void RegisterAction()
        {
            pageService.ChangePage(EPages.REG);
        }
    }
}
