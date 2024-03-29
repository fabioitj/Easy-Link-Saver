﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Link : ContentPage
    {
        public Models.LinksModel link { get; set; }
        public Link()
        {
            InitializeComponent();

            BindingContext = new Models.LinksModel();
        }

        public Link(Models.LinksModel linkToEdit)
        {
            InitializeComponent();
            BindingContext = linkToEdit; 
        }

        private async void CreateNewLink(object sender, EventArgs e)
        {
            DependencyService.Get<IAdInterstitial>().ShowAd();

            link = (Models.LinksModel)BindingContext;
            link.DateRegister = DateTime.UtcNow;
            if (!string.IsNullOrWhiteSpace(link.Title) && !string.IsNullOrWhiteSpace(link.Description))
            {
                await App.Database.SaveLinkAsync(link);
            }
            else
            {
                await DisplayAlert("Alert", "Please, feed all the entries to save.", "Ok");
            }
            await Navigation.PopAsync();
        }
    }
}