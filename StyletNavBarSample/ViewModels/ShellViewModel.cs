using System;
using System.Collections.Generic;
using System.Text;

namespace StyletNavBarSample.ViewModels
{
    class ShellViewModel
    {
        public NavigationPageViewModel NavigationPage { get; set; }

        public ShellViewModel(NavigationPageViewModel navigationPage)
        {
            NavigationPage = navigationPage;
        }
    }
}
