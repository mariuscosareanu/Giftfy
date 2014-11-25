﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Giftfy.Models;
using Giftfy.Views;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.Practices.Prism.StoreApps.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualBasic;

namespace Giftfy.ViewModels
{
    public class PhotoListViewModel : ViewModel
    {
        public PhotoListViewModel()
        {
            this.ListTapCommand = new DelegateCommand<TappedRoutedEventArgs>(ListTap);
        }

        private int _id;

        public int Id
        {
            get { return this._id; }
            set { SetProperty(ref _id, value); }
        }

        private IEnumerable<PhotoItemModel> _items;

        public IEnumerable<PhotoItemModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public int Count
        {
            get { return _items != null ? _items.Count() : 0; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<TappedRoutedEventArgs> ListTapCommand { get; set; }

        private void ListTap(TappedRoutedEventArgs eventArgs)
        {
            (App.Current as App).NavigationService.Navigate("PhotoList", this.Id);
        }
    }
}
