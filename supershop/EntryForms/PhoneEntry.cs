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
            

           // textBox1.Focus();
        }
        private int _cursorPosition;
        private TextBox currentFocusedTextBox;
        private int CursorPosition { get { return _cursorPosition; } set { _cursorPosition = value; } }

        private string _phoneNumber;
        public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

       

        
        /*
        private void myform_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    */
        private void PhoneEntry_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            currentFocusedTextBox = textBox1;
            textBox1.MaxLength = 3;
            textBox2.MaxLength = 3;
            textBox3.MaxLength = 4;
            enterButton.Enabled = false;
            backSpace.Enabled = false;
            

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
           
        }

       


        private void backSpace_MouseUp(object sender, MouseEventArgs e)
        {
            //textBox1.Focus();
           // SendKeys.Send("{BACKSPACE}");

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyCode == Keys.Back) {
                textBox1.Focus();
            }
        }
       

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            if (textBox1.Text.Length == 3)
            {

                textBox2.Focus();
                currentFocusedTextBox = textBox2;

            }

            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0 && textBox3.Text.Length == 0)
            {

                enterButton.Enabled = false;
                backSpace.Enabled = false;

            }


            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0)
            {

                //enterButton.Enabled = false;
                backSpace.Enabled = true;

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 3)
            {

                textBox3.Focus();
                currentFocusedTextBox = textBox3;

            }
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0)
            {

                //enterButton.Enabled = false;
                backSpace.Enabled = true;

            }
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0 && textBox3.Text.Length == 0)
            {

                enterButton.Enabled = false;
                backSpace.Enabled = false;

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0 && textBox3.Text.Length == 0)
            {

                enterButton.Enabled = false;
                backSpace.Enabled = false;

            }

            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0)
            {

                backSpace.Enabled = true;

            }

            if (textBox3.Text.Length == 4 && textBox2.Text.Length == 3 && textBox1.Text.Length == 3)
            {
                enterButton.Enabled = true;
                backSpace.Enabled = true;

            }
        }
       
        
        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

    
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back && textBox1.Text.Length <3) {
                textBox1.Focus();
                currentFocusedTextBox = textBox1;

            }

            if (e.KeyCode == Keys.Tab ) //|| e.KeyCode == Keys.Right)
            {
                textBox2.Focus();
                currentFocusedTextBox = textBox2;

            }
            /*
            if ( e.KeyCode == Keys.Left)
            {
                textBox1.Focus();
                currentFocusedTextBox = textBox1;

            }
            */

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text.Length == 0 && e.KeyCode == Keys.Back)
            {

                Console.WriteLine("backspace");
                textBox1.Focus();
                currentFocusedTextBox = textBox1;
                //textBox1.KeyUp += "";

            }
            if (e.KeyCode == Keys.Tab)// || e.KeyCode == Keys.Right)
            {
                textBox3.Focus();
                currentFocusedTextBox = textBox3;

            }
            /*
            if (e.KeyCode == Keys.Left)
            {
                textBox1.Focus();
                currentFocusedTextBox = textBox1;

            }
            */
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {


            if (textBox3.Text.Length == 0 && e.KeyCode == Keys.Back)// || e.KeyCode == Keys.Left)
            {
                textBox2.Focus();
                currentFocusedTextBox = textBox2;
            }


            if (textBox3.Text.Length == 4 && textBox2.Text.Length ==3  && textBox1.Text.Length ==3 && e.KeyCode == Keys.Enter)
            {

                Console.WriteLine("clicked enter");
                capturePhoneNumber();



            }
            if (e.KeyCode == Keys.Tab) // || e.KeyCode == Keys.Right)
            {
                textBox3.Focus();
                currentFocusedTextBox = textBox3;

            }
            

        }


        private void textInput_TextChanged(object sender, EventArgs e) {

            

            // if all fields are empty, disable back space and enter 
            if (textBox1.Text.Length == 0 && textBox2.Text.Length == 0 && textBox3.Text.Length == 0)
            {
                //TODO: disable enter key 
                enterButton.Enabled = false;
                backSpace.Enabled = false;

            }
            // if any field has any input, enable backspace
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0)
            {

                backSpace.Enabled = true;

            }

           
            if (textBox3.Text.Length < 4 || textBox2.Text.Length < 3 || textBox1.Text.Length < 3)
            {
               
                enterButton.Enabled = false;
                

            }


            if (textBox1.Text.Length == 3 && textBox2.Text.Length <3) {
                textBox2.Focus();
                currentFocusedTextBox = textBox2;
            }
            if (textBox2.Text.Length == 3 && textBox1.Text.Length ==3)
            {
                textBox3.Focus();
                currentFocusedTextBox = textBox3;
            }
            // if all fields have proper input , enable enter, backspace and continue button
            if (textBox3.Text.Length == 4 && textBox2.Text.Length == 3 && textBox1.Text.Length == 3)
            {
                //TODO: allow enter key 

                enterButton.Enabled = true;
                backSpace.Enabled = true;
                currentFocusedTextBox = textBox3;
                


            }

            //TextBox txBx = sender as TextBox;
           // currentFocusedTextBox = txBx;
            //Console.WriteLine("We are in"+this.Name+"e is== "+ txBx.Name.ToString());

        }


        private void textInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
                                    
        }

        private void backSpace_Click(object sender, EventArgs e)
        {
            
            currentFocusedTextBox.Focus();

            SendKeys.Send("{BACKSPACE}");
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("This is a mouse click");
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("what about this?");
        }

        private void textInput_Click(object sender, EventArgs e) {
            TextBox txBx = sender as TextBox;
            currentFocusedTextBox = txBx;
            Console.WriteLine("We clicked on " + this.Name + "e is== " + txBx.Name.ToString());

        }

        private void capturePhoneNumber() {

            _phoneNumber = textBox1.Text + textBox2.Text + textBox3.Text;
            Console.WriteLine("phone#---> "+_phoneNumber);
            //todo: save to database

        }

        private void buttonInput(object sender, EventArgs e) {

            Button b = (Button)sender;
            currentFocusedTextBox.Text += b.Text;

        }


        private void goToDeliveryForm() {
            //if order type is delivery


        }

        private void goToOrderForm() {
            //if ordertype is pickup 

        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            capturePhoneNumber();

            this.Hide();

            var  of = new Ordering.OrderingForm();
            of.Closed += (s, args) => this.Close();
            of.ShowDialog();

            
            
        }
    }
}
