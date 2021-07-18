﻿using System.Collections.Generic;
using System.ComponentModel;
using TerminalMACS.Clients.App.Models;
using TerminalMACS.Clients.App.Resx;
using Xamarin.Forms;

namespace TerminalMACS.Clients.App.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{ Id = MenuItemType.ClientInfo, Title=AppResource.ClientInfo_MenuItem },
                new HomeMenuItem{ Id = MenuItemType.Contacts, Title=AppResource.Contacts_MenuItem},
                new HomeMenuItem { Id = MenuItemType.About, Title=AppResource.About_MenuItem }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[menuItems.Count - 1];     //Default display about page
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}