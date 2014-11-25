using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

        private SQLiteConnection db;

        public PhotoListsService()
        {
            db = new SQLiteConnection(App.DB_PATH);
        }

        public List<PhotoListModel> GetAll()
        {
            return db.Table<PhotoLists>().Select(x => new PhotoListModel
            {
                Id = x.Id,
                Name = x.Name,
                Timestamp = x.Timestamp
            }).ToList();
        }

        public PhotoListModel Get(int listId)
        {
            var model = db.Get<PhotoLists>(listId);

            return new PhotoListModel
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public int Add(PhotoListModel model)
        {
            var dbModel = new PhotoLists
                {
                    Name = model.Name,
                    Timestamp = DateTime.Now
                };


            db.RunInTransaction(() => db.Insert(dbModel));

            return dbModel.Id;
        }

        public void Delete(int listId)
        {
            db.Delete<PhotoLists>(listId);
        }

        public void Update(PhotoListModel model)
        {
            var dbEntry = db.Get<PhotoLists>(model.Id);

            dbEntry.Name = model.Name;

            var item = db.Update(dbEntry);
        }
    }
}
