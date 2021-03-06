﻿using Android.Widget;
using Covid19.Controller;
using Covid19.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Covid19.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        ConnectivityTest connectivityTest = null;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Home, Title="Home" },
                new HomeMenuItem {Id = MenuItemType.CurrentCovid19Status, Title="CurrentStatus" },
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };
            connectivityTest = new ConnectivityTest();
            if (connectivityTest.CheckInternet())
            {
               // Toast.MakeText(Android.App.Application.Context,"Yea", ToastLength.Long).Show();
                ListViewMenu.ItemsSource = menuItems;

                ListViewMenu.SelectedItem = menuItems[0];
                ListViewMenu.ItemSelected += async (sender, e) =>
                {
                    if (e.SelectedItem == null)
                        return;

                    var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                    await RootPage.NavigateFromMenu(id);
                };
            }
            else
            {
                string no = "No Internet";
                Toast.MakeText(Android.App.Application.Context, no, ToastLength.Long).Show();
            }
            
        }
    }
}