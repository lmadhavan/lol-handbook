﻿using DataDragon;
using LolHandbook.ViewModels;
using Windows.UI.Xaml.Controls;

namespace LolHandbook.Pages
{
    public sealed partial class ItemsPage : Page, ISupportResuming
    {
        public ItemsPage()
        {
            this.InitializeComponent();
        }

        private ItemsViewModel ViewModel => DataContext as ItemsViewModel;

        public void OnResuming()
        {
            ViewModel.LoadData(false);
        }

        public void Refresh()
        {
            ViewModel.LoadData(true);
        }

        private void TagList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFlyout.Hide();
            ViewModel.TagFilter = TagList.SelectedItem as Tag;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ItemDetailPage.Visibility == Windows.UI.Xaml.Visibility.Collapsed)
            {
                Item item = (Item)e.ClickedItem;
                App.Navigate(typeof(ItemDetailPage), item);
            }
        }
    }
}
