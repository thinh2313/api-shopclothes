using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopClothes.Models
{
    public class Categories
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int? CREATEBY { get; set; }
        public System.DateTime CREATEAT { get; set; }
        public int? UPDATEBY { get; set; }
        public System.DateTime UPDATEAT { get; set; }
    }
}
