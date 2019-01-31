using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Text.RegularExpressions;
 

namespace supershop 
{
    public partial class SalesRegisterQC : Form
    {
        /// <summary>
        ///  Author : Tuaha Mohammad 
        ///  Email:   citkar@live.com        ///  
        ///Web:         http://codecanyon.net/user/dynamicsoft/portfolio
        ///Item Link:   http://codecanyon.net/item/advance-point-of-sale-system-pos/6317175
        /// </summary>
        /// <param name="aa"></param>
        /// Developed by DynamicSoft
        // Actual size = 1188, 679

        public SalesRegisterQC()
        {
            InitializeComponent();
            lbluser.Text = UserInfo.UserName;             
          //  this.tabPageSR_Payment.Parent = null; //Hide payment tab
           // tabSRcontrol.TabPages.Remove(tabPageSR_Payment);
            txtBarcodeReaderBox.Focus();
           

            formFunctionPointer += new functioncall(Replicate); // Coin and papernotes
            currency_Shortcuts1.CoinandNotesFunctionPointer = formFunctionPointer;

            numformFunctionPointer += new numvaluefunctioncall(NumaricKeypad);
            currency_Shortcuts1.NumaricKeypad = numformFunctionPointer;
        }

        #region Databind
        //Default Form Load 
        private void SalesRegister_Load(object sender, EventArgs e)
        {
            try
            {
                ItemList_with_images("");

                dtSalesDate.Format = DateTimePickerFormat.Custom;
                dtSalesDate.CustomFormat = "yyyy-MM-dd";


                //Customer Databind 
                string sqlCust = "select   DISTINCT  *   from tbl_customer where PeopleType = 'Customer'";
                DataAccess.ExecuteSQL(sqlCust);
                DataTable dtCust = DataAccess.GetDataTable(sqlCust);
                ComboCustID.DataSource = dtCust;
                ComboCustID.DisplayMember = "Name";
                ComboCustID.Text = "Guest";

                btnCompleteSalesAndPrint.Focus();

                //Load Vat and Discount rate
               // string sqlVatdis = "select * from storeconfig";
              //  DataAccess.ExecuteSQL(sqlVatdis);
                //DataTable dtVatdis = DataAccess.GetDataTable(sqlVatdis);
                 txtVATRate.Text         = vatdisvalue.vat;
                // txtDiscountRate.Text    = vatdisvalue.dis;            


                this.dgrvSalesItemList.Columns.Add("itm", "Items Name");
                this.dgrvSalesItemList.Columns.Add("Am", "Price");
                this.dgrvSalesItemList.Columns.Add("Qty", "Qty");
                this.dgrvSalesItemList.Columns.Add("Total", "Total");             
                this.dgrvSalesItemList.Columns.Add("ID", "ID");
                this.dgrvSalesItemList.Columns.Add("disamt", "Disamt");     // 5. new in 8.1 version
                this.dgrvSalesItemList.Columns.Add("taxamt", "taxamt");     // 6. new in 8.1 version
                this.dgrvSalesItemList.Columns.Add("dis", "Dis");           // 7. new in 8.1 version
                this.dgrvSalesItemList.Columns.Add("taxapply", "Tax");      // 8. new in 8.1 version
                this.dgrvSalesItemList.Columns.Add("kitdisplay", "KD");      // 8. new in 8.3.1 version

                //Hide fields
                dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
                dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
                dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
                dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version
                dgrvSalesItemList.Columns[9].Visible = false; // kitdisplay    // new in 8.3.1 version

                //Font size of columns and aligmnet  // add in from version 8.3
                dgrvSalesItemList.Columns["itm"].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9);
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgrvSalesItemList.Columns["taxapply"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
               

               ///// dataGridView1.Rows.Add(1);         
               
                DataGridViewButtonColumn inc = new DataGridViewButtonColumn();
                dgrvSalesItemList.Columns.Add(inc);
                inc.HeaderText = "Inc";
                inc.Text = "+";
                inc.Name = "inc";
                inc.ToolTipText = "Increase Item Qty";
                inc.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn minus = new DataGridViewButtonColumn();
                dgrvSalesItemList.Columns.Add(minus);
                minus.HeaderText = "Dec";
                minus.Text = "-";
                minus.Name = "minus";
                minus.ToolTipText = "minus Item Qty";
                minus.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                dgrvSalesItemList.Columns.Add(del);
                del.HeaderText = "Del";
                del.Text = "x";
                del.Name = "del";
                del.ToolTipText = "Delete this Item";
                del.UseColumnTextForButtonValue = true;
                

               // this.dgrvSalesItemList.Rows[0].Cells[2].Value = "1";
               //  dgrvSalesItemList.ReadOnly = true;
                dgrvSalesItemList.Columns[0].ReadOnly = true;
                dgrvSalesItemList.Columns[1].ReadOnly = true;
                dgrvSalesItemList.Columns[2].ReadOnly = false;
                dgrvSalesItemList.Columns[3].ReadOnly = true;
                dgrvSalesItemList.Columns[4].ReadOnly = true;
                dgrvSalesItemList.Columns[5].ReadOnly = true;
                dgrvSalesItemList.Columns[6].ReadOnly = true;
                dgrvSalesItemList.Columns[7].ReadOnly = true;
                dgrvSalesItemList.Columns[8].ReadOnly = true;
                dgrvSalesItemList.Columns[9].ReadOnly = true;

                //Qty column row color
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.ForeColor = Color.Black;
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.BackColor = Color.Silver;
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.SelectionForeColor = Color.Black;
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.SelectionBackColor = Color.Silver;
                dgrvSalesItemList.Columns["Qty"].DefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

                

                //  Column width
                dgrvSalesItemList.Columns["itm"].Width = 200;
                dgrvSalesItemList.Columns["Del"].Width = 11;
                dgrvSalesItemList.Columns["inc"].Width = 35;
                dgrvSalesItemList.Columns["minus"].Width = 35; 

               // dgrvSalesItemList.Rows[0].Cells[2].Style.BackColor = Color.Red;
               // DataGridViewColumn ColQty = dgrvSalesItemList.Columns[2];
               // ColQty.Width = 45;


                //Load Invoice No / Receipt No for current transaction
                string sql = "select sales_id from sales_payment order by sales_id desc";
                DataTable dt = DataAccess.GetDataTable(sql);
                if (dt.Rows.Count > 0)
                {
                    double id = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()) + 1;
                    //  txtInvoiceNo.Text = Convert.ToString(id);
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                   // btnInvoiceNo.Text = id.ToString();
                }
                else
                {
                    double id = 1;
                    // txtInvoiceNo.Text = Convert.ToString(id);
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                   // btnInvoiceNo.Text = id.ToString();
                }              
              
            }
            catch //(Exception ex)
            {
               //MessageBox.Show(ex.Message);
            }
        }
                
