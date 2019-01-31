using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Customer
{
    public partial class AddNewCustomer : Form
    {
        public AddNewCustomer()
        {
            InitializeComponent();
        }

        public string CustID
        {
            set
            {
                lblCustID.Text = value;
                lnkCustomers.Visible = false;
                grboxCusthistory.Visible = true;
                lblcuthistorylabel.Visible = true;
                lbltoplabel.Visible = true;

            }
            get
            {
                return lblCustID.Text;

            }
        }

        public string CustName
        {
            set
            {
                txtCustomerName.Text = value;
                btnSave.Text = "Update";
            }
            get
            {
                return txtCustomerName.Text;
            }
        }

        public string CustPhone
        {
            set
            {
                txtPhone.Text = value;
                
            }
            get
            {
                return txtPhone.Text;
                
            }
        }

        public string City
        {
            set
            {
                txtCity.Text = value;
            }
            get
            {
                return txtCity.Text;
            }
        }


        public string Email
        {
            set
            {
                txtEmailAddress.Text = value;
            }
            get
            {
                return txtEmailAddress.Text;
            }
        }

        public string CustAddress
        {
            set
            {
                txtCustomerAddress.Text = value;                
            }
            get
            {
                return txtCustomerAddress.Text;
            }
        }

        public string PeopleType
        {
            set
            {
                
                CombPeopleType.Text = value;
            }
            get
            {
                return CombPeopleType.Text;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void clearform()
        {
            CombPeopleType.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtCustomerAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblCustID.Text == "-")
                {
                   // if (txtPeopleID.Text == "") { MessageBox.Show("Please Fill ID"); txtPeopleID.Focus(); } else
                    if (txtCustomerName.Text == "") { MessageBox.Show("Please Fill Name"); txtCustomerName.Focus(); }
                    else if (txtPhone.Text == "") { MessageBox.Show("Please Fill Phone"); txtPhone.Focus(); }
                    else if (CombPeopleType.Text == "") { MessageBox.Show("Please Fill People Type"); CombPeopleType.Focus(); }
                    else if (txtCity.Text == "") { MessageBox.Show("Please Fill City"); txtCity.Focus(); }
                    else if (txtCustomerAddress.Text == "") { MessageBox.Show("Please Fill  Address"); txtCustomerAddress.Focus(); }
                    else
                    {                        
                            string sqlCmd = "insert into tbl_customer (Name, EmailAddress, Phone, address, City, PeopleType )  values ('" + txtCustomerName.Text + "', '" + txtEmailAddress.Text + "', '" + txtPhone.Text + "', '" + txtCustomerAddress.Text + "', '" + txtCity.Text + "', '" + CombPeopleType.Text + "')";
                            DataAccess.ExecuteSQL(sqlCmd);
                            MessageBox.Show("Successfully saved");
                            lblMsg.Text = "Successfully saved";
                            clearform();       
                       
                    }
                }
                else  //Update 
                {
                    string sqlUpdateCmd = "update tbl_customer set Name = '" + txtCustomerName.Text + "', EmailAddress= '" + txtEmailAddress.Text + "', address = '" + txtCustomerAddress.Text + "', Phone = '" + txtPhone.Text + "', City = '" + txtCity.Text + "' , PeopleType = '" + CombPeopleType.Text + "'   where ID = '" + lblCustID.Text + "'";
                    DataAccess.ExecuteSQL(sqlUpdateCmd);
                    MessageBox.Show("Successfully Updated");
                }
              
              
            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n this id already added \n\n " + exp.Message);
            }
                  
        }

        private void AddNewCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Customer.CustomerDetails go = new Customer.CustomerDetails();
            //go.MdiParent = this.ParentForm;
            //go.Show();
        }

        private void AddNewCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                        string sql = "  select  sales_id as 'Invo_No' , sales_time as Date , payment_amount as Total , " +
                                    "   (payment_amount - due_amount) as 'Paid Amount' ,  payment_type as 'Payment Type' , " +
                                    "   due_amount as Due, emp_id as 'Sold by' ,    C_id  as Contact , Comment as 'Cust Name/Comment' " +
                                    "   from sales_payment   where C_id = '" + lblCustID.Text + "' order by  sales_id desc";
                        DataAccess.ExecuteSQL(sql);
                        DataTable dt1 = DataAccess.GetDataTable(sql);
                        dtgviewCusttrxHistory.DataSource = dt1;
            }
            catch
            {
            }

        }

        private void lnkCustomers_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Customer.CustomerDetails go = new Customer.CustomerDetails();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void dtgviewCusttrxHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                DataGridViewRow row = dtgviewCusttrxHistory.Rows[e.RowIndex];               
               
                //this.Hide();
                Customer.Due_payment_History go = new Customer.Due_payment_History(row.Cells["Contact"].Value.ToString(), row.Cells["Invo_No"].Value.ToString());
                go.MdiParent = this.ParentForm;
                go.ShowDialog();

            }
            catch
            {

            }
        }
    }
}
