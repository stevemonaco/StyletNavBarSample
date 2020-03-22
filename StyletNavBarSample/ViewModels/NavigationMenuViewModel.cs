using Stylet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace StyletNavBarSample.ViewModels
{
    class NavigationMenuViewModel : Screen
    {
        public string Name { get; set; }

        private ItemCollection _menuOptions;
        public ItemCollection MenuOptions
        {
            get => _menuOptions;
            set => SetAndNotify(ref _menuOptions, value);
        }

        private PageContentViewModel _pageContent;
        public PageContentViewModel PageContent
        {
            get => _pageContent;
            set => SetAndNotify(ref _pageContent, value);
        }

    }
}
