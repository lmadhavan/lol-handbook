using LolHandbook.Pages;
using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace LolHandbook
{
    public sealed partial class MainFrame: Page
    {
        private static readonly IDictionary<Type, string> PageTitles = new Dictionary<Type, string>();

        static MainFrame()
        {
            PageTitles[typeof(ChampionsPage)] = "Champions";
            PageTitles[typeof(ChampionDetailPage)] = "Champions";
            PageTitles[typeof(ItemsPage)] = "Items";
            PageTitles[typeof(SummonerSpellsPage)] = "Summoner Spells";
        }

        public MainFrame()
        {
            this.InitializeComponent();
            ContentFrame.CacheSize = PageTitles.Count;
            ContentFrame.Navigated += OnNavigated;
            ContentFrame.NavigationFailed += OnNavigationFailed;
            SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
            Window.Current.CoreWindow.PointerPressed += OnPointerPressed;
        }

        private Frame ContentFrame => SplitView.Content as Frame;
        private Type ContentType => ContentFrame.Content.GetType();
        public bool IsContentLoaded => ContentFrame.Content != null;

        public void Navigate(Type type)
        {
            Navigate(type, null);
        }

        public void Navigate(Type type, object parameter)
        {
            SplitView.IsPaneOpen = false;

            if (IsContentLoaded && ContentType == type)
            {
                return;
            }

            ContentFrame.Navigate(type, parameter);
        }

        private void OnNavigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = ContentFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;

            Type type = ContentFrame.Content.GetType();
            string title = PageTitles[type];
            PageTitle.Text = title?.ToUpper();
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                e.Handled = true;
                ContentFrame.GoBack();
            }
        }

        private void OnPointerPressed(CoreWindow sender, PointerEventArgs args)
        {
            if (args.CurrentPoint.Properties.IsXButton1Pressed)
            {
                if (ContentFrame.CanGoBack)
                {
                    ContentFrame.GoBack();
                }
            }
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void Nav_Champions_Click(object sender, RoutedEventArgs e)
        {
            Navigate(typeof(ChampionsPage));
        }

        private void Nav_Items_Click(object sender, RoutedEventArgs e)
        {
            Navigate(typeof(ItemsPage));
        }

        private void Nav_SummonerSpells_Click(object sender, RoutedEventArgs e)
        {
            Navigate(typeof(SummonerSpellsPage));
        }
    }
}
