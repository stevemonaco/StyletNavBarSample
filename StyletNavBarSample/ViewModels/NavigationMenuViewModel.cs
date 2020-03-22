using Stylet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace StyletNavBarSample.ViewModels
{
    class NavigationMenuViewModel : Screen
    {
        private NavigationPageViewModel _parentNavigator;
        public NavigationPageViewModel ParentNavigator
        {
            get => _parentNavigator;
            set => SetAndNotify(ref _parentNavigator, value);
        }

        private BindableCollection<NavigationMenuViewModel> _menuOptions = new BindableCollection<NavigationMenuViewModel>();
        public BindableCollection<NavigationMenuViewModel> MenuOptions
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
