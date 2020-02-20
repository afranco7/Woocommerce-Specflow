using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WOOCOMMERCE_SPECFLOW.Api.Domain
{    

        public class Product
        {
            public string name { get; set; }
            public string type { get; set; }
            public string regular_price { get; set; }
            public string description { get; set; }
            public string short_description { get; set; }
            public Category[] categories { get; set; }
            public Image[] images { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
        }

        public class Image
        {
            public string src { get; set; }
        }
    
}
