using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace supershop.Items
{
    class ItemClass
    {
        // do we need to make this private ??

        public Dictionary<string, object> itemPropertiesDictionary { get; set; }

        private string _itemID;
        private string _itemDescription;
        private string _itemPlu;
        private double _itemPrice;
        private string _itemUPC1;
        private string _foodStampsPayable;



        public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
        public string ItemPlu { get => _itemPlu; set => _itemPlu = value; }
        public double ItemPrice { get => _itemPrice; set => _itemPrice = value; }
        public string ItemID { get => _itemID; set => _itemID = value; }
        public string ItemUPC1 { get => _itemUPC1; set => _itemUPC1 = value; }
        public string FoodStampable { get => _foodStampsPayable; set => _foodStampsPayable = value; }

        public ItemClass() //Constructor
        {
            this.itemPropertiesDictionary = new Dictionary<string, object>();
        }

        public void Add(string key, object value)
        {
            this.itemPropertiesDictionary.Add(key, value);
            Console.WriteLine("Adding to Item Class  -->" + value + " to [" + key + "]");
        }

        public object Get(string key)
        {
            return this.itemPropertiesDictionary[key];
        }


    }
}
