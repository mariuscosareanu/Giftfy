using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftfy.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListsPageViewModel : ViewModel
    {
        public PhotoListsPageViewModel()
        {
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
                    Items = new List<PhotoItem>{new PhotoItem(), new PhotoItem()}
                },
                new PhotoListViewModel()
                {
                    Title = "For dad",
                    Items = new List<PhotoItem>{new PhotoItem()}
                },
                new PhotoListViewModel()
                {
                    Title = "For friends",
                    Items = new List<PhotoItem>{new PhotoItem(),new PhotoItem(),new PhotoItem(),new PhotoItem()}
                    }
            };
        }
    }
}
