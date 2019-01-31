using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using MySql.Data.MySqlClient;

namespace supershop.Ordering
{
    public partial class OrderingForm : Form
    {
        public OrderingForm()
        {
            InitializeComponent();
           
        }

        //ArrayList grourList = new ArrayList();

        MenuGroups.MenuGroupClass menuGroup = new MenuGroups.MenuGroupClass();

        ArrayList listOfButtons = new ArrayList();
        Size btnSize = new Size(100, 50);
        string defaultColor = "#C5DCF2";
        public static string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
        public  string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
        public double cartTotal = 0.00;
        public double subTotal = 0.00;
        public double foodstampsTotal = 0.00;
        
        public double taxTotalAmount = 0.00;
        public Button  orderType = new Button();
        private int qtyAmount;
        private double weight;

        //private string labelOrderType;

        //TODO: should not be hardcoded
        SoundPlayer sp = new SoundPlayer(@"C:\Development\STS POS\codecanyon-6317175-advance-point-of-sale-system-pos\POS_Adv_Project_8_5\POS_Source_Code\POS__SQLite\supershop\sounds\error.wav");

        public string OrderType { get => btnOrderType.Text; set => btnOrderType.Text = value; }

        public int QtyAmount { get => qtyAmount; set => qtyAmount = value; }
        public double Weight { get => weight; set => weight = value; }

        private void OrderingForm_Load(object sender, EventArgs e)
        {
            //default display panel ( Pizza ) or the first item in group!
            string defaultPanel = "tableLayoutPanel";
            tabControl1.Controls.Clear(); // clear out all default tabs 

            // connect to the database table; (menugroup )  and get all groups

            // order type 
            Point p = new Point();
            p.X = 632;
            p.Y = 12;
            orderType.Location = (p);


            // get stuff from menu groups table and display to our form

            try {
                string sql = "select MenuGroupID," +    // 0
                            " Description," +
                            " DisplayIndex," +  //2
                            " Hidden," +  //3
                            " Color," +   //4
                            "PictureLocation," +
                            "ShowCaption" + //6
                            " from menugroup";

                DataTable dt = DataAccess.GetDataTable(sql);

                //todo: if connection successfull, proceed, otherwise, show not successfull! 
                /* 1) get each row,  Make a button,  assign values and button properties ( exTags) 
                 * 2) add buttons to collections of this form, and also add to dictionary 
                 * 3) display those buttons on the form  
                 * */

                //MenuGroups.MenuGroupClass menuGroup = new MenuGroups.MenuGroupClass();
                // for debuggging, gets count of rows -1 

                //Console.WriteLine("prev index" +prevIndex);
                //MessageBox.Show(dt.Rows.Count.ToString());
                // this.dataGridView1.Rows.Add(10);
                //DataGridViewButtonColumn col0 = new DataGridViewButtonColumn();
                //DataGridViewButtonColumn col1 = new DataGridViewButtonColumn();
                //col0.UseColumnTextForButtonValue = true; 
                // col1.UseColumnTextForButtonValue = true;

                // dataGridView1.Columns.Add(col1);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MyButton menuGroupButton = new MyButton();

                    string id = dt.Rows[i][0].ToString(); //might need to delete this


                    string description = dt.Rows[i][1].ToString(); 
                    int displayIndex = Int32.Parse(dt.Rows[i][2].ToString());
                    menuGroupButton.Position = dt.Rows[i][2].ToString();
                    string hidden = dt.Rows[i][3].ToString();
                    string color = dt.Rows[i][4].ToString();
                    string imgName = dt.Rows[i][5].ToString();
                    string showCaption = dt.Rows[i][6].ToString();
                    menuGroupButton.Size = btnSize;
                    menuGroupButton.MenuID = dt.Rows[i][0].ToString();


                    // add if for empty color value 
                    if (String.IsNullOrEmpty(color) || String.IsNullOrWhiteSpace(color))
                    {
                        color = defaultColor;
                    }

                    menuGroupButton.BackColor = System.Drawing.ColorTranslator.FromHtml(color);

                    if (showCaption == "1") { menuGroupButton.Text = description; } else { menuGroupButton.Text = ""; }
                    if (hidden == "0")
                    {
                        this.tableLayoutPanel1.Controls.Add(menuGroupButton, (displayIndex % 2), (displayIndex / 2));
                        // makes the button clickable to do actions here 
                        // toggle between display panels 
                        menuGroupButton.Click += new EventHandler(btnControl_Click);
                    }
                    if (hidden == "1")
                    {
                        menuGroupButton.Hide();
                        //MessageBox.Show("we should Hide this!!->" + menuGroupButton.MenuID.ToString());
                        this.tableLayoutPanel1.Controls.Remove(menuGroupButton);
                        Console.WriteLine("we should Hide this!!->" + menuGroupButton.MenuID.ToString());
                    }

                    // image on button

                    if (!String.IsNullOrEmpty(imgName) && !String.IsNullOrWhiteSpace(imgName))
                    {
                        //Console.WriteLine(img_directory+imgName);

                        //TODO: I should have this along with other && 
                        if (File.Exists(img_directory + imgName))
                        {
                            menuGroupButton.Image = Image.FromFile(img_directory + imgName);

                        }

                    }
                   
                     
                }
                // get every item under every menu group
                /*
                foreach (Control btnControl in tableLayoutPanel1.Controls) {

                    if (btnControl is Button)
                    {

                    btnControl.Click += new EventHandler(btnControl_Click);
                        //MyButton btnControl0  = (MyButton)btnControl;
                        // Button btnControl = (Button)sender;
                        //string x = btnControl0.Position.ToString();
                        //Console.WriteLine("itemButton position--> " + btnControl0.Position.ToString());
                        // tableLayoutPanel2.Controls.Add(btnControl);

                        //get items from database 
                        MessageBox.Show("you Clicked " + btnControl.Text.ToString());
                        

                    }//end if


                    } //end foreach

                */
            } // end displaying menu groups


