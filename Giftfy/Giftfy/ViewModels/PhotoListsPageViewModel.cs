using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Input;
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

            FillWithDummy();
        }

        private IEnumerable<PhotoListViewModel> _lists;

        public IEnumerable<PhotoListViewModel> Lists
        {
            get { return _lists; }
            private set { SetProperty(ref _lists, value); }
        }

        public void FillWithDummy()
        {
            Lists = new List<PhotoListViewModel>
            {
                new PhotoListViewModel
                {
                    Title = "For mom",
                    Items = new List<PhotoItemModel>{new PhotoItemModel(), new PhotoItemModel()}
                },
                new PhotoListViewModel()
                {
                    Title = "For dad",
                    Items = new List<PhotoItemModel>{new PhotoItemModel()}
                },
                new PhotoListViewModel()
                {
                    Title = "For friends",
                    Items = new List<PhotoItemModel>{new PhotoItemModel(),new PhotoItemModel(),new PhotoItemModel(),new PhotoItemModel()}
                    }
            };
        }
    }
}
