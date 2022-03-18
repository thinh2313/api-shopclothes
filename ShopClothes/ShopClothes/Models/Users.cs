using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopClothes
{
    public class Users
    {
        public int ID { get; set; }
        public int SDT { get; set; }
        public string NAME { get; set; }
        public string ADDRESS { get; set; }
        public int ROLES { get; set; }
        public System.DateTime CREATEAT { get; set; }
    }
}
