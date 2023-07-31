using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTM
{

     public class Item
    {
        public string Name { get; set; }
        // material icon Pack kind name
        public string Kind { get; set; }

        public string Key { get; set; }

    }

    public class Group
    {
        public string Name { get; set; }
        // material icon Pack kind name
        public string Kind { get; set; }
        public string Key { get; set; }

        public ObservableCollection<Item> Children { get; set; }
        
    }
   

}
