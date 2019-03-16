using Common.Helpers;
using Services;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money_and_data_management.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private IPageService pageService;

        public RegisterViewModel()
        {
            pageService = SimpleDI.Instance.PageService;
        }
    }
}
