using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftfy.Models
{
    public class PhotoListModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Timestamp { get; set; }

        public List<PhotoItemModel> Photos { get; set; }
    }
}
