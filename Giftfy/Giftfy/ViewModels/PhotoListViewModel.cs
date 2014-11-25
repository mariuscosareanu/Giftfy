using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Input;
using Giftfy.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListViewModel : ViewModel
    {
        public PhotoListViewModel()
        {
            this.ListTapCommand = new DelegateCommand<TappedRoutedEventArgs>(ListTap);
        }

        #region Properties
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
        #endregion

        #region Commands
        public DelegateCommand<TappedRoutedEventArgs> ListTapCommand { get; set; }

        private void ListTap(TappedRoutedEventArgs eventArgs)
        {
            (App.Current as App).NavigationService.Navigate("PhotoList", this.Id);
        }
        #endregion
    }
}
