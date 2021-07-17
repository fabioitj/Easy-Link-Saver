using System;
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
        public List<Models.LinksModel> linkList { get; set; }
        public Inicio()
        {
            InitializeComponent();
            Title = "Links";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var listaItens = await App.Database.GetLinksAsync();

            listaItens = listaItens.OrderByDescending(x => x.ID).ToList();

            pageLinksList.ItemsSource = listaItens;
        }

        private void AddNewLink(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddLink());
        }
        private async void TapJoinLink(object sender, ItemTappedEventArgs e)
        {
            var link = ((Models.LinksModel)e.Item).Description;

            if (!(link.StartsWith("https://") || link.StartsWith("http://"))) {
                link = "https://" + link;   
            }
            await Browser.OpenAsync(link, BrowserLaunchMode.SystemPreferred);
        }
        
        private void SelectItem(object sender, ItemTappedEventArgs e)
        {

        }


    }
}