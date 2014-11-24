using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftfy.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListPageViewModel : ViewModel
    {
        public PhotoListPageViewModel()
        {
            
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
    }
}
