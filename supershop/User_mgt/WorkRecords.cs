﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.User_mgt
{
    public partial class WorkRecords : Form
    {
        public WorkRecords()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region Data load
        public void Databind(string dtstart, string dtend)
        {
        //    string sql = " select  username , logdate as 'Date' ,  min( logtime) as 'IN' , max( logtime)  as 'OUT', " +
        //                    " CAST(((strftime('%s', max(logtime)  ) - strftime('%s',  min(logtime) )) % (60 * 60 * 24)) / (60 * 60) AS TEXT) || ':' || " +
        //                    " CAST((((strftime('%s', max(logtime)  ) - strftime('%s',  min(logtime) )) % (60 * 60 * 24)) % (60 * 60)) / 60 AS TEXT) as 'HOURS - HH:MM'  " +
        //                    " from tbl_workrecords where logdate BETWEEN '" + dtstart + "' AND    '" + dtend + "'  and " +
        //                    " username = '" + UserInfo.usernamWK + "'   group by username , logdate order by  logdate ";

            string sql = " SELECT * FROM vw_workrecords " +
                         " where Date BETWEEN '" + dtstart + "' AND    '" + dtend + "'  and " +
                         " username = '" + UserInfo.usernamWK + "'    order by  Date ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dtgrdWorkingHoursList.DataSource = dt1;
        }

       
        private void WorkRecords_Load(object sender, EventArgs e)
        {
            try
            {
               
                Databind(DateTime.Now.AddDays(-30).ToString(), DateTime.Now.ToString("yyyy-MM-dd"));              
            }
            catch
            {

            } 
        }

        private void dtEndDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Databind(dtStartDate.Text, dtEndDate.Text);                 
            }
            catch
            {

            }
        }

        private void btn30days_Click(object sender, EventArgs e)
        {
            try
            {
                Databind(DateTime.Now.AddDays(-30).ToString(), DateTime.Now.ToString("yyyy-MM-dd"));
            }
            catch { }
        }

        #endregion

        #region Export to CSV
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                //Exporting to xls.     
                saveFileDialog1.FileName = "WorkedHours_" + UserInfo.usernamWK + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";
                saveFileDialog1.ShowDialog(); 
            }
            catch
            {

            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
                //Build the CSV file data as a Comma separated string.
            string csv = string.Empty;

            //Add the Header row for CSV file.
            foreach (DataGridViewColumn column in dtgrdWorkingHoursList.Columns)
            {
                csv += column.HeaderText + ',';
            }

            //Add new line.
            csv += "\r\n";

            //Adding the Rows
            foreach (DataGridViewRow row in dtgrdWorkingHoursList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    //Add the Data rows.
                    csv += cell.Value.ToString().Replace(",", ";") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Exporting to CSV.
            //  string targetPath = "D:\\";
            string fileName = "SalesReport_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".csv";
            string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location: 
            // Create a new target folder, if necessary. 
            if (!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);

            }

            // Get file name.
            string name = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(name, csv);

        }
        #endregion
    }
}
