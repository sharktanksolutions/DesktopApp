using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supershop
{
    public class ExTag
    {
        public Dictionary<string, object> TagDictionary { get; set; }

        public ExTag() //Constructor
        {
            this.TagDictionary = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            this.TagDictionary.Add(key, value);
            Console.WriteLine("Adding -->" + value + " to [" + key + "]");
        }

        public object Get(string key)
        {
            return this.TagDictionary[key];
        }
    }
}
