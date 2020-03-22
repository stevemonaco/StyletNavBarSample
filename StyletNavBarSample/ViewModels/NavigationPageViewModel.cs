using Stylet;
using StyletNavBarSample.Infrastructure;

namespace StyletNavBarSample.ViewModels
{
    class NavigationPageViewModel : MenuStackConductor<NavigationMenuViewModel>
    {
        private NavigationMenuViewModel _initialMenu;

        private PageContentViewModel _activeContent;
        public PageContentViewModel ActiveContent
        {
            get => _activeContent;
            set => SetAndNotify(ref _activeContent, value);
        }

        public NavigationPageViewModel()
        {
            BuildMenus();
            ActiveItem = _initialMenu;
            ActiveContent = _initialMenu.PageContent;
        }

        public void GoBackMenu()
        {
            GoBack();
            ActiveContent = ActiveItem.PageContent;
        }

        public void ShowMenu(NavigationMenuViewModel menu)
        {
            ActiveItem = menu;
            ActiveContent = menu.PageContent;
        }

        private void BuildMenus()
        {
            _initialMenu = new NavigationMenuViewModel
            {
                PageContent = new PageContentViewModel() { Title = "Menu Splash", Content = "Menu Splash Screen" },
                ParentNavigator = this
            };

            _initialMenu.MenuOptions.Add(BuildMenuA());
            _initialMenu.MenuOptions.Add(BuildMenuB());
            _initialMenu.MenuOptions.Add(BuildMenuC());
        }

        private NavigationMenuViewModel BuildMenuA()
        {
            var menuA = new NavigationMenuViewModel
            {
                DisplayName = "Menu A",
                PageContent = new PageContentViewModel() { Title = "Menu A Title", Content = "Menu A Content" },
                ParentNavigator = this
            };

            var menuA1 = new NavigationMenuViewModel
            {
                DisplayName = "Menu A.1",
                PageContent = new PageContentViewModel() { Title = "Menu A.1 Title", Content = "Menu A.1 Content" },
                ParentNavigator = this
            };

            var menuA2 = new NavigationMenuViewModel
            {
                DisplayName = "Menu A.2",
                PageContent = new PageContentViewModel() { Title = "Menu A.2 Title", Content = "Menu A.2 Content" },
                ParentNavigator = this
            };

            var menuA3 = new NavigationMenuViewModel
            {
                DisplayName = "Menu A.3",
                PageContent = new PageContentViewModel() { Title = "Menu A.3 Title", Content = "Menu A.3 Content" },
                ParentNavigator = this
            };

            var menuA1a = new NavigationMenuViewModel
            {
                DisplayName = "Menu A.1.a",
                PageContent = new PageContentViewModel() { Title = "Menu A.1.a Title", Content = "Menu A.1.a Content" },
                ParentNavigator = this
            };

            menuA1.MenuOptions.Add(menuA1a);

            menuA.MenuOptions.Add(menuA1);
            menuA.MenuOptions.Add(menuA2);
            menuA.MenuOptions.Add(menuA3);

            return menuA;
        }

        private NavigationMenuViewModel BuildMenuB()
        {
            var menuB = new NavigationMenuViewModel
            {
                DisplayName = "Menu B",
                PageContent = new PageContentViewModel() { Title = "Menu B Title", Content = "Menu B Content" },
                ParentNavigator = this
            };

            return menuB;
        }

        private NavigationMenuViewModel BuildMenuC()
        {
            var menuC = new NavigationMenuViewModel
            {
                DisplayName = "Menu C",
                PageContent = new PageContentViewModel() { Title = "Menu C Title", Content = "Menu C Content" },
                ParentNavigator = this
            };

            return menuC;
        }
    }
}
