using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supershop.MenuGroups
{
    class MenuGroupClass
    {
        public Dictionary<string, object> GroupDictionary { get; set; }

        public MenuGroupClass() //Constructor
        {
            this.GroupDictionary = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            this.GroupDictionary.Add(key, value);
            Console.WriteLine("Adding -->" + value + " to [" + key + "]");
        }

        public object Get(string key)
        {
            return this.GroupDictionary[key];
        }
    }
}
