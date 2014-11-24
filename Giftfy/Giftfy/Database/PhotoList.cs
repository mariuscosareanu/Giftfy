using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftfy.Database
{
    public class PhotoLists
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Timestamp { get; set; }

        public PhotoLists() { }

        public PhotoLists(string name)
        {
            Name = name;
        }
    }
}
