using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giftfy.Models
{
    public class PhotoList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<PhotoItem> Photos { get; set; }
    }
}
