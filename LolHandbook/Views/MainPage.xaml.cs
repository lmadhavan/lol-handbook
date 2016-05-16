﻿using LolHandbook.ViewModels.Services;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Views
{
    public sealed partial class MainPage : Page, ISupportResuming
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        public void OnResuming()
        {
            ChampionsView.OnResuming();
            ItemsView.OnResuming();
        }

        private async void About_Click(object sender, RoutedEventArgs e)
        {
            AboutDialog dialog = new AboutDialog();
            await dialog.ShowAsync();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            DataDragonService.InvalidateCache();
            ChampionsView.Refresh();
            ItemsView.Refresh();
        }
    }
}
