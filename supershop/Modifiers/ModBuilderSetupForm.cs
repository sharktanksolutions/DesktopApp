using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Modifiers
{
    public partial class ModBuilderSetupForm : Form
    {
        public ModBuilderSetupForm()
        {
            InitializeComponent();
        }

        private void roundButton3_Click(object sender, EventArgs e)
        {

        }

        private void roundButton2_Click(object sender, EventArgs e)
        {

        }

        private void roundButton5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

        private void updateModifierTabText_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string text;
            string buttonIndex = btn.Tag.ToString();
            string buttonName = "btnTab" + buttonIndex;
            int index = 0;
            using (var rbf = new EntryForms.RenameButtonForm())
            {
                rbf.ShowDialog();
                
                text = rbf.TypeName;
            }
            //this.Controls["btnTab1"].Text = "sam";
            

            btnTab1.Text = text;


        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void roundButton4_Click(object sender, EventArgs e)
        {
        }
    }
}
