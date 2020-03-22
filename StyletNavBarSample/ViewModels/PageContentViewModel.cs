using Stylet;
using System;

namespace StyletNavBarSample.ViewModels
{
    class PageContentViewModel : Screen
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetAndNotify(ref _title, value);
        }

        private string _content;
        public string Content
        {
            get => _content;
            set => SetAndNotify(ref _content, value);
        }
    }
}
