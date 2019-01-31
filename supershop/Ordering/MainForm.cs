using MySql.Data.MySqlClient;
using supershop.Ordering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            // check if the user has logged in or not

            // ToDo: check if the user has access to place an order

            // create new orderId 
            
            // set order type as TAKE OUT 

            //make sure no other forms are up

            // go to ordering form 
            //type 1 takeOut
            startOrder("Take Out");


        }
        private void startOrder(string type)
        {

           
            OrderHeaders orderHeader = new OrderHeaders();
            
            orderHeader.OrderType = type;

           
            //MessageBox.Show("type-->>" +type);
            OrderingForm ordFrm = new OrderingForm();
            //ordFrm.MdiParent = this.ParentForm;
            ordFrm.OrderType = type;
            ordFrm.ShowDialog();
           
            //btnOrderType.Name = "buttonOrderType";

            /*

            ordFrm.ShowDialog();
            string sql = "INSERT INTO order_headers " +
                "(order_date," +
                "employee_id," +
                "station_id," +
                "order_type)" +
                "Values " +
                "('2019-02-03'," +
                "2," +
                "03," +
                "1)";

            //DataTable dt = DataAccess.GetDataTable(sql);


            MySqlConnection sqlconn = new MySqlConnection(DataAccess._ConnectionString);

            MySqlCommand sqlCmd = new MySqlCommand(sql, sqlconn);
            sqlconn.Open();
            sqlCmd.CommandText = sql;
            sqlCmd.ExecuteNonQuery();
            int orderId = (Int32)sqlCmd.LastInsertedId;


            //string sql2 = "SELECT LAST_INSERT_ID()";
            //            int orderId =  DataAccess.ExecuteSQL(sql);


            //dt = DataAccess.GetDataTable(sql2);
            //string orderId = dt.Rows[0][0].ToString();
            MessageBox.Show("orderid-->"+orderId);
            Console.WriteLine("orderid----->"+orderId);

             */

        }

        private void btnPickUp_Click(object sender, EventArgs e)
        {
            //check if user is logged in or not

            // pull phone from caller id,


            //or ask for phone number

            EntryForms.PhoneEntry pe = new EntryForms.PhoneEntry();
            pe.ShowDialog();


            //set order type as pickup

            //go to ordering screen 

            // display phone number on order panel

            
        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            // check if user is logged in 

            // open phone number form 
            EntryForms.PhoneEntry pe = new EntryForms.PhoneEntry();
            pe.ShowDialog();

            // pull phone number from caller id or ask for it, then fill in info

            //set order type as delivery
            //go to ordering screen

            // display customer info on ordering panel

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalesRegister sr = new SalesRegister();


            Console.WriteLine();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
