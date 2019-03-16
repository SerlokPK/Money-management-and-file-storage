using Common.Enums;
using Services.Interface;
using System;

namespace Services.Page
{
    public class PageService : IPageService
    {
        public event EventHandler PageChanged;

        public EPages CurrentPage { get; private set; }

        public PageService()
        {
        }

        public void ChangePage(EPages pageName)
        {
            CurrentPage = pageName;
            PageChanged?.Invoke(this, new EventArgs());
        }
    }
}
