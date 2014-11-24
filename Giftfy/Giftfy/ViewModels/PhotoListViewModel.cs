using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftfy.Models;
using Microsoft.Practices.Prism.Mvvm;

namespace Giftfy.ViewModels
{
    public class PhotoListViewModel : ViewModel
    {
        public PhotoListViewModel()
        {
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
    }
}
