using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Giftfy.Database;
using Giftfy.Models;
using Giftfy.ViewModels;
using Newtonsoft.Json;
using SQLite;

namespace Giftfy.Services
{
    public class PhotoListsService
    {
        private string DataPath = "photosList.json";

        private readonly SQLiteConnection db;

        public PhotoListsService()
        {
            db = new SQLiteConnection(App.DB_PATH);
        }

        public List<PhotoListModel> GetAll()
        {
            return db.Table<PhotoLists>().Select(x => new PhotoListModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public PhotoListModel Get(int listId)
        {
            var model = db.Table<PhotoLists>().FirstOrDefault(x => x.Id == listId);

            return new PhotoListModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public int Add(PhotoListModel model)
        {
            return db.Insert(new PhotoLists
            {
                Name = model.Name,
                Timestamp = DateTime.Now
            });
        }
    }
}
