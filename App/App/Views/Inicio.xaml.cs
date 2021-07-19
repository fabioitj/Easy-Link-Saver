﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        public List<Models.LinksModel> LinkList { get; set; }
        public bool Selected { get; set; }
        public Inicio()
        {
            InitializeComponent();
            Title = "Links";
            searchBar.TextChanged += OnTextChanged;

            RefreshListView();

        }

        public void RefreshListView()
        {
            pageLinksList.RefreshCommand = new Command(() =>
            {
                GetLinksByFilter("");    
                pageLinksList.IsRefreshing = false;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetLinksByFilter("");
        }

        void OnTextChanged(object sender, EventArgs e)
        {
            GetLinksByFilter(searchBar.Text);
        }

        protected async void GetLinksByFilter(string filter)
        {
            var listaItens = await App.Database.GetLinksAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                listaItens = listaItens.OrderByDescending(x => x.ID).Where(x => x.Title.ToLower().Contains(filter.ToLower())).ToList();
            }
            pageLinksList.ItemsSource = listaItens;
        }

        private void AddNewLink(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Link());
        }
        private async void TapJoinLink(object sender, ItemTappedEventArgs e)
        {
            var link = ((Models.LinksModel)e.Item).Description;
            if (!(link.StartsWith("https://") || link.StartsWith("http://")))
            {
                link = "https://" + link;
            }
            await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
        }

        async void OnActionSheetSimpleClicked(object sender, EventArgs e)
        {
            var link = (Models.LinksModel)((ImageButton)sender).CommandParameter;

            string action = await DisplayActionSheet("Options: ", "Cancel", null, "Edit", "Delete");

            if (action == "Edit")
            {
                await Navigation.PushAsync(new Link(link));
            }
            else if (action == "Delete")
            {
                if (await DisplayAlert("Confirmation", "Do you really want to delete this item?", "Yes", "No"))
                {
                    await App.Database.DeleteLinkAsync(link);
                    await DisplayAlert("Success", "Register deleted.", "Ok");
                }
            }

            GetLinksByFilter("");

        }
    }
}