using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İkas_Entegrasyonu.Model
{
    internal class markaListele
    {
        public class Data
        {
            public List<ListProductBrand> listProductBrand { get; set; }
        }

        public class ListProductBrand
        {
            public string name { get; set; }
            public string id { get; set; }
            public object updatedAt { get; set; }
        }

        public class Root
        {
            public Data data { get; set; }
        }
    }
}
