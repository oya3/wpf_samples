using System;
using System.Collections.Generic;

namespace WpfApp1.ViewModels
{
    public static class PageManager
    {
        public delegate void ChangePageDelegate(IPageViewModel page);
        public static ChangePageDelegate ChangePageFunction;
        public static void ChangePage(IPageViewModel page)
        {
            ChangePageFunction(page);
        }
    }
}
