using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftfy.Models;
using Giftfy.ViewModels;

namespace Giftfy.DesignViewModels
{
    public class PhotoListsDesignViewModel
    {
        public PhotoListsDesignViewModel()
        {
            FillWithDummy();
        }

        public IEnumerable<PhotoListViewModel> Lists { get; set; }

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
