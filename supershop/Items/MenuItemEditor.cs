using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Items
{
    public partial class MenuItemEditor : Form
    {
        public MenuItemEditor()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void MenuItemEditor_Load(object sender, EventArgs e)
        {

            // pull up a new Item to modify 

            // get items from the database 
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            

            //plu should be number only 
            if (String.IsNullOrEmpty(tbUPC1.Text) || String.IsNullOrWhiteSpace(tbUPC1.Text))
            {
                MessageBox.Show("Please Enter a UPC ");
                tbUPC1.Focus();
            }
            // descriptions should not be null
           else if (String.IsNullOrEmpty(tbDescription.Text) || String.IsNullOrWhiteSpace(tbDescription.Text))
            {
                MessageBox.Show("Please Enter a Description ");
                tbDescription.Focus();
            }
            //price must be set and default to zero or negative 
            else if (String.IsNullOrEmpty(tbPrice.Text) || String.IsNullOrWhiteSpace(tbPrice.Text))
            {
                MessageBox.Show("Please Enter a Price ");
                tbPrice.Focus();
            }

            //Default Printer is set to NONE no need to check for anything here I guess



            else try {

                // create a new Item 
                Items.ItemClass item = new Items.ItemClass();
                item.ItemID = tbItemID.Text.ToString();
                item.ItemUPC1 = tbUPC1.Text.ToString();
                item.ItemPlu = tbPLU.Text.ToString();
                item.ItemDescription = tbDescription.Text.ToString();
                item.ItemPrice = Double.Parse(tbPrice.Text);
                if (cbEBT.Checked) {  item.FoodStampable = "1" ; }  else {  item.FoodStampable= "0"; } // 1 :0;

                    //item.FoodStampable = (cbEBT.Checked) ? "1" : "0" ;
                       

                        MessageBox.Show("EBT-->" + item.FoodStampable);




                    // sqlQuery0 ---> this will not work since if ID is not provided, it will auto increment last one, which 
                    //will mess things up if we try to modify an existing item. 
                    // use sqlQuery1 instead. 
                    string sqlQuery0 = "insert into menu_items" +
                        " (MenuItemID, MenuItemText, DefaultUnitPrice, upc1," +
                        "FoodStampsPayable" +
                        ")" +
                        "values (' " + item.ItemID + "', '"
                                     + item.ItemDescription + "', '"
                                                                        
                                     + item.ItemPrice + "', '"
                                     + item.ItemUPC1 + "', '"
                                     + item.FoodStampable +

                        "')" +
                        "ON DUPLICATE KEY UPDATE " +
                        "MenuItemID = Values(MenuItemID) ," + 
                        "MenuItemText = Values(MenuItemText) ," +
                        "DefaultUnitPrice = Values(DefaultUnitPrice) ," +
                        "upc1 = Values(upc1) ," +

                        " FoodStampsPayable=VALUES(FoodStampsPayable)";


                    string sqlQuery1 = "insert into menu_items" +
                        " ( MenuItemText, DefaultUnitPrice, upc1," +
                        "FoodStampsPayable" +
                        ")" +
                        "values (' " + item.ItemDescription + "', '"
                                    // + item.ItemDescription + "', '"

                                     + item.ItemPrice + "', '"
                                     + item.ItemUPC1 + "', '"
                                     + item.FoodStampable +

                        "')" +
                        "ON DUPLICATE KEY UPDATE " +
                       // "MenuItemID = Values(MenuItemID) ," +
                        "MenuItemText = Values(MenuItemText) ," +
                        "DefaultUnitPrice = Values(DefaultUnitPrice) ," +
                        "upc1 = Values(upc1) ," +

                        " FoodStampsPayable=VALUES(FoodStampsPayable)";



                    DataAccess.ExecuteSQL(sqlQuery1);
                    MessageBox.Show("EBT-->" + item.FoodStampable);
                }

            catch (Exception ex1) {

                MessageBox.Show("MIE Code 98-->"+ex1.Message);

            }


            // keep in mind----> it shouldn't save the data to the database even if it prompts to enter data for empty fields





        }
    }
}
