using App.Menu;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();

            CreateMenu();

        }
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                var item = (MasterPageItem)e.Item;
                Type page = item.TargetType;
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }
        }

        public async void CreateMenu()
        {

            menuList = new List<MasterPageItem>
            {
                new MasterPageItem() { Title = "Links", Icon = "ic_globe.png", TargetType = typeof(Views.Inicio) },
                new MasterPageItem() { Title = "About", Icon = "ic_info_outline.png", TargetType = typeof(Views.About) }
            };

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Views.Inicio)));

            paginaMestreList.ItemsSource = menuList;

        }

    }
}