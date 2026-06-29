using Avalonia.Collections;
using AvaStar.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace AvaStar.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public IAvaloniaReadOnlyList<ViewModelBase> AllPages { get; }
        public PageNavigationService PageNavigationService { get; }


        [ObservableProperty] private ViewModelBase? _selectedPage;

        public MainWindowViewModel(IEnumerable<ViewModelBase> allPages, PageNavigationService pageNavigationService)
        {
            AllPages = new AvaloniaList<ViewModelBase>(allPages.OrderBy(x => x.Index).ThenBy(x => x.DisplayName)); 
            PageNavigationService = pageNavigationService;

            pageNavigationService.NavigationRequested += pageType =>
            {
                var page = AllPages.FirstOrDefault(x => x.GetType() == pageType);
                if (page is null || SelectedPage?.GetType() == pageType) return;
                SelectedPage = page;
            };

        }
    }
}
