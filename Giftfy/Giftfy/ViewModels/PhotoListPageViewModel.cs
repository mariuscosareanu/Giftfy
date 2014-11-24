using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using Giftfy.Models;
using Giftfy.Services;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListPageViewModel : ViewModel
    {
        private readonly PhotosService _photosService;

        public PhotoListPageViewModel()
        {
            _photosService = new PhotosService();
        }

        private int _id;

        public int Id
        {
            get { return this._id; }
            private set { SetProperty(ref _id, value); }
        }

        private IEnumerable<PhotoItemModel> _items;

        public IEnumerable<PhotoItemModel> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public async override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);

            var id = (int) navigationParameter;
        }

    }
}
