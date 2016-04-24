using System;
using System.Collections.Generic;
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
            PageTitles[typeof(SummonerSpellPage)] = "Summoner Spells";
        }

        public MainFrame()
        {
            this.InitializeComponent();
            ContentFrame.Navigated += ContentFrame_Navigated;
            ContentFrame.NavigationFailed += ContentFrame_NavigationFailed;
        }

        private Frame ContentFrame => SplitView.Content as Frame;
        public bool IsContentLoaded => ContentFrame.Content != null;

        public void Navigate(Type type)
        {
            SplitView.IsPaneOpen = false;
            ContentFrame.Navigate(type);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SplitView.IsPaneOpen = !SplitView.IsPaneOpen;
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            Type type = ContentFrame.Content.GetType();
            string title = PageTitles[type];
            PageTitle.Text = title?.ToUpper();
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void Nav_SummonerSpells_Click(object sender, RoutedEventArgs e)
        {
            Navigate(typeof(SummonerSpellPage));
        }
    }
}
