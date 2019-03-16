using Common.Enums;
using System;

namespace Services.Interface
{
    public interface IPageService
    {
        event EventHandler PageChanged;
        void ChangePage(EPages pageName);
        EPages CurrentPage { get; }
    }
}