        //Show Products image
        public void ItemList_with_images(string value)
        {
            flowLayoutPanelItemList.Controls.Clear();
            string img_directory = Application.StartupPath + @"\ITEMIMAGE\";
            string[] files = Directory.GetFiles(img_directory, "*.png *.jpg");
            try
            {
                string sql = " select  *  from  vw_itemdisplay_sr    where  ( product_name like '" + value + "%' and product_quantity >= 1) " +
                " OR ( product_id like '" + value + "%'  and product_quantity >= 1) " +
                " OR (category like '" + value + "%' and   product_quantity >= 1)  ";
                //" ORDER BY RANDOM() LIMIT 12 "; // Sqlite  //View vw_itemdisplay_sr   purchase
               // " ORDER BY RAND() LIMIT 12 "; // MySQL
              //  " ORDER BY NEWID() "; // SQL server and use -- top 12 after select  

                DataAccess.ExecuteSQL(sql);
                DataTable dt = DataAccess.GetDataTable(sql);

                int currentImage = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dataReader = dt.Rows[i];

                    Button b = new Button();
                    //Image i = Image.FromFile(img_directory + dataReader["name"]);
                    b.Tag = dataReader["product_id"];
                    b.Click += new EventHandler(b_Click);

                    string taxapply;
                    if (dataReader["taxapply"].ToString() == "1")
                    {
                        taxapply = "YES";
                    }
                    else
                    {
                        taxapply = "NO";
                    }

                    string details = dataReader["product_id"] +
                     "\n Name: " + dataReader["product_name"].ToString() +
                  //   "\n Buy price: " + dataReader["cost_price"].ToString() +
                     "\n Stock Qty: " + dataReader["product_quantity"].ToString() +
                     "\n Retail price: " + dataReader["retail_price"].ToString() +
                     "\n Discount: " + dataReader["discount"].ToString() +
                     "\n Category: " + dataReader["category"].ToString() +
                     "\n Supplier: " + dataReader["supplier"].ToString() +
                   //  "\n Branch: "  + dataReader["Shopid"].ToString() +
                     "\n Tax Apply: " + taxapply;
                    b.Name = details;                 
                     toolTip2.ToolTipTitle = "Item Details";  // If you want to Show tooltip please uncomment
                     toolTip2.SetToolTip(b, details);          //Umncomment

                    ImageList il = new ImageList();
                    il.ColorDepth = ColorDepth.Depth32Bit;
                    il.TransparentColor = Color.Transparent;
                    il.ImageSize = new Size(55, 45);
                    il.Images.Add(Image.FromFile(img_directory + dataReader["imagename"]));
                   

                    b.Image = il.Images[0];
                    b.Margin = new Padding(3, 3, 3, 3);

                    b.Size = new Size(87, 60);
                    b.Text.PadRight(4);
                    
                  //  b.Text += " " + dataReader["product_id"] + "\n ";
                  //   b.Text +=  dataReader["product_name"].ToString();
                  //  b.Text += "\n Buy: " + dataReader["cost_price"];
                //    b.Text += "\n Stock: " + dataReader["product_quantity"];
                  //  b.Text += "\n R.Price: " + dataReader["retail_price"];
                //    b.Text += "\n Dis: " + dataReader["discount"] + "% ";   //"Tax: " + taxapply;

                    b.Font = new Font("Arial", 9, FontStyle.Bold, GraphicsUnit.Point);
                    b.TextAlign = ContentAlignment.TopLeft;
                    b.TextImageRelation = TextImageRelation.ImageAboveText;
                  //  b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    flowLayoutPanelItemList.Controls.Add(b);
                    currentImage++;

                }
            }
            catch //(Exception)
            {

                //throw;
            }
        }
       
        //Product filter by Product Name or Product ID
        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            try
            {   

                ItemList_with_images(txtSearchItem.Text);
            }
            catch
            {
            }
      
            
        }
     

        //Click add to cart
        protected void b_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            string s;
            s = " ID: ";
            s += b.Tag;
            s += "\n Name: ";
            s += b.Name.ToString();

             txtBarcodeReaderBox.Text = b.Tag.ToString();  

        }

        //// BarCode or keyboard input  items code  || add to cart
        private void txtBarcodeReaderBox_TextChanged(object sender, EventArgs e)
        {
            if (txtBarcodeReaderBox.Text == "")
            {
                //  MessageBox.Show("Please Insert Product id : ");
                //textBox1.Focus();
            }
            else
            {
                try
                {
                    dgrvSalesItemList.Visible = true;
                    // Default tax rate 
                    double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                    //- new in 8.1 version // Default Product QTY is 1
                    string sql = "SELECT  product_name as Name , retail_price as Price , 1.00  as QTY, (retail_price * 1.00 ) * 1.00  as 'Total' ,  " +
                            " (((retail_price * 1.00 ) * discount) / 100.00) as 'dis amt' , " +
                            " CASE     " +
                            " WHEN taxapply = 1 THEN   (((retail_price * 1.00 )  - (((retail_price * 1.00 ) * discount) / 100.00))  * " + Taxrate + " ) / 100.00   " +
                            " ELSE '0.00'  " +
                            " END 'taxamt' , product_id as ID , discount , taxapply, status " +
                            " FROM  purchase  where product_id = '" + txtBarcodeReaderBox.Text + "'  and product_quantity >= 1 ";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt = DataAccess.GetDataTable(sql);

                    string ItemsName    = dt.Rows[0].ItemArray[0].ToString();
                    double Rprice       = Convert.ToDouble(dt.Rows[0].ItemArray[1].ToString());
                    double Qty          = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
                    double Total        = Convert.ToDouble(dt.Rows[0].ItemArray[3].ToString()) * Qty;
                    string Itemid       = dt.Rows[0].ItemArray[6].ToString();
                    double Disamt       = Convert.ToDouble(dt.Rows[0].ItemArray[4].ToString());       //  Total Discount amount of this item
                    double Taxamt       = Convert.ToDouble(dt.Rows[0].ItemArray[5].ToString());       //  Total Tax amount  of this item
                    double Dis          = Convert.ToDouble(dt.Rows[0].ItemArray[7].ToString());       //  Discount Rate
                    double Taxapply     = Convert.ToDouble(dt.Rows[0].ItemArray[8].ToString());       //  VAT/TAX/TPS/TVQ apply or not
                    int kitchendisplay  = Convert.ToInt32(dt.Rows[0].ItemArray[9].ToString());        //  kitchen display 3= show 1= not display in kitchen 

                    //Add to Item list
                   // long i = 1;
                    int n = Finditem(ItemsName);
                    if (n == -1)  //If new item
                    {                        
                        dgrvSalesItemList.Rows.Add(ItemsName, Rprice, Qty, Rprice, Itemid, Disamt, Taxamt, Dis, Taxapply, kitchendisplay);
                    }
                    else  // if same item Quantity increase by 1 
                    {
                      //  dgrvSalesItemList.Rows[n].Cells[0].Value = ItemsName;
                       // dgrvSalesItemList.Rows[n].Cells[1].Value = Rprice;
                        int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                        dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                        dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                      //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     

                        double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);                    
                        double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);     
      
                        if (disrate != 0)  // if discount has
                        {
                            double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                            dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                        }

                        if (Taxapply != 0)   // If apply  tax 
                        {
                            // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                            double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                            dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                        }

                       // dgrvSalesItemList.Rows[n].Cells[7].Value = Dis; // Discount rate
                      //  dgrvSalesItemList.Rows[n].Cells[8].Value = Taxapply;  //Tax apply
                      //  dgrvSalesItemList.Rows[n].Cells[9].Value = kitchendisplay;

                    }                  
                   

                    //Hide fields
                    dgrvSalesItemList.Columns[4].Visible = false; // ID             // new in 8.1 version
                    dgrvSalesItemList.Columns[5].Visible = false; // Disamt         // new in 8.1 version
                    dgrvSalesItemList.Columns[6].Visible = false; // taxamt         // new in 8.1 version
                    dgrvSalesItemList.Columns[7].Visible = false; // Discount rate  // new in 8.1 version
                    dgrvSalesItemList.Columns[9].Visible = false; // kitdisplay    // new in 8.3.1 version

               

                    btnSuspend.Enabled = true;
                    btnPayment.Enabled = true;
                    btnCompleteSalesAndPrint.Enabled = true;
                    btnSaveOnly.Enabled = true;

                    DiscountCalculation();
                    vatcal();
                    txtDiscountRate.Text = "0";

                    txtBarcodeReaderBox.Text = "";
                    txtBarcodeReaderBox.Focus();
                   // lbloveralldiscount.Text = "0";

                    if (dt.Rows.Count > 0)
                    {
                        lblNotFound.Visible = false;
                    }

                    else
                    {
                        lblNotFound.Visible = true;
                    }
                }

                catch
                {
                    //MessageBox.Show("sorry");
                }
            }
        }

        // Check duplicate item 
        public int Finditem(string item)
        {
            int k = -1;
            if (dgrvSalesItemList.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgrvSalesItemList.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(item))
                    {
                        k = row.Index;
                        break;
                    }
                }
            }
            return k;
        }
        #endregion
        

        // Discount Calculation - Change in 8.1 version
        public void DiscountCalculation()
        {
            // // subtotal without dis vat sum 
            double totalsum = 0.00;
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                totalsum += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value);
            }
            lblTotal.Text = Math.Round(totalsum, 2).ToString();
            lblTotalItems.Text = dgrvSalesItemList.RowCount.ToString();
            
            ////    Discount amount sum
            double total = Convert.ToDouble(totalsum.ToString());
            double DisCount = 0.00;
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                DisCount += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[5].Value);
            }           

            DisCount = Math.Round(DisCount, 2);
            double sum = total - DisCount;
            sum = Math.Round(sum, 2);
            lblsubtotal.Text = sum.ToString();

            double payable = sum + Convert.ToDouble(lblTotalVAT.Text);
            payable = Math.Round(payable,2);
            lblTotalPayable.Text = payable.ToString();

            lblTotalDisCount.Text = DisCount.ToString();
            lbloveralldiscount.Text = DisCount.ToString();
           // btnPayment.Text = "Pay = " + payable.ToString();

            tabPageSR_Counter.Text = "Terminal (" + dgrvSalesItemList.RowCount.ToString() + ")";
          //  tabPageSR_Payment.Text = "Payment (" + payable.ToString() + ")";
        }

        //VAT amount sum calculation - Change in 8.1 version
        public void vatcal()
        {
            //Subtotal = total - (discount + Globaldiscount)
            double Subtotal = Convert.ToDouble(lblsubtotal.Text);            
            //double Subtotal = Convert.ToDouble(lbloveralldiscount.Text)  ;

            //VAT amount
            double VAT = 0.00;
            for (int i = 0; i < dgrvSalesItemList.Rows.Count; ++i)
            {
                VAT += Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[6].Value);
            }

            VAT = Math.Round(VAT, 2);
            lblTotalVAT.Text = VAT.ToString();

            double payable = Subtotal + VAT;
            payable = Math.Round(payable, 2);
            lblTotalPayable.Text = payable.ToString();

           // btnPayment.Text = "Pay = " + payable.ToString();
	    
	      ///////Pole shows Price value  | if you have pole device please UnComment   below code
		//SerialPort sp = new SerialPort();
		//sp.PortName = "COM1";  ////Insert your pole Device Port Name E.g. COM4  -- you can find  from pole device manual  
		//sp.BaudRate = 9600;     // Pole Bound Rate 
		//sp.Parity = Parity.None;
		//sp.DataBits = 8;   // Data Bits
		//sp.StopBits = StopBits.One;
		//sp.Open();                 
		//sp.WriteLine(lblTotalPayable.Text);

		//sp.Close();
		//sp.Dispose();
		//sp = null;
        }
        
        // Sales item   Increase , Decrease and Delete Options
        private void dgrvSalesItemList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
             
                // Delete items From Gridview
                if (e.ColumnIndex == dgrvSalesItemList.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgrvSalesItemList.SelectedRows)
                    {
                      //  DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                      //  if (result == DialogResult.Yes)
                      //  {
                            if (!row2.IsNewRow)
                                dgrvSalesItemList.Rows.Remove(row2);
                            DiscountCalculation();
                            vatcal();
                            txtDiscountRate.Text = "0";
                           // lbloveralldiscount.Text = "0";
                       // }
                    } 
                }

                // Increase Item Quantity
                if (e.ColumnIndex == dgrvSalesItemList.Columns["inc"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {

                        //if (Convert.ToDouble(row.Cells[6].Value) <= 0)
                        //{
                        //    MessageBox.Show("You don't have sufficient item Quantity \n\n Your  Item Quantity is greater than Stock Qty");
                        //}
                        //else
                        //{
                            //// Increase by 1
                            double qtySum = Convert.ToDouble(row.Cells[2].Value) + 1;
                            row.Cells[2].Value = qtySum;

                            double qty      = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double disrate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice; 
                            row.Cells[3].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }                      
                        

                            DiscountCalculation();
                            vatcal();

                            txtDiscountRate.Text = "0";                       
                     
                    }
                }

                // Decrease Item Quantity  -- Add new from 8.3.2
                if (e.ColumnIndex == dgrvSalesItemList.Columns["minus"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        if (Convert.ToDouble(row.Cells[2].Value)  >  1)
                        {
                            //// Decrease by 1 
                            double qtySum = Convert.ToDouble(row.Cells[2].Value) - 1;
                            row.Cells[2].Value = qtySum;

                            double qty = Convert.ToDouble(row.Cells[2].Value);
                            double Rprice = Convert.ToDouble(row.Cells[1].Value);
                            double disrate = Convert.ToDouble(row.Cells[7].Value);
                            double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                            //// show total price   Qty  * Rprice
                            double totalPrice = qty * Rprice;
                            row.Cells[3].Value = totalPrice;

                            if (Convert.ToDouble(row.Cells[7].Value) != 0)
                            {
                                double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                                row.Cells[5].Value = Disamt;
                            }

                            if (Convert.ToDouble(row.Cells[8].Value) != 0)
                            {
                                double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                                row.Cells[6].Value = Taxamt;
                            }

                            DiscountCalculation();
                            vatcal();

                            txtDiscountRate.Text = "0";  
                        }
                   
                    }
                }

            }
            catch //(Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }
        
        //Input Item Quantity
        private void dgrvSalesItemList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Increase Item Quantity with Edited cell
                if (e.ColumnIndex == dgrvSalesItemList.Columns["Qty"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        // Total Price
                       // double totalPrice = Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[1].Value);
                       // row.Cells[3].Value = totalPrice;

                        double qty = Convert.ToDouble(row.Cells[2].Value);
                        double Rprice = Convert.ToDouble(row.Cells[1].Value);
                        double disrate = Convert.ToDouble(row.Cells[7].Value);
                        double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                        //// show total price   Qty  * Rprice
                        double totalPrice = qty * Rprice;
                        row.Cells[3].Value = totalPrice;

                        if (Convert.ToDouble(row.Cells[7].Value) != 0)  // IF discount is not zero then apply discount
                        {
                            double Disamt = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                            row.Cells[5].Value = Disamt;
                        }

                        if (Convert.ToDouble(row.Cells[8].Value) != 0)  // IF tax is not zero then apply tax
                        {
                            double Taxamt = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00); // Total Tax amount  of this item
                            row.Cells[6].Value = Taxamt;
                        }

                        DiscountCalculation();
                        vatcal();
                        txtDiscountRate.Text = "0";
                    }
                }
            }
            catch
            {
            }

        }
        
        // Auto Invoice.No Shows 
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                string sql = "select  sales_id  from sales_payment order by sales_id desc";
                DataTable dt = DataAccess.GetDataTable(sql);      
                if (dt.Rows.Count > 0)
                {
                    double id = Convert.ToDouble(dt.Rows[0].ItemArray[0].ToString()) + 1;               
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                  //  btnInvoiceNo.Text = "# " + Convert.ToString(id);
                }
                else
                {
                    double id = 1;           
                    txtInvoice.Text = Convert.ToString(Convert.ToInt32(id));
                   // btnInvoiceNo.Text = btnInvoiceNo.Text = "# " + Convert.ToString(id);
                }
            }
            catch
            {

            } 
        }

        //  Discount
        private void btnIncreaseDisCount_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblTotalPayable.Text == "")
                {
                    MessageBox.Show("Please Add at least One Item");
                }
                else
                {
                    double Discountvalue = Convert.ToDouble(txtDiscountRate.Text);
                    txtDiscountRate.Text = Discountvalue.ToString();
                    double subtotal = Convert.ToDouble(lblTotal.Text) - Convert.ToDouble(lblTotalDisCount.Text); // total - item discount  100 - 5 = 95        
                    double totaldiscount = (subtotal * Discountvalue) / 100;  //Counter discount  // 95 * 5 /100 = 4.75  
                   // double totaldiscount = Convert.ToDouble(lblTotalDisCount.Text) + Discountvalue;   // Uncomment this line if you want to discount value and comment/delete above line
                    double disPlusOverallDiscount = totaldiscount + Convert.ToDouble(lblTotalDisCount.Text); // 4.75 + 5 = 9.75
                    disPlusOverallDiscount = Math.Round(disPlusOverallDiscount, 2);
                    lbloveralldiscount.Text = disPlusOverallDiscount.ToString();  // Overall discount 9.75

                    double subtotalafteroveralldiscount = subtotal - totaldiscount; // 95 - 4.75 = 90.25
                    subtotalafteroveralldiscount = Math.Round(subtotalafteroveralldiscount, 2);
                    lblsubtotal.Text = subtotalafteroveralldiscount.ToString();

                    double payable = subtotalafteroveralldiscount + Convert.ToDouble(lblTotalVAT.Text);
                    payable = Math.Round(payable, 2);
                    lblTotalPayable.Text = payable.ToString();

                  //  btnPayment.Text = "Pay = " + payable.ToString();

                }
            }
            catch
            {
                txtDiscountRate.Text = "0";
            }
 
        }
             

        #region ////////////////  Submit request - New  ////////////////////////
       
        /// //// Add sales item  ////////////Store into sales_item table //////////
        public bool sales_item(string salesdate)
        {
            int rows = dgrvSalesItemList.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                //string SalesDate = dtSalesDate.Text;  
                string trno = txtInvoice.Text;
                string itemid = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                string itNam = dgrvSalesItemList.Rows[i].Cells[0].Value.ToString();
                double qty = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());
                double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[1].Value.ToString());
                double total = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[3].Value.ToString());
                double dis = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[7].Value.ToString()); //discount rate
                double taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[8].Value.ToString());
                int kitchendisplay = Convert.ToInt32(dgrvSalesItemList.Rows[i].Cells[9].Value.ToString());



                // =================================Start=====  Profit calculation =============== Start ========= 
                // Discount_amount = (Retail_price * discount) / 100                    -- 49 * 3 / 100 = 1.47
                // Retail_priceAfterDiscount = Retail_price - Discount_amount           -- 49 - 1.47 = 47.53
                // Profit = (Retail_priceAfterDiscount * QTY )   - (cost_price * qty);  ---( 47.53 * 1 ) - ( 45 * 1) = 2.53

                string sqlprofit = "Select cost_price , discount  from  purchase  where product_id  = '" + itemid + "'";
                DataAccess.ExecuteSQL(sqlprofit);
                DataTable dt1 = DataAccess.GetDataTable(sqlprofit);

                double cost_price = Convert.ToDouble(dt1.Rows[0].ItemArray[0].ToString());
                double discount = Convert.ToDouble(dt1.Rows[0].ItemArray[1].ToString());

                double Discount_amount = (Rprice * discount) / 100.00;
                double Retail_priceAfterDiscount = Rprice - Discount_amount;
                double Profit = Math.Round((Retail_priceAfterDiscount - cost_price), 2); // old calculation (Retail_priceAfterDiscount * qty) - (cost_price * qty);
                // =================================Start=====  Profit calculation =============== Start =========  


                string sql1 = " insert into sales_item (sales_id,itemName,Qty,RetailsPrice,Total, profit,sales_time, itemcode , discount, taxapply, status) " +
                              " values ('" + trno + "', '" + itNam + "', '" + qty + "', '" + Rprice + "', '" + total + "', '" + Profit + "', " +
                              " '" + salesdate + "','" + itemid + "','" + dis + "','" + taxapply + "','" + kitchendisplay + "')";
                DataAccess.ExecuteSQL(sql1);

                //update quantity Decrease from Stock Qty |  purchase Table
                if (txtInvoice.Text == "")
                {
                    MessageBox.Show("please check sales no ");
                }
                else
                {

                    string itemids = dgrvSalesItemList.Rows[i].Cells[4].Value.ToString();
                    double qtyupdate = Convert.ToDouble(dgrvSalesItemList.Rows[i].Cells[2].Value.ToString());

                    // Update Quantity
                    string sqlupdateQty = "select product_quantity  from purchase where product_id = '" + itemids + "'";
                    DataAccess.ExecuteSQL(sqlupdateQty);
                    DataTable dtUqty = DataAccess.GetDataTable(sqlupdateQty);
                    double product_quantity = Convert.ToDouble(dtUqty.Rows[0].ItemArray[0].ToString()) - qtyupdate;

                    string sql = " update purchase set " +
                                    " product_quantity = '" + product_quantity + "' " +
                                    " where product_id = '" + itemids + "' ";
                    DataAccess.ExecuteSQL(sql);
                }

            }
            return true;

        }

        /// //// Payment items Add  ///////////Store into Sales_payment table //////// 
        public void payment_item(string payamount, string changeamount, string dueamount , string salestype, string salesdate, string custid, string Comment)
        {
            string trno             = lblTotalPayable.Text;
           // string payamount        = lblTotalPayable.Text;
          //  string changeamount     = "0";
            //string due              =  "0";
            string vat              = lblTotalVAT.Text;
            string DiscountTotal    = lbloveralldiscount.Text; // Total discount = item wise discount + counter discount
           // string Comment          = "Guest";
            string overalldisRate   = txtDiscountRate.Text;
            string vatRate          = txtVATRate.Text;

             string sql1 =   " insert into sales_payment (sales_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
                            " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate ) " + 
                            "  values ('" + txtInvoice.Text + "','" + CombPayby.Text + "', '" + payamount + "', '" + changeamount + "', " +
                            " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + salesdate + "', '" + lblCustID.Text + "', " +
                            "  '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "' )";
            DataAccess.ExecuteSQL(sql1);

            //string sql1 = " insert into sales_payment (sales_id, payment_type,payment_amount,change_amount,due_amount, dis, vat, " +
            //                " sales_time,c_id,emp_id,comment, TrxType, Shopid , ovdisrate , vaterate ) " +
            //                " values ('" + txtInvoice.Text + "','Cash', '" + payamount + "', '" + changeamount + "', " +
            //                " '" + dueamount + "', '" + DiscountTotal + "', '" + vat + "', '" + DateTime.Now.ToString("yyyy-MM-dd") + "', '10000009', " +
            //                " '" + UserInfo.UserName + "','" + Comment + "','POS','" + UserInfo.Shopid + "' , '" + overalldisRate + "' , '" + vatRate + "' )";
            //DataAccess.ExecuteSQL(sql1);
        }
        #endregion
                
        //paid amount Input Operation
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (lblTotalPayable.Text == "")
            {
                // MessageBox.Show("please insert Amount ");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(txtPaidAmount.Text) >= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(txtPaidAmount.Text) - Convert.ToDouble(lblTotalPayable.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        txtChangeAmount.Text = changeAmt.ToString();
                        txtDueAmount.Text = "0";
                        this.AcceptButton = btnCompleteSalesAndPrint;
                    }
                    if (Convert.ToDouble(txtPaidAmount.Text) <= Convert.ToDouble(lblTotalPayable.Text))
                    {
                        double changeAmt = Convert.ToDouble(lblTotalPayable.Text) - Convert.ToDouble(txtPaidAmount.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        txtDueAmount.Text = changeAmt.ToString();
                        txtChangeAmount.Text = "0";
                        this.AcceptButton = btnCompleteSalesAndPrint;
                    }

                }
                catch //(Exception exp)
                {
                    // MessageBox.Show(exp.Message);
                }

            }
        }
        
        // Sales cart page load
        private void tabPageSR_Counter_Enter(object sender, EventArgs e)
        {
            txtBarcodeReaderBox.Focus();
        }

        // ///// // Button Events 
        //1. Direct sales and print Receipt
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lblTotalPayable.Text == "00" || lblTotalPayable.Text == "0" || lblTotalPayable.Text == string.Empty)
            {
                MessageBox.Show("Sorry ! You don't have enough product in Item cart \n  Please Add to cart", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            else
            {
                ////Save payment info into sales_payment table
                payment_item(lblTotalPayable.Text, "0", "0", "Cash", DateTime.Now.ToString("yyyy-MM-dd").ToString(), "10000009", "Guest");

                ///// save sales items one by one  
                sales_item(DateTime.Now.ToString("yyyy-MM-dd").ToString());

                //btnPayment.Enabled = false;


                ///// // Open Print Invoice
                parameter.autoprintid = "1";
                POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                go.ShowDialog();

                dgrvSalesItemList.Rows.Clear();
                // lblTotalItems.Text = "0";
                DiscountCalculation();
                vatcal();
                btnCompleteSalesAndPrint.Enabled = false;
                btnPayment.Enabled = false;
                //  this.tabPageSR_Payment.Parent = null; //Hide payment tab
            }

        }
        
        //2. only save
        private void btnSaveOnly_Click(object sender, EventArgs e)
        {            
            if (txtPaidAmount.Text == "00" || txtPaidAmount.Text == "0" || txtPaidAmount.Text == string.Empty)
            {
                MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            }
            //else if (Convert.ToInt32(txtInvoice.Text) >= 53)
            //{
            //    MessageBox.Show("Sorry ! Demo version has limited transaction \n Please buy it \n contact at : citkar@live.com \n https://goo.gl/Hs7XsD", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            //}
            else
            {
                try
                {
                    //Save payment info into sales_payment table
                    payment_item(lblTotalPayable.Text,txtChangeAmount.Text, txtDueAmount.Text, CombPayby.Text, dtSalesDate.Text , lblCustID.Text, txtCustName.Text);

                    ///// save sales items one by one 
                    sales_item(dtSalesDate.Text);
                    MessageBox.Show("Successfully has been saved ");
                    //btnCompleteSalesAndPrint.Enabled = false;
                    //btnSaveOnly.Text = "Done";
                    //btnSaveOnly.Enabled = false;

                    //Clean Datagridview and Back to sales cart
                    dgrvSalesItemList.Rows.Clear();
                    DiscountCalculation();
                    vatcal();
                 //   this.tabPageSR_Payment.Parent = null; //Hide payment tab
                    tabSRcontrol.SelectedTab = tabPageSR_Counter;

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }            
        }

        //3. Complete print
        private void btnCompleteSalesAndPrint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to Complete this transaction?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (txtPaidAmount.Text == "00" || txtPaidAmount.Text == "0" || txtPaidAmount.Text == string.Empty)
                {
                    MessageBox.Show("Please insert paid amount. \n  If you want full due transaction \n Please insert 0.00 ", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                }
                //  else if (Convert.ToInt32(txtInvoice.Text) >= 53)
                // {
                //   MessageBox.Show("Sorry ! Demo version has limited transaction \n Please buy it \n contact at : citkar@live.com \n https://goo.gl/Hs7XsD", "Yes or No", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                //  }
                else
                {
                    try
                    {
                        //Save payment info into sales_payment table
                        payment_item(lblTotalPayable.Text, txtChangeAmount.Text, txtDueAmount.Text, CombPayby.Text, dtSalesDate.Text, lblCustID.Text, txtCustName.Text);

                        ///// save sales items one by one 
                        sales_item(dtSalesDate.Text);

                        ///// // Open Print Invoice
                        parameter.autoprintid = "1";
                        POSPrintRpt go = new POSPrintRpt(txtInvoice.Text);
                        go.ShowDialog();

                        //Clean Datagridview and Back to sales cart
                        dgrvSalesItemList.Rows.Clear();
                        DiscountCalculation();
                        vatcal();
                    //    this.tabPageSR_Payment.Parent = null; //Hide payment tab
                        tabSRcontrol.SelectedTab = tabPageSR_Counter;
                        btnCompleteSalesAndPrint.Enabled = false;
                        btnPayment.Enabled = false;
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                }
            }
        }

        //4. Suspend Order/ Cancel transaction
        private void btnSuspend_Click(object sender, EventArgs e)
        {
            try
            {
                dgrvSalesItemList.Rows.Clear();
                dgrvSalesItemList.Visible = false;
                // lblTotalItems.Text = "0";
                txtDiscountRate.Text = "0";
                lbloveralldiscount.Text = "0";
                DiscountCalculation();
                vatcal();
                btnCompleteSalesAndPrint.Enabled = false;
                btnSaveOnly.Enabled = false;
                btnPayment.Enabled = false;
                tabPageSR_Counter.Text = "Terminal";
                txtBarcodeReaderBox.Focus();
                //  this.tabPageSR_Payment.Parent = null; //Hide payment tab
            }
            catch
            {
            }
        }
        
        //Customer filter
        private void ComboCustID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sqlCmd = "Select ID from  tbl_customer  where Name  = '" + ComboCustID.Text + "'";
                DataAccess.ExecuteSQL(sqlCmd);
                DataTable dt1 = DataAccess.GetDataTable(sqlCmd);
                lblCustID.Text = dt1.Rows[0].ItemArray[0].ToString();
            }
            catch
            {
            }
        }
        
        #region  Links
        // Call System Calculator
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // System.Diagnostics.Process.Start("Calc");
                SendKeys.SendWait(lblTotal.Text);
                Process p = new Process();
                p.StartInfo.FileName = "calc.exe";
                p.Start();
                p.WaitForInputIdle();

            }
            catch
            {
            }
        }
       
        //--  new   8.1 version
        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "SRQC";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();

            //SalesRagister.Currency_Shortcuts uc = new SalesRagister.Currency_Shortcuts();
            //uc.Dock = DockStyle.None;
            //panel1.Controls.Add(uc);
           // this.Controls.Add(uc);            
            
          //  tabControl1.SelectedTab = tabterminal;
        }

        ///ShortCut Keys
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.C)) // Cash
            {
                btnPayment.PerformClick();  //Shift+P for Open Payment Page 
            }
            else if (keyData == (Keys.Control | Keys.Enter)) // Ctrl+Enter  
            {
                btnCompleteSalesAndPrint.PerformClick(); 
            }
            else if (keyData == (Keys.Control | Keys.S)) // Ctrl+S  
            {
                btnSaveOnly.PerformClick();  
            }
            else if (keyData == (Keys.Shift | Keys.Delete)) // Shift + Del -> Suspen/clear all items
            {
                btnSuspend.PerformClick(); 
            }
            else if (keyData == (Keys.Control | Keys.B)) // Ctl + B Barcode Cursor
            {
                txtBarcodeReaderBox.Focus();
            }
            else if (keyData == (Keys.F4))  // Selected item delete
            {
                try
                {
                   
                    foreach (DataGridViewRow row in dgrvSalesItemList.SelectedRows)
                    {
                        dgrvSalesItemList.Rows.RemoveAt(row.Index);
                    }
                    DiscountCalculation();
                    vatcal();
                    txtDiscountRate.Text = "0";
                }
                catch
                {
                }
            }
            else if (keyData == (Keys.F6)) // Increase item Qty
            {
                try
                {
                    double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                    int n = dgrvSalesItemList.CurrentCell.RowIndex;

                    double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[1].Value);
                    double Taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[8].Value);

                    int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                    dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc + 1);  //Qty Increase
                    dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc + 1);   // Total price
                    //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     



                    double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                    double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                    if (disrate != 0)  // if discount has
                    {
                        double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                        dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                    }

                    if (Taxapply != 0)   // If apply  tax 
                    {
                        // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                        double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                        dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                    }
                    DiscountCalculation();
                    vatcal();
                }
                catch
                {
                }
            }
            else if (keyData == (Keys.F7)) // Decrease item Qty
            {
                try
                {
                    int n = dgrvSalesItemList.CurrentCell.RowIndex;
                    if (Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value) > 1)
                    {
                        double Taxrate = Convert.ToDouble(vatdisvalue.vat);

                        double Rprice = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[1].Value);
                        double Taxapply = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[8].Value);

                        int QtyInc = Convert.ToInt32(dgrvSalesItemList.Rows[n].Cells[2].Value);
                        dgrvSalesItemList.Rows[n].Cells[2].Value = (QtyInc - 1);  //Qty Increase
                        dgrvSalesItemList.Rows[n].Cells[3].Value = Rprice * (QtyInc - 1);   // Total price
                        //  dgrvSalesItemList.Rows[n].Cells[4].Value = Itemid;                     



                        double qty = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[2].Value);
                        double disrate = Convert.ToDouble(dgrvSalesItemList.Rows[n].Cells[7].Value);

                        if (disrate != 0)  // if discount has
                        {
                            double DisamtInc = (((Rprice * qty) * disrate) / 100.00);      // Total Discount amount of this item
                            dgrvSalesItemList.Rows[n].Cells[5].Value = DisamtInc;
                        }

                        if (Taxapply != 0)   // If apply  tax 
                        {
                            // Total Tax amount  of this item  (Rprice - disamount) * taxRate / 100
                            double TaxamtInc = ((((Rprice * qty) - (((Rprice * qty) * disrate) / 100.00)) * Taxrate) / 100.00);
                            dgrvSalesItemList.Rows[n].Cells[6].Value = TaxamtInc;
                        }
                        DiscountCalculation();
                        vatcal();
                    }

                }
                catch
                {
                }

            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
             
        #region Text box Validatation 
        //Validation Overall Discount Rate
        private void txtDiscountRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtDiscountRate.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            } 
        }

        //Validation Paid amount
        private void txtPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtPaidAmount.Text.ToString(), @"\.\d\d\d");

                if (e.KeyChar == '\b') // Always allow a Backspace
                    ignoreKeyPress = false;
                else if (matchString)
                    ignoreKeyPress = true;
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                    ignoreKeyPress = true;
                else if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
                    ignoreKeyPress = true;

                e.Handled = ignoreKeyPress;
                //using System.Text.RegularExpressions;
            }
            catch
            {
            }
        }
        #endregion

        #region //////////////////   Currency shortcuts value get
        public delegate void functioncall(string currencyvalue);
        public delegate void numvaluefunctioncall(string Numvalue);

        private event functioncall formFunctionPointer;
        private event numvaluefunctioncall numformFunctionPointer;

        private void Replicate(string currencyvalue)
        {
            if (currencyvalue == "XX") // All clear
            {
                txtPaidAmount.Text = "";
            }
            else if (currencyvalue == "BXC") //Backspace
            {
                if ((String.Compare(txtPaidAmount.Text, " ") < 0))
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1 + 1);
                }
                else
                {
                    txtPaidAmount.Text = txtPaidAmount.Text.Substring(0, txtPaidAmount.Text.Length - 1);
                }
                txtPaidAmount.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(txtPaidAmount.Text))
                {
                    txtPaidAmount.Text = "0.00";
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                else
                {
                    txtPaidAmount.Text = (Convert.ToDouble(txtPaidAmount.Text) + Convert.ToDouble(currencyvalue)).ToString();
                }
                txtPaidAmount.Focus();
            }
      
        }

        private void NumaricKeypad(string Numvalue)
        {
            txtPaidAmount.Text += Numvalue;
            txtPaidAmount.Focus();
        }
        #endregion
        
      
    }
}
