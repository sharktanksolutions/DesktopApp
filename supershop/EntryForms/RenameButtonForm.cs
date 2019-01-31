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
    public partial class RenameButtonForm : Form
    {
        public RenameButtonForm()
        {
            InitializeComponent();
           
    }
        //public string typeName;

        public string TypeName { get => textBox1.Text; set => textBox1.Text = value; }

        public Form ModBuilderSetupForm;
   
    //private string TypeName 

    private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void RenameButtonForm_Load(object sender, EventArgs e)
        {
            //this.textBox1.Text = typeName; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //ModBuilderSetupForm.Show();


        }
    }
}
