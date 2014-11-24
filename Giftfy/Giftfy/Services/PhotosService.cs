using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftfy.Models;

namespace Giftfy.Services
{
    public class PhotosService
    {
        public PhotoItemModel Get(int id)
        {
            return new PhotoItemModel();
        }

        public IEnumerable<PhotoItemModel> GetByListId(int listId)
        {
            return new List<PhotoItemModel>();
        }

        public void AddPhoto(int listId)
        {

        }
    }
}
