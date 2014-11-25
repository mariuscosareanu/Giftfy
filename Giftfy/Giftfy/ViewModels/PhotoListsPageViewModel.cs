using System.Collections.ObjectModel;
using System.Linq;
using Windows.System;
using Windows.UI.Xaml.Input;
using Giftfy.Models;
using Giftfy.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListsPageViewModel : ViewModel
    {
        private readonly PhotoListsService _photoListsService;

        public PhotoListsPageViewModel()
        {
            this._photoListsService = new PhotoListsService();

            this.NewListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnNewListCommand);

            this.ShowNewListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnShowNewListCommand);

            this.KeyUpNewList = new DelegateCommand<KeyRoutedEventArgs>(OnKeyUpNewList);

            this.CancelNewListCommand = new DelegateCommand<TappedRoutedEventArgs>(OnCancelNewListCommand);

            this.GetLists();
        }

        #region Properties
        private string _newListName;

        public string NewListName
        {
            get { return this._newListName; }
            set { SetProperty(ref _newListName, value); }
        }

        private bool _newListVisible;

        public bool NewListVisible
        {
            get { return this._newListVisible; }
            set { SetProperty(ref _newListVisible, value); }
        }

        private ObservableCollection<PhotoListViewModel> _lists;

        public ObservableCollection<PhotoListViewModel> Lists
        {
            get { return _lists; }
            set { SetProperty(ref _lists, value); }
        }
        #endregion

        #region Commands
        public DelegateCommand<TappedRoutedEventArgs> NewListCommand { get; set; }

        private void OnNewListCommand(TappedRoutedEventArgs eventArgs)
        {
            var newId = this._photoListsService.Add(new PhotoListModel
            {
                Name = this.NewListName
            });

            var newList = this._photoListsService.Get(newId);

            this.Lists.Insert(0, new PhotoListViewModel
            {
                Title = newList.Name,
                Items = newList.Photos,
                Id = newList.Id
            });

            this.NewListName = string.Empty;

            this.NewListVisible = false;
        }

        public DelegateCommand<TappedRoutedEventArgs> ShowNewListCommand { get; set; }

        private void OnShowNewListCommand(TappedRoutedEventArgs eventArgs)
        {
            this.NewListVisible = true;
        }

        public DelegateCommand<KeyRoutedEventArgs> KeyUpNewList { get; set; }

        private void OnKeyUpNewList(KeyRoutedEventArgs eventArgs)
        {
            if (eventArgs.Key == VirtualKey.Enter)
            {
                this.OnNewListCommand(null);
            }
        }

        public DelegateCommand<TappedRoutedEventArgs> CancelNewListCommand { get; set; }

        private void OnCancelNewListCommand(TappedRoutedEventArgs eventArgs)
        {
            this.NewListVisible = false;
            this.NewListName = string.Empty;
        }
        #endregion

        #region Init
        public void GetLists()
        {
            this.Lists = new ObservableCollection<PhotoListViewModel>();

            var lists = this._photoListsService.GetAll().OrderBy(x => x.Timestamp).Select(x => new PhotoListViewModel
            {
                Id = x.Id,
                Title = x.Name,
                Items = x.Photos
            });

            foreach (var list in lists)
            {
                this.Lists.Add(list);
            }
        }
        #endregion
    }
}
