using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLink : ContentPage
    {
        public Models.LinksModel link { get; set; }
        public AddLink()
        {
            InitializeComponent();

            BindingContext = new Models.LinksModel();
        }

        public AddLink(Models.LinksModel linkToEdit)
        {
            InitializeComponent();
            link = linkToEdit;
            entryTitle.Text = link.Title;
            entryDescription.Text = link.Description; 
            BindingContext = new Models.LinksModel();
        }

        private async void CreateNewLink(object sender, EventArgs e)
        {
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