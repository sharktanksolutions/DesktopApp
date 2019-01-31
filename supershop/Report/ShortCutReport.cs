﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace supershop.Report
{
    public partial class ShortCutReport : Form
    {
        public ShortCutReport()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            string sql3 = "select * from tbl_terminalLocation where Shopid = '" + UserInfo.Shopid + "'";
            DataAccess.ExecuteSQL(sql3);
            DataTable dt1 = DataAccess.GetDataTable(sql3);

            DateTime dt = DateTime.Now;
            string printdate = dt.ToString("MMMM dd, yyyy    hh:mm:ss tt");
            string Companyname = dt1.Rows[0].ItemArray[1].ToString();
            string branchname = dt1.Rows[0].ItemArray[2].ToString();
            string Location = dt1.Rows[0].ItemArray[3].ToString();
            string phone = dt1.Rows[0].ItemArray[4].ToString();
            string email = dt1.Rows[0].ItemArray[5].ToString();
            string web = dt1.Rows[0].ItemArray[6].ToString();

            string Header = Companyname + "\n" + Location + "." + "\n" + email + "\n" + branchname + " ph: " + phone + "\n" + printdate + "\n";

            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;


            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            printDocument1.DocumentName = "Sales Report";
            printDocument1.PrinterSettings = MyPrintDialog.PrinterSettings;
            printDocument1.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);

            //if (MessageBox.Show("Do you want the report to be centered on the page",
            //    "InvoiceManager - Center on Page", MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question) == DialogResult.Yes)
                MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
                printDocument1, true, true, Header + " Sales Report \n", new Font("Baskerville Old Face", 13,
                FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

                // tosend = "<html><table>" + tosend + "</table></html>";
            //  mail.IsBodyHtml = true;
            //mail.Body = tosend;

            //else

            //    MyDataGridViewPrinter = new DataGridViewPrinter(datagrdReportDetails,
            //    printDocument1, false, true, Header + "   Sales Report   \n", new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Point), Color.Black, true);

            return true;
        }


        private void ShortCutReport_Load(object sender, EventArgs e)
        {
            dtStartDate.Format = DateTimePickerFormat.Custom;
            dtStartDate.CustomFormat = "yyyy-MM-dd";

            dtEndDate.Format = DateTimePickerFormat.Custom;
            dtEndDate.CustomFormat = "yyyy-MM-dd";

            datagrdReportDetails.EnableHeadersVisualStyles = false;
            datagrdReportDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            datagrdReportDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (lblENDdate.Text == "0")
            {
               

                dailyReport();

            }
            else
            {
                Last30daysReport(lblStartDate.Text,lblENDdate.Text);
            } 
        }

        public string ReportName
        {
            set
            {
                        lblReportName.Text = value;
            }
            get
            {
                return  lblReportName.Text;
            }
        }

        public string DTtoday  
        {  
                set     
                {    
                    lblStartDate.Text = value;    
                }
                get 
                { 
                     return lblStartDate.Text; 
                }
        }

        public string last30salesStartDate  
        {  
                set     
                {    
                    lblStartDate.Text = value;    
                }
                get 
                { 
                     return lblStartDate.Text; 
                }
        }

        public string last30salesENDDate
        {
            set
            {
                lblENDdate.Text = value;
            }
            get
            {
                return lblENDdate.Text;
            }
        }


        public void dailyReport()
        {
            if (lblStartDate.Text == "")
            {

                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {

                  //  string sql = "select   [sales_time] as [Date] , SUM(payment_amount) as [Total] , SUM(dis) as [Discount] , SUM(vat) as [VAT]  ,  SUM(due_amount)  as [Due]  from sales_payment where sales_time BETWEEN '" + lblShowValue.Text + "' AND    '" + lblShowValue.Text + "' GROUP BY  sales_time  Order  by sales_time"; //order by salesdate
                    string sql = "select  sales_id as 'Recipt No' , sales_time as Date , payment_amount as Total , emp_id as 'Sold by',  " + 
                        " dis as Discount , vat as TAX ,  payment_type as 'Payment Type' ,  due_amount as Due, Comment as Comments " + 
                        " from sales_payment where sales_time   like  '%" + lblStartDate.Text + "%' order by sales_time";     
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;

                    string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis) "+ 
                        " from sales_payment  where sales_time   >='" + lblStartDate.Text + "' AND  sales_time <='" + lblStartDate.Text + "' ";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);


                    DataRow dr = dt1.NewRow();
                    dr[1] = " ";
                    dt1.Rows.Add(dr);

                    DataRow dr2 = dt1.NewRow();
                    dr2[1] = "Sub Total";
                    dr2[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr2);


                    DataRow discount = dt1.NewRow();
                    discount[1] = "Total Discount";
                    discount[4] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                    dt1.Rows.Add(discount);



                    DataRow dr4 = dt1.NewRow();
                    dr4[1] = "Total TAX ";
                    dr4[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr4);

                    DataRow dr6 = dt1.NewRow();
                    dr6[1] = " ";
                    dt1.Rows.Add(dr6);

                    DataRow dr5 = dt1.NewRow();
                    dr5[1] = "Total Sales+TAX ";
                    dr5[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                    dt1.Rows.Add(dr5);

                    DataRow dr8 = dt1.NewRow();
                    dr8[1] = "Total Due ";
                    dr8[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    dt1.Rows.Add(dr8);

                    DataRow dr17 = dt1.NewRow();
                    dr17[1] = " ";
                    dt1.Rows.Add(dr17);

                    //DataRow dr9 = dt1.NewRow();
                    //dr9[1] = "Total in Cash ";
                    //dr9[2] = (Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString())) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    //dt1.Rows.Add(dr9);

                    DataRow dr7 = dt1.NewRow();
                    dr7[1] = " ";
                    dt1.Rows.Add(dr7);


                    DataRow rep = dt1.NewRow();
                    rep[1] = "Payment Report ";
                    // rep[3] = dateTimePicker1.Text;                  
                    dt1.Rows.Add(rep);

                    DataRow repdt = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt[1] = "From : " + lblStartDate.Text;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt);

                    DataRow repdt2 = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt2[1] = "To : " + lblStartDate.Text;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt2);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        public void Last30daysReport(string startDate,string endDate)
        {
            if (lblStartDate.Text == "")
            {
                // MessageBox.Show("Please Select Date ");
            }
            else
            {
                try
                {
                    //string sql = "select   sales_time as Date , SUM(payment_amount) as 'Total' , SUM(dis) as 'Discount' , SUM(vat) as 'VAT'  ,  SUM(due_amount)  as 'Due'" + 
                    //            "  from sales_payment where sales_time BETWEEN '" + startDate + "' AND    '" + endDate + "'    Order  by sales_time"; //order by salesdate
                    //DataAccess.ExecuteSQL(sql);
                    //DataTable dt1 = DataAccess.GetDataTable(sql);
                    //datagrdReportDetails.DataSource = dt1;

                    //string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis)  " +
                    //    " from sales_payment  where sales_time   >='" + startDate + "' AND  sales_time <='" + endDate + "' ";
                    //DataAccess.ExecuteSQL(sql3);
                    //DataTable dt3 = DataAccess.GetDataTable(sql3);

                    string sql = "select  sales_id as 'Recipt No' , sales_time as Date , payment_amount as Total , emp_id as 'Sold by', " + 
                        " dis as Discount , vat as TAX ,  payment_type as 'Payment Type' ,  due_amount as Due, Comment as Comments " +
                        "  from sales_payment where sales_time BETWEEN '" + startDate + "' AND    '" + endDate + "'    Order  by sales_time";
                    DataAccess.ExecuteSQL(sql);
                    DataTable dt1 = DataAccess.GetDataTable(sql);
                    datagrdReportDetails.DataSource = dt1;

                    string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis)  "+
                                "  from sales_payment where sales_time BETWEEN '" + startDate + "' AND    '" + endDate + "'    Order  by sales_time";
                    DataAccess.ExecuteSQL(sql3);
                    DataTable dt3 = DataAccess.GetDataTable(sql3);

                    DataRow dr = dt1.NewRow();
                    dr[1] = " ";
                    dt1.Rows.Add(dr);

                    DataRow dr2 = dt1.NewRow();
                    dr2[1] = "Sub Total";
                    dr2[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr2);


                    DataRow discount = dt1.NewRow();
                    discount[1] = "Total Discount";
                    discount[4] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                    dt1.Rows.Add(discount);



                    DataRow dr4 = dt1.NewRow();
                    dr4[1] = "Total TAX ";
                    dr4[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                    dt1.Rows.Add(dr4);

                    DataRow dr6 = dt1.NewRow();
                    dr6[1] = " ";
                    dt1.Rows.Add(dr6);

                    DataRow dr5 = dt1.NewRow();
                    dr5[1] = "Total Sales+ TAX ";
                    dr5[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                    dt1.Rows.Add(dr5);

                    DataRow dr8 = dt1.NewRow();
                    dr8[1] = "Total Due ";
                    dr8[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    dt1.Rows.Add(dr8);

                    DataRow dr17 = dt1.NewRow();
                    dr17[1] = " ";
                    dt1.Rows.Add(dr17);

                    //DataRow dr9 = dt1.NewRow();
                    //dr9[1] = "Total in Cash ";
                    //dr9[2] = (Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString())) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                    //dt1.Rows.Add(dr9);

                    DataRow dr7 = dt1.NewRow();
                    dr7[1] = " ";
                    dt1.Rows.Add(dr7);


                    DataRow rep = dt1.NewRow();
                    rep[1] = "Payment Report ";
                    // rep[3] = dateTimePicker1.Text;                  
                    dt1.Rows.Add(rep);

                    DataRow repdt = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt[0] = "From : " + startDate;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt);

                    DataRow repdt2 = dt1.NewRow();
                    // rep[3] = "Daily Report For ";
                    repdt2[0] = "To : " + endDate;
                    //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                    dt1.Rows.Add(repdt2);
                }
                catch
                {
                    // MessageBox.Show("There is no Data in this date");
                }
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.datagrdReportDetails.RowsDefaultCellStyle.BackColor = Color.White;
                this.datagrdReportDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

                if (SetupThePrinting())
                {
                    PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();                  
                    MyPrintPreviewDialog.WindowState = FormWindowState.Maximized;
                    MyPrintPreviewDialog.PrintPreviewControl.Zoom = 1.0;              
                    MyPrintPreviewDialog.Document = printDocument1;
                    MyPrintPreviewDialog.ShowDialog(); 

                    //PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                    //MyPrintPreviewDialog.Document = printDocument1;
                    //MyPrintPreviewDialog.ShowDialog();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("!!! Please Print Preview or Setup Print only for First time " + exp.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        // Variable pass for Salesdetails 
        private void datagrdReportDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (lblENDdate.Text == "0")
                {
                    DataGridViewRow row = datagrdReportDetails.Rows[e.RowIndex];
                    string id = row.Cells[0].Value.ToString();
                    double Payamt = Convert.ToDouble(row.Cells[2].Value.ToString());
                    double vat = Convert.ToDouble(row.Cells[5].Value.ToString());
                    double subtotal = Convert.ToDouble(row.Cells[2].Value.ToString()) - Convert.ToDouble(vat);
                    double dis = Convert.ToDouble(row.Cells[4].Value.ToString());

                    if (row.Cells[6].Value.ToString() == "Invoice")
                    {
                        // Inventory.InvoicePrint go = new Inventory.InvoicePrint(id);
                        View_Sales_invoice go = new View_Sales_invoice(id);
                        go.ShowDialog();
                    }
                    else
                    {
                        SalesDetails go = new SalesDetails(id, dis, subtotal, vat, Payamt);
                        go.ShowDialog();                    
                    }                    
                }
             
            }
            catch // (Exception exp)
            {
                // MessageBox.Show("Sorry" + exp.Message);
            }
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            Last30daysReport(dtStartDate.Text, dtEndDate.Text);
        }

        private void txtInvoice_TextChanged(object sender, EventArgs e)
        {
            try
            {

                //  string sql = "select   [sales_time] as [Date] , SUM(payment_amount) as [Total] , SUM(dis) as [Discount] , SUM(vat) as [VAT]  ,  SUM(due_amount)  as [Due]  from sales_payment where sales_time BETWEEN '" + lblShowValue.Text + "' AND    '" + lblShowValue.Text + "' GROUP BY  sales_time  Order  by sales_time"; //order by salesdate
                string sql = "select  sales_id as 'Recipt No' , sales_time as Date , payment_amount as Total , emp_id as 'Sold by',  " +
                    " dis as Discount , vat as TAX ,  payment_type as 'Payment Type' ,  due_amount as Due, Comment as Comments " +
                    " from sales_payment where   sales_id  = '" + txtInvoice.Text + "' order by sales_time";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                datagrdReportDetails.DataSource = dt1;

                string sql3 = "select SUM(payment_amount), SUM(vat) , SUM(due_amount), SUM(dis) " +
                    " from sales_payment  where sales_id  = '" + txtInvoice.Text + "'  ";
                DataAccess.ExecuteSQL(sql3);
                DataTable dt3 = DataAccess.GetDataTable(sql3);


                DataRow dr = dt1.NewRow();
                dr[1] = " ";
                dt1.Rows.Add(dr);

                DataRow dr2 = dt1.NewRow();
                dr2[1] = "Sub Total";
                dr2[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                dt1.Rows.Add(dr2);


                DataRow discount = dt1.NewRow();
                discount[1] = "Total Discount";
                discount[4] = Convert.ToDouble(dt3.Rows[0].ItemArray[3].ToString());
                dt1.Rows.Add(discount);



                DataRow dr4 = dt1.NewRow();
                dr4[1] = "Total TAX ";
                dr4[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[1].ToString());
                dt1.Rows.Add(dr4);

                DataRow dr6 = dt1.NewRow();
                dr6[1] = " ";
                dt1.Rows.Add(dr6);

                DataRow dr5 = dt1.NewRow();
                dr5[1] = "Total Sales+TAX ";
                dr5[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString());
                dt1.Rows.Add(dr5);

                DataRow dr8 = dt1.NewRow();
                dr8[1] = "Total Due ";
                dr8[5] = Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                dt1.Rows.Add(dr8);

                DataRow dr17 = dt1.NewRow();
                dr17[1] = " ";
                dt1.Rows.Add(dr17);

                //DataRow dr9 = dt1.NewRow();
                //dr9[1] = "Total in Cash ";
                //dr9[2] = Convert.ToDouble(dt3.Rows[0].ItemArray[0].ToString()) - Convert.ToDouble(dt3.Rows[0].ItemArray[2].ToString());
                //dt1.Rows.Add(dr9);

                DataRow dr7 = dt1.NewRow();
                dr7[1] = " ";
                dt1.Rows.Add(dr7);


                DataRow rep = dt1.NewRow();
                rep[1] = "Payment Report ";
                // rep[3] = dateTimePicker1.Text;                  
                dt1.Rows.Add(rep);

                DataRow repdt = dt1.NewRow();
                // rep[3] = "Daily Report For ";
                repdt[1] = "From : " + lblStartDate.Text;
                //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                dt1.Rows.Add(repdt);

                DataRow repdt2 = dt1.NewRow();
                // rep[3] = "Daily Report For ";
                repdt2[1] = "To : " + lblStartDate.Text;
                //rep[4] = dt3.Rows[0].ItemArray[5].ToString();
                dt1.Rows.Add(repdt2);
            }
            catch
            {
                // MessageBox.Show("There is no Data in this date");
            }
        }

        private void helplnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            parameter.helpid = "INV";
            HelpPage go = new HelpPage();
            go.MdiParent = this.ParentForm;
            go.Show();
        }

        private void datagrdReportDetails_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            try
            {
                e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch
            {

            }
        }

    }
}
