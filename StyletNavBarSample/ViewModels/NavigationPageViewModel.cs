﻿using Stylet;

namespace StyletNavBarSample.ViewModels
{
    class NavigationPageViewModel : MenuStackConductor<NavigationMenuViewModel>
    {
        private NavigationMenuViewModel _activeMenu;
        public NavigationMenuViewModel ActiveMenu
        {
            get => _activeMenu;
            set => SetAndNotify(ref _activeMenu, value);
        }

        private PageContentViewModel _activeContent;
        public PageContentViewModel ActiveContent
        {
            get => _activeContent;
            set => SetAndNotify(ref _activeContent, value);
        }

        public void ShowMenu(NavigationMenuViewModel menu)
        {
            ActiveItem = menu;
        }

        public void ShowContent(PageContentViewModel content)
        {
            ActiveContent = content;
        }
    }
}
