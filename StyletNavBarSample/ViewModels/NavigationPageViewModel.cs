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

        public void ShowMenu(NavigationMenuViewModel menu)
        {
            ActiveItem = menu;
            ActiveContent = menu.PageContent;
        }

        public void ShowContent(PageContentViewModel content)
        {
            ActiveContent = content;
        }

        private void BuildMenus()
        {
            _initialMenu = new NavigationMenuViewModel();
            _initialMenu.PageContent = new PageContentViewModel() { Title = "Menu Splash", Content = "Menu Splash Screen" };
            _initialMenu.ParentNavigator = this;

            _initialMenu.MenuOptions.Add(BuildMenuA());
            _initialMenu.MenuOptions.Add(BuildMenuB());
            _initialMenu.MenuOptions.Add(BuildMenuC());
        }

        private NavigationMenuViewModel BuildMenuA()
        {
            var menuA = new NavigationMenuViewModel();
            menuA.DisplayName = "Menu A";
            menuA.PageContent = new PageContentViewModel() { Title = "Menu A Title", Content = "Menu A Content" };
            menuA.ParentNavigator = this;

            var menuA1 = new NavigationMenuViewModel();
            menuA1.DisplayName = "Menu A.1";
            menuA1.PageContent = new PageContentViewModel() { Title = "Menu A.1 Title", Content = "Menu A.1 Content" };
            menuA1.ParentNavigator = this;

            var menuA2 = new NavigationMenuViewModel();
            menuA2.DisplayName = "Menu A.2";
            menuA2.PageContent = new PageContentViewModel() { Title = "Menu A.2 Title", Content = "Menu A.2 Content" };
            menuA2.ParentNavigator = this;

            var menuA3 = new NavigationMenuViewModel();
            menuA3.DisplayName = "Menu A.3";
            menuA3.PageContent = new PageContentViewModel() { Title = "Menu A.3 Title", Content = "Menu A.3 Content" };
            menuA3.ParentNavigator = this;

            var menuA1a = new NavigationMenuViewModel();
            menuA1a.DisplayName = "Menu A.1.a";
            menuA1a.PageContent = new PageContentViewModel() { Title = "Menu A.1.a Title", Content = "Menu A.1.a Content" };
            menuA1a.ParentNavigator = this;

            menuA1.MenuOptions.Add(menuA1a);

            menuA.MenuOptions.Add(menuA1);
            menuA.MenuOptions.Add(menuA2);
            menuA.MenuOptions.Add(menuA3);

            return menuA;
        }

        private NavigationMenuViewModel BuildMenuB()
        {
            var menuB = new NavigationMenuViewModel();
            menuB.DisplayName = "Menu B";
            menuB.PageContent = new PageContentViewModel() { Title = "Menu B Title", Content = "Menu B Content" };
            menuB.ParentNavigator = this;

            return menuB;
        }

        private NavigationMenuViewModel BuildMenuC()
        {
            var menuC = new NavigationMenuViewModel();
            menuC.DisplayName = "Menu C";
            menuC.PageContent = new PageContentViewModel() { Title = "Menu C Title", Content = "Menu C Content" };
            menuC.ParentNavigator = this;

            return menuC;
        }
    }
}
