﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace supershop.Expenses
{
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();             
            txtReferNo.CharacterCasing = CharacterCasing.Upper;
        }
     

        private void lnkExpenses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Expenses.ExpensesList go = new Expenses.ExpensesList();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        public void Expensebind()
        {
            string sql = " select  ID, Date , ReferenceNo as 'Refer No' , Category ,	Amount , Note ,	Createdby as 'Posted by', Attachment , fileextension from tbl_expense " +
                            " where ID = '" + lblfileID.Text + "' ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
           // dtStartDate.Value           = Convert.ToDateTime(dt1.Rows[0].ItemArray[1].ToString());
            txtReferNo.Text             = dt1.Rows[0].ItemArray[2].ToString();
            txtAmount.Text              = dt1.Rows[0].ItemArray[4].ToString();
            txtAttachmentFileName.Text  = dt1.Rows[0].ItemArray[7].ToString();
            txtNote.Text                = dt1.Rows[0].ItemArray[5].ToString();
            cmboCategory.Text           = dt1.Rows[0].ItemArray[3].ToString();
            lblFileExtension.Text       = dt1.Rows[0].ItemArray[8].ToString();
            lblcopyfile.Text            = dt1.Rows[0].ItemArray[7].ToString();

        }

        private void AddExpense_Load(object sender, EventArgs e)
        {
            try
            {
                dtStartDate.Format = DateTimePickerFormat.Custom;
                dtStartDate.CustomFormat = "yyyy-MM-dd";
                txtAmount.Focus();               
                Expensebind();
                 
            }
            catch
            {
            }
 
          
        }

        private void btnaddexpense_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("Please Insert Expense Amount");
                    txtAmount.Focus();
                }
                else if (cmboCategory.Text == string.Empty)
                {
                    MessageBox.Show("Please Select category");
                    cmboCategory.Focus();
                }
                else
                {
                    string Filename;
                    if (txtAttachmentFileName.Text != string.Empty)
                    {
                        Filename = DateTime.Now.ToString("yyyyMMddhhmmss") + lblFileExtension.Text;
                    }
                    else
                    {
                        Filename = "";
                    }                   
                    string sql1 = " insert into tbl_expense (Date , ReferenceNo , Category ,	Amount ,	Attachment , fileextension, Note ,	Createdby) " +
                                " values ('" + dtStartDate.Text + "', '" + txtReferNo.Text + "','" + cmboCategory.Text + "', '" + txtAmount.Text + "',  " +
                                " '" + Filename + "', '" + lblFileExtension.Text + "', '" + txtNote.Text + "' , '" + UserInfo.UserName + "')";
                    DataAccess.ExecuteSQL(sql1);

                    if (txtAttachmentFileName.Text != string.Empty)
                    {
                        //Attachment upload  /////////////////
                        string path = Application.StartupPath + @"\ExpenseAttachment\";
                        if (!System.IO.Directory.Exists(path))
                            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\ExpenseAttachment\");
                        string copyfile = lblcopyfile.Text; //Source file
                        string pastefile = path + @"\" + Filename;  //destination file
                        System.IO.File.Copy(copyfile, pastefile);                      
                    }

                    MessageBox.Show("Saved Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult result = MessageBox.Show("Do you want to add a new Expense?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        txtAmount.Text = string.Empty;
                        txtNote.Text = string.Empty;
                        txtReferNo.Text = string.Empty;
                    }
                    else
                    {
                        this.Hide();
                        Expenses.ExpensesList go = new Expenses.ExpensesList();
                        go.MdiParent = this.ParentForm;
                        go.Show();
                    }      
  
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
 
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = ".pdf";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf|jpg files (*.jpg)|*.jpg|PNG files (*.png)|*.png";

            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;
                txtAttachmentFileName.Text = openFileDialog1.SafeFileName;
                lblcopyfile.Text = openFileDialog1.FileName;
                lblFileExtension.Text = Path.GetExtension(openFileDialog1.FileName);
                FileInfo fi1 = new FileInfo(openFileDialog1.FileName);
                lblfileinfo.Text = "File Name: " + fi1.Name + "\n" + fi1.Length.ToString() + " Bytes \nFile type:" + fi1.Extension + "";
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                bool ignoreKeyPress = false;

                bool matchString = Regex.IsMatch(txtAmount.Text.ToString(), @"\.\d\d\d");

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
    }
}
