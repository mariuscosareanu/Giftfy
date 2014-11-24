using System;
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
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.Mvvm.Interfaces;
using Microsoft.VisualBasic;

namespace Giftfy.ViewModels
{
    public class PhotoListViewModel : ViewModel
    {
        private INavigationService navigationService;

        public PhotoListViewModel()
        {
            this.ListTapCommand = new DelegateCommand<TappedRoutedEventArgs>(ListTap);

            this.navigationService = new FrameNavigationService(new FrameFacadeAdapter(Window.Current.Content as Frame), GetPageType, new SessionStateService());
        }

        protected virtual Type GetPageType(string pageToken)
        {
            var assemblyQualifiedAppType = this.GetType().GetTypeInfo().AssemblyQualifiedName;

            var pageNameWithParameter = assemblyQualifiedAppType.Replace(this.GetType().FullName, this.GetType().Namespace + ".Views.{0}Page");

            var viewFullName = string.Format(CultureInfo.InvariantCulture, pageNameWithParameter, pageToken).Replace(".ViewModels", string.Empty);
            var viewType = Type.GetType(viewFullName);

            return viewType;
        }

        private int _id;

        public int Id
        {
            get { return this._id; }
            private set { SetProperty(ref _id, value); }
        }

        private IEnumerable<PhotoItem> _items;

        public IEnumerable<PhotoItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public int Count
        {
            get { return _items.Count(); }
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
            var a = 0;

            this.navigationService.Navigate("PhotoList", this.Id);
        }

    }
}
