using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace supershop
{
    public class MyButton: Button
    {
        private string _position;
        private string _backgroundColor = "#C00A27";
        private string _menuID;
        private double _defaultPrice=0.00;
        private bool _foodstampsPayable =false;
        private string _itemType; // ; // regular food item  = "1" , top level food item =2; 
        private string _itemPopUpHeaderID;
        private string _itemPopUpChoiceText;
        private double _tax1Rate;
        private bool _tax1Apply = false;

        public string Position { get { return _position; } set { _position = value; } }
        public string BackGroundColor { get { return _backgroundColor; } set { _backgroundColor = value; } }
        public string MenuID { get { return _menuID; } set { _menuID = value; } }
        public double DefaultPrice { get { return _defaultPrice; } set { _defaultPrice = value; } }
        public bool FoodstampsPayable { get { return _foodstampsPayable; } set { _foodstampsPayable = value; } }
        public string ItemType { get { return _itemType; } set { _itemType = value; } }
        public string PopUpHeaderID { get { return _itemPopUpHeaderID; } set { _itemPopUpHeaderID = value; } }
        public string PopUpText { get { return _itemPopUpChoiceText; } set { _itemPopUpChoiceText = value; } }
        public double Tax1Rate { get { return _tax1Rate; } set { _tax1Rate = value; } }
        public bool Tax1Apply { get { return _tax1Apply; } set { _tax1Apply = value; } }
        //Color color = System.Drawing.ColorTranslator.FromHtml("#FFCC66");



    }
}
