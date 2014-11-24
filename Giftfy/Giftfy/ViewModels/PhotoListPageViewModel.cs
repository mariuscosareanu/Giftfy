using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Giftfy.Models;
using Giftfy.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListPageViewModel : ViewModel
    {
        private readonly PhotosService _photosService;

        private readonly PhotoListsService _photoListsService;

        public PhotoListPageViewModel()
        {
            _photosService = new PhotosService();

            _photoListsService = new PhotoListsService();

            this.OpenPicturePickerCommand = new DelegateCommand<TappedRoutedEventArgs>(OnOpenPicturePickerCOmmand);
        }

        //#region properties
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

        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        //#endregion

        //#region commands
        public DelegateCommand<TappedRoutedEventArgs> OpenPicturePickerCommand { get; set; }

        private async void OnOpenPicturePickerCOmmand(TappedRoutedEventArgs eventArgs)
        {
            var openPicker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                ViewMode = PickerViewMode.Thumbnail
            };

            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");

            openPicker.PickSingleFileAndContinue();

            var a = 1;
        }
        //#endregion

        //#region init
        public async override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);

            var listId = (int)navigationParameter;

            var list = this._photoListsService.Get(listId);

            this.Id = list.Id;
            this.Title = list.Name;
        }
        //#endregion

    }
}
