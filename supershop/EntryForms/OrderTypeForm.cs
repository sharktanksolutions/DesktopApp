using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.EntryForms
{
    public partial class OrderTypeForm : Form
    {
        public OrderTypeForm()
        {
            InitializeComponent();
            this.MdiParent = this.ParentForm;
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            // console
            //this.ParentForm.Order
            // change parent form order type then close this form 

            this.Close();
        }

        private void roundButton2_Click(object sender, EventArgs e)
        {
            //this.ParentForm.Order
            //open phone number dialog

            // change parent form order type then close this form 

            this.Close();
            
           
            
            //MdiParent.Controls["btnOrderType"].Text = "Changed";

            
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {
            //this.ParentForm.Order
            //open phone number dialog, then address input 
            // change parent form order type then close this form
            

            this.Close();
        }
    }
}