            catch (Exception e1) {
                //MessageBox.Show(e1.Message);
                Console.WriteLine("132 Ordering Form-->"+e1.Message);
            } // end try - catch

            this.txtUPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);

            
            
            ///////////////////////////// Load (Food) Items from database to their tabs ///////////
            // tableLayoutPanel2.Hide();
            // tableLayoutPanel3.Show();

            // for each menu group,make a panel, then save items to each panel 

            foreach (MyButton mnuGroupBtn in this.tableLayoutPanel1.Controls) {
               // String _tabPageName = "tabPage" + mnuGroupBtn.MenuID.ToString();
                TabPage _tabPage = new TabPage();
                _tabPage.Text = mnuGroupBtn.Text;
                _tabPage.Name = "tabPage-" + mnuGroupBtn.MenuID.ToString();
                int mnuGID = Int32.Parse(mnuGroupBtn.MenuID.ToString());
                tabControl1.TabIndex = Int32.Parse(mnuGroupBtn.MenuID.ToString());
                

                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.ColumnCount = 4;
                tlp.RowCount = 8;
                tlp.Size = new Size(500, 900);
                
                tlp.BackColor = Color.Red;
                
                _tabPage.Controls.Add(tlp);

                //getting the corresponding buttons (items) for each group 
                try
                {
                    Console.WriteLine("do we get here?178");
                    string sqlQuery2 = "select MenuItemText," +    // 0
                           " DefaultUnitPrice," + //1
                           " DisplayIndex," +  //2
                           "FoodStampsPayable,"+ //3
                           " MenuItemType," +  //4
                           " MenuItemPopUpHeaderID," +  //5
                           " MenuItemPopUpChoiceText," +  //6
                           " MenuItemID," + //7
                           "MenuItemTaxable"+ //8
                    //   " from menu_items where MenuGroupId = 2" ;
                    " FROM  menu_items  where MenuGroupId = " + mnuGID;// + '"' ;

                    DataTable dataTable = DataAccess.GetDataTable(sqlQuery2);

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {

                       // Console.WriteLine("do we get here? 189");
                        string itemText = dataTable.Rows[i][0].ToString();
                        double itemDefaultPrice;
                        bool tax1Apply;
                        

                        Double.TryParse(dataTable.Rows[i][1].ToString(), out itemDefaultPrice);

                        int displayIndex = Int32.Parse(dataTable.Rows[i][2].ToString());

                        Console.WriteLine("about to make the button ");
                        MyButton itemBtn = new MyButton();
                        itemBtn.Text = itemText;
                        itemBtn.DefaultPrice = itemDefaultPrice;
                        itemBtn.Size = new Size (100, 50);

                        itemBtn.FoodstampsPayable = bool.Parse(dataTable.Rows[i][3].ToString());
                        itemBtn.Tax1Apply = bool.Parse(dataTable.Rows[i][8].ToString());

                        itemBtn.ItemType = dataTable.Rows[i][4].ToString();
                        itemBtn.PopUpHeaderID = dataTable.Rows[i][5].ToString();
                        itemBtn.PopUpText = dataTable.Rows[i][6].ToString();
                        itemBtn.MenuID = dataTable.Rows[i][7].ToString();
                        


                        Console.WriteLine(itemBtn.PopUpHeaderID+"----< pop up header id is-->"+itemBtn.PopUpText.ToString());


                        //if top level item, make the panel 
                        if (itemBtn.ItemType == "2" ) {        //&& !string.IsNullOrWhiteSpace(itemBtn.PopUpHeaderID)) {
                            Console.WriteLine("We Should make a tab for "+itemBtn.Text.ToString());
                            Console.WriteLine(itemBtn.MenuID.ToString() + "Menu ID is-->" );
                            makeTopLevelPanel(itemBtn);

                        }
                        
                        // once clicked,  add to event handler
                        itemBtn.Click += new EventHandler(itemBtnControl_Click);


                        Console.WriteLine("made button-->"+itemBtn.Text.ToString());
                        //tlp.Controls.Add(itemBtn);
                        tlp.Controls.Add(itemBtn, (displayIndex % 4), (displayIndex / 4));
                        Console.WriteLine("adding this button to contorl??? " + itemBtn.Text.ToString()+"--tab-->"+_tabPage.Text.ToString());

                    }

                }
                catch (Exception e3) {
                    MessageBox.Show("Exception Line182-ORDERINGFORM" + e3.Message);
                    
                }
                
                // Console.WriteLine("show this group-->" + mnuGroupBtn.Position.ToString());
                this.tabControl1.Controls.Add(_tabPage);
            }   


        }//end ordering form load


        // this will happen once itemButton is clicked 
        private void itemBtnControl_Click(object sender, EventArgs e)
        {
            

            MyButton _itemButton = sender as MyButton;

            // TODO: check what kind of button is clicked ( pizza, grocery, random weight, etc..)

            Console.WriteLine("this button type --------------->"+_itemButton.ItemType);
            if (_itemButton.ItemType == "2") {
                Console.WriteLine("should be type 2? --------------->" + _itemButton.ItemType);
                Console.WriteLine("now, call the form for this");



            }

            // TODO: check what kind of button is clicked ( pizza, grocery, random weight, etc..)

            int n = dataGridView1.Rows.Add(); // n is the row number 

                       
            Int32.TryParse(tbQty.Text.ToString(),out qtyAmount);

            //TODO: implement the '@' function ( multiplication ) 
            dataGridView1.Rows[n].Cells[0].Value = QtyAmount; //qtyAmount.ToString();

            dataGridView1.Rows[n].Cells[1].Value = _itemButton.Text.ToString(); // description
            dataGridView1.Rows[n].Cells[2].Value = _itemButton.DefaultPrice;

            if (_itemButton.FoodstampsPayable == true)
            {
                dataGridView1.Rows[n].Cells[4].Value = "FS";
                //updateFoodStamps(n, _itemButton.DefaultPrice);
            }
            else 
            {
                dataGridView1.Rows[n].Cells[4].Value = "N/F";
            }

            if (_itemButton.Tax1Apply == true) {
                dataGridView1.Rows[n].Cells[5].Value = "Tx1";
                //TODO: get tax1 rate from store config  - there might be rates as tax1,2 and 3 ( we might need a class for this)
                // try catch, if tax is not set or 0
                updateTax(n, _itemButton.DefaultPrice);

            }
            else
            {
                dataGridView1.Rows[n].Cells[5].Value = "N/T";
            }
            
            // update cart - to show price 
            updateCart(n, _itemButton.DefaultPrice);
            updateSubTotal00();
            
            tbQty.Text = "1"; // reset qty to 1 as the default
            txtUPC.Focus(); // so it could always be available for scanning items
            

        }


        private void updateSubTotal00() {
            subTotal = 0;
            foodstampsTotal = 0;
            taxTotalAmount = 0;
            cartTotal = 0;

            double itemQty;
            double itemUnitPrice;
            double rowPrice;
            string fs;
            string tx;
            double tax1Rate = 0.08;  // TODO: get tax rates from store config 
            double rowTaxAmount;
            double rowFSAmount;

            for (int i=0; i<dataGridView1.RowCount; i++) {
                Double.TryParse(dataGridView1.Rows[i].Cells[0].Value.ToString(), out itemQty);
                Double.TryParse(dataGridView1.Rows[i].Cells[2].Value.ToString(), out itemUnitPrice);
                

                rowPrice = itemQty * itemUnitPrice;
                dataGridView1.Rows[i].Cells[3].Value = rowPrice.ToString();
                if (dataGridView1.Rows[i].Cells[5].Value == "Tx1")
                {
                    rowTaxAmount = rowPrice* tax1Rate;
                    taxTotalAmount += rowTaxAmount;
                }

                if (dataGridView1.Rows[i].Cells[4].Value == "FS")
                {
                    rowFSAmount = rowPrice;
                    foodstampsTotal += rowFSAmount;
                }

                subTotal += rowPrice;
               
            }
            
            
            lblSubtotal.Text = "$" +subTotal.ToString();
            txTotal.Text = "$" + taxTotalAmount.ToString();
            fsTotal.Text = "$" + foodstampsTotal.ToString();
            cartTotal = subTotal + taxTotalAmount;

            totalAmount.Text = "$" + cartTotal.ToString();

        }

        private void updateCartTotal() {

            //cartTotal = subTotal + taxTotalAmount;
            for (int i = 0; i < dataGridView1.RowCount; i++) {



            }



            totalAmount.Text = "$"+ cartTotal.ToString();
        }

        private void updateCart(int x, double p) {

            dataGridView1.Rows[x].Cells[0].Value = QtyAmount;
            dataGridView1.Rows[x].Cells[2].Value = p;


        }

        private void makeTopLevelPanel(MyButton btn) {
            Console.WriteLine("                  Making the tab page-->");
            TabPage _tabPage = new TabPage();

            _tabPage.Text = btn.Text;
            _tabPage.Name = "tabPage+" + btn.MenuID.ToString();
            int mnuGID = Int32.Parse(btn.MenuID.ToString());

            Console.WriteLine("                     tab page created --->");


            // make the button panel for the items 
            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.ColumnCount = 4;
            tlp.RowCount = 8;
            tlp.Size = new Size(500, 900);

            tlp.BackColor = Color.Blue;

            _tabPage.Controls.Add(tlp);

            // add the panel to the tab control
            this.tabControl1.Controls.Add(_tabPage);
        }

        //add sublevel items to toplevel item's tab page
        private void addSublevelBtn(MyButton btn) {

            if (string.IsNullOrEmpty(btn.PopUpHeaderID.ToString()) && string.IsNullOrWhiteSpace(btn.PopUpHeaderID.ToString())) {

                tabControl1.Controls.Add(btn);

            }

        }

        private void updateFoodStampsDelete(int x, double p) {
            foodstampsTotal += QtyAmount * p; //  Double.Parse(dataGridView1.Rows[x].Cells[2].Value.ToString());
            fsTotal.Text = "$ " + foodstampsTotal.ToString();
        }


        private void updateTax(int x, double p)
        {
            double tax1Rate = 0.08;  // TODO: get tax rates from store config 

            //Double.TryParse(dataGridView1.Rows[x].Cells[2].Value.ToString());
            //taxTotalAmount +=
            taxTotalAmount += QtyAmount * p * tax1Rate;

            txTotal.Text = "$ " + taxTotalAmount.ToString();
        }



        private void btnControl_Click(object sender, EventArgs e)
        {
            MyButton btn = sender as MyButton;

            Console.WriteLine("we should get this-->"+btn.MenuID.ToString());
            // tabControl1.SelectedIndex = Int32.Parse(btn.MenuID.ToString())+1;
            //tabControl1.SelectTab(Int32.Parse(btn.MenuID.ToString()));
            //tabControl1.SelectedTab = "tabPage2";
            tabControl1.SelectTab("tabPage-"+btn.MenuID.ToString());

            //MessageBox.Show("MenuId-->"+btn.MenuID.ToString());
            
            //this.defaultPanel = "tableLayoutPanel";

          /*
            foreach (Control itemButton in tableLayoutPanel2.Controls) {
                // MyButton(itemButton)
                Console.WriteLine("itemButton-->" + itemButton.Text.ToString());

            }

            */
          /*
          MyButton btnControl = sender as MyButton;
          Console.WriteLine("We just clicked"+ btnControl.Position.ToString());
          */
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            string input = txtUPC.Text.ToString();
            if (e.KeyChar == (char)Keys.Return)

            {
                //check if null or empty 
                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    //MessageBox.Show("Enter something");
                    //play error sound 
                    sp.Play();
                }

                //TODO: also play sound if item does not exist 

                //TODO: also play sound if item does not have a price and prompt user for price 
                //TODO: do not allow white spaces in between input. and do not allow any other special chars
                //TODO: check for sql injection
                
                Console.WriteLine("looking this up->"+ input);

                try {

                    // check if random weight item ( starts with 2) and has at least another 5 digits for plu and 5 digits for price
                    //todo try catch here if the input is less than 12 digits
                    if (input.Substring(0,1) == "2" && input.Length>11) {
                        
                        string plu = input.Substring(1,5);
                        int totalItemPrice = Int32.Parse(input.Substring(6, 5));
                        Decimal decimalPrice  = totalItemPrice / 100m;  //2 10111 027695


                        // string totalPriceString = input.Substring(7,5);//(originalValue / 100m).ToString("C2");
                        Console.WriteLine("--------------> plu is "+plu+"\n price $"+ decimalPrice);
                    }
                    string sqlQueryTest = "select distinct " +
                        "name," +
                        "unitPrice"+
                        " from grocery_test  where upc12  = '" + txtUPC.Text + "'";
                    DataTable dt = DataAccess.GetDataTable(sqlQueryTest);


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        
                        string itemName = dt.Rows[i][0].ToString();
                        string unitPrice = dt.Rows[i][1].ToString();
                        label1.Text += itemName + "\n";
                        if (unitPrice=="0") {
                            sp.Play();
                            EntryForms.ManualPriceEntry mpe = new EntryForms.ManualPriceEntry();
                            mpe.ShowDialog();
                            Console.WriteLine("Enter Price ");
                        }
                       
                    }

                    }
                catch (Exception e4) {
                    MessageBox.Show("454" + e4.Message);

                }

                txtUPC.Clear();
                txtUPC.Focus();
            }
        }


        private void button20_Click(object sender, EventArgs e)
        {
            //MenuGroups.MenuGroupClass.Get()
            //    MessageBox.Show(menuGroup.Get("1").ToString());
            //testing adding new lines to the grid
            DataGridView modifiersGrid = new DataGridView();
            modifiersGrid.Columns.Add("h1","h1");
            modifiersGrid.Columns.Add("h2", "h2");
            modifiersGrid.Rows.Add(2);
            modifiersGrid.Rows[0].Cells[0].Value = "bacon";
            modifiersGrid.Rows[0].Cells[1].Value = "1.99";

            modifiersGrid.Rows[1].Cells[0].Value = "chs";
            modifiersGrid.Rows[1].Cells[1].Value = ".99";

            dataGridView1.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Rows.Add(3);
            //dataGridView1.Rows.Add("test" + Environment.NewLine + "\t        topping");
            dataGridView1.Rows[0].Cells[1].Value = "test" + Environment.NewLine + "\t topping";

            dataGridView1.Rows[1].Cells[1].Value = (modifiersGrid.Rows[0].Cells[0].Value.ToString()  
                                                    + modifiersGrid.Rows[0].Cells[1].Value.ToString() +"\n"
                                                    + modifiersGrid.Rows[1].Cells[0].Value.ToString() 
                                                    + modifiersGrid.Rows[1].Cells[1].Value.ToString() + "\n"



                                                    );

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtUPC_TextChanged(object sender, EventArgs e)
        {

        }

        // when sale is cancelled, remove the last id record
        private void cancelSale() {

            MySqlConnection sqlconn = new MySqlConnection(DataAccess._ConnectionString);
            string sql = "Select * from order_headers";
            MySqlCommand sqlCmd = new MySqlCommand(sql, sqlconn);
            sqlconn.Open();
            sqlCmd.CommandText = sql;
            sqlCmd.ExecuteNonQuery();
            int orderId = (Int32)sqlCmd.LastInsertedId;
            MessageBox.Show("we should remove this-->"+orderId);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //cancelSale();
            this.Close();
        }

        private void btnOrderType_Click(object sender, EventArgs e)
        {

            EntryForms.OrderTypeForm otForm = new EntryForms.OrderTypeForm();
            otForm.MdiParent = this.ParentForm;
            otForm.Show();

            

        }

        private void button19_Click(object sender, EventArgs e)
        {
            updateSubTotal00();
        }
    }
}
