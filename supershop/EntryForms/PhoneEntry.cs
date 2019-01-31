using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.EntryForms
{
    public partial class PhoneEntry : Form
    {
        public PhoneEntry()
        {
            InitializeComponent();
            DoubleBuffered = true;
            

            //textBox1.Focus();
        }
        private int _cursorPosition;


        private int CursorPosition { get { return _cursorPosition; } set { _cursorPosition = value; } }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void myform_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void PhoneEntry_Load(object sender, EventArgs e)
        {
            
            textBox1.MaxLength = 12;

        }

        private void roundButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

           // string phoneNumber = textBox1.Text.ToString();//.Trim("l");


        }

        public void roundButton13_Click(object sender, EventArgs e)
        {
            // if there is nothing in the text box, disable backspace and disable delete button

            _cursorPosition = textBox1.SelectionStart;
            // Console.WriteLine("position" + cursorPosition.ToString());

            if (textBox1.Text.Substring(_cursorPosition - 1) == "-")
            {
                //textBox1.Text = textBox1.Text.Substring(cursorPosition, textBox1.Text.Length - 2);
                textBox1.Focus();
                SendKeys.Send("{BACKSPACE}");
                SendKeys.Send("{BACKSPACE}");

            }
            else {
                //textBox1.Text = textBox1.Text.Substring(cursorPosition, textBox1.Text.Length - 1);
                textBox1.Focus();
                SendKeys.Send("{BACKSPACE}");
            }
            
            //textBox1.Text.Length = textBox1.Text.Length - 1; 

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                backSpace.Enabled = true;
            }
            else {
                backSpace.Enabled = false ;
            }
            // else backSpace.Enabled = false;

            if (textBox1.Text.Length == 3 && textBox1.Text.Substring(textBox1.Text.Length-1,1) != "-" )  {
                textBox1.Text += "-";
                textBox1.SelectionStart = textBox1.Text.Length;
            }
            if (textBox1.Text.Length == 7 && textBox1.Text.Substring(textBox1.Text.Length - 1, 1) != "-")
            {
                textBox1.Text += "-";
                textBox1.SelectionStart = textBox1.Text.Length;
            }

           

        }

        private void roundButton7_Click(object sender, EventArgs e)
        {
            // test
            //int cursorPosition = textBox1.SelectionStart;
            //Console.WriteLine("position" + cursorPosition.ToString());
        }

        private void backSpace_MouseUp(object sender, MouseEventArgs e)
        {
            //textBox1.Focus();
           // SendKeys.Send("{BACKSPACE}");

        }
    }
}
