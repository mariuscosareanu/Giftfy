using System.Collections.Generic;
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
        private readonly PhotoListsService _photoListsService;

        public PhotoListPageViewModel()
        {
            _photoListsService = new PhotoListsService();

            this.OpenPicturePickerCommand = new DelegateCommand<TappedRoutedEventArgs>(OnOpenPicturePickerCommand);

            this.DeleteListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnDeleteListCommand);

            this.EditListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnShowEditListCommand);

            this.CancelEditListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnCancelEditListCommand);

            this.SaveEditListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnSaveEditListCommand);

            this.BackToStartCommand = new DelegateCommand<TappedRoutedEventArgs>(OnBackToStartCommand);
        }

        #region Properties
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

        private bool _showEditList;

        public bool ShowEditList
        {
            get { return _showEditList; }
            set { SetProperty(ref _showEditList, value); }
        }

        private string _titleEdit;

        public string TitleEdit
        {
            get { return this._title; }
            set { SetProperty(ref _titleEdit, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand<TappedRoutedEventArgs> OpenPicturePickerCommand { get; set; }

        private async void OnOpenPicturePickerCommand(TappedRoutedEventArgs eventArgs)
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
        }

        public DelegateCommand<TappedRoutedEventArgs> DeleteListCommand { get; set; }

        private async void OnDeleteListCommand(TappedRoutedEventArgs eventArgs)
        {
            this._photoListsService.Delete(this.Id);

            (App.Current as App).NavigationService.Navigate("PhotoLists", null);
        }

        public DelegateCommand<TappedRoutedEventArgs> EditListCommand { get; set; }

        private async void OnShowEditListCommand(TappedRoutedEventArgs eventArgs)
        {
            this.ShowEditList = true;
        }

        public DelegateCommand<TappedRoutedEventArgs> SaveEditListCommand { get; set; }

        private void OnSaveEditListCommand(TappedRoutedEventArgs eventArgs)
        {
            this._photoListsService.Update(new PhotoListModel
            {
                Id = this.Id,
                Name = this._titleEdit
            });

            this.Title = this._titleEdit;

            this.ShowEditList = false;
        }

        public DelegateCommand<TappedRoutedEventArgs> CancelEditListCommand { get; set; }

        private void OnCancelEditListCommand(TappedRoutedEventArgs eventArgs)
        {
            this.ShowEditList = false;

            this._titleEdit = this.Title;
        }

        public DelegateCommand<TappedRoutedEventArgs> BackToStartCommand { get; set; }

        private void OnBackToStartCommand(TappedRoutedEventArgs eventArgs)
        {
            (App.Current as App).NavigationService.Navigate("PhotoLists", null);
        }
        #endregion

        #region Init
        public override void OnNavigatedTo(object navigationParameter, NavigationMode navigationMode, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(navigationParameter, navigationMode, viewModelState);

            var listId = (int)navigationParameter;

            var list = this._photoListsService.Get(listId);

            this.Id = list.Id;
            this.Title = list.Name;
        }
        #endregion

    }
}
