using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.Ordering
{
    public partial class MenuGroupEditor : Form
    {
        private string _groupId;
        private string _groupDescription;
        private string _groupPictureLocation;
        private string _showCaption = "1";
        private string _groupIndexLocation;  // from the database
        private string _btnPosition;
        private int _hiddenButton = 0;
        private string _buttonColor;
        //private string _groupButtonLocation; // current position on the screen ( i ) in the loop
        
        public string GroupID { get { return _groupId; } set { _groupId= value; } }
        public string GroupDescription { get { return _groupDescription; } set { _groupDescription = value; } }
        public string GroupPictureLocation { get { return _groupPictureLocation; } set { _groupPictureLocation = value; } }
        public string ShowCaption { get { return _showCaption; } set { _showCaption = value;  } }
        public string GroupIndexLocation {  get { return _groupIndexLocation; } set { _groupIndexLocation = value; } }
        public string ButtonPosition { get { return _btnPosition;  } set { _btnPosition = value;  } }
        public int HideButton { get { return _hiddenButton; } set { _hiddenButton = value; } }
        public string ButtonColor { get { return _buttonColor; } set { _buttonColor = value; } }

        // public string GroupButtonLocation { get { return _groupButtonLocation; } set { _groupButtonLocation = value;  } }

        public MenuGroupEditor()
        {
            InitializeComponent();
        }

        private void MenuGroupEditor_Load(object sender, EventArgs e)
        {
            // when form loads , get the information from prevoius form and from database

            //todo : if it is hidden, make the space available for other buttons ( differnet than show description ) 


            try {

                this.menuGroupIdBox.Text = _groupId.ToString();
                this.menuGroupDescriptionTextBox.Text = _groupDescription.ToString();
                this.menuGroupPictureLocation.Text = _groupPictureLocation.ToString();
                this.buttonPositionTextBox.Text = _btnPosition.ToString();
                this.txBoxColor.Text = _buttonColor.ToString();
                if (String.IsNullOrEmpty(this.txBoxColor.Text = _buttonColor.ToString() )){

                    this.txBoxColor.Text = "it is empty";
                }

                //this.checkBox1.Checked = _showCaption; //==  true : false;
                //this._showCaption = (this.checkBox1.Checked) ? 1 : 0;
                if (this.ShowCaption == "1")
                {

                    this.checkBox1.Checked = true;
                }
                else {
                    this.checkBox1.Checked = false;
                }
                if (this.HideButton == 1)
                {
                    this.checkBox2.Checked = true;
                }
                else {
                    this.checkBox2.Checked = false;
                }

                 //_hiddenButton = (this.checkBox2.Checked) ? 1 : 0;
                //MessageBox.Show("Should it be checked?--->" + this.checkBox1.Checked);


            } catch (Exception e1 ) {

                MessageBox.Show(" Error ---> 79" + e1);

            }
            
           // MessageBox.Show("loading now .." + _btnPosition.ToString());
           //label2.Text = _btnPosition;


            // this.GroupButtonLocation = _groupButtonLocation.ToString();
            //MessageBox.Show(_groupId);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void bntSave_Click(object sender, EventArgs e)
        {

            //string _groupID = this.menuGroupIdBox.Text.ToString();
            string _displayIndex = this.buttonPositionTextBox.Text.ToString();
            string _description = this.menuGroupDescriptionTextBox.Text.ToString();
            string _pictureLocation = this.menuGroupPictureLocation.Text.ToString();
            string _color = this.txBoxColor.Text.ToString();
            int _showCaption = (this.checkBox1.Checked) ? 1:0;
            int _hidden = (this.checkBox2.Checked) ? 1 : 0; 
            //int _hidden = 0;

            // string _color = this.menuGroupDescriptionTextBox.   implement color picker


            // string _color = this._color; //"not implemented";

            // string _pictureLocation = this.menuGroupPictureLocation;

            MessageBox.Show(
                "_displayIndex-->"+ _displayIndex+
                "_desc-->"+ _description+
                "pictureLocation---->"+_pictureLocation+
                "_color-->" +_color+
                "hidden-->"+_hidden+
                "show caption-->"+_showCaption
                );

            // get the values from this class 
            //this.menuGroupIdBox.Text = _groupID;                       
            try
            {
                // bad case nothing to save or update
                if (this.menuGroupIdBox.Text.ToString() == "" && string.IsNullOrEmpty(this.menuGroupDescriptionTextBox.Text.ToString()))
                {
                    MessageBox.Show("Add description ");
                    menuGroupDescriptionTextBox.Focus();
                }

                // new Insert or update
                if (!string.IsNullOrEmpty(this.menuGroupDescriptionTextBox.Text.ToString())) {
                    MessageBox.Show("Now,   add/update");
                    //menuGroupDescriptionTextBox.Focus();
                    string sqlCommand =
                        "insert into menugroup" +
                        " (ID, DisplayIndex,Description,Color,PictureLocation, ShowCaption, Hidden)" +
                        "values (' " + _groupId + "', '"
                                     + _displayIndex  +"', '" 
                                     + _description +"', '" 
                                     + _color + "', '" 
                                     + _pictureLocation + "', '"
                                     + _showCaption + "', '"
                                     + _hidden + 

                        "')" +
                        "ON DUPLICATE KEY UPDATE " +
                        "ID = Values(ID) ," +
                        "DisplayIndex = VALUES(DisplayIndex)," +
                        "Description = VALUES(Description)," +
                        "Color= VALUES(Color)," +
                        "PictureLocation= VALUES(PictureLocation)," +
                        "ShowCaption= VALUES(ShowCaption)," +
                        " Hidden=VALUES(Hidden)";

                    DataAccess.ExecuteSQL(sqlCommand);

                    //MessageBox.Show("description--->"+_description.ToString());
                    /*
                    this.Close();
                    MdiParent.Refresh();
                    */

                } // end new insert

                                
                else
                {
                    if (menuGroupDescriptionTextBox.Text == "000")
                    {
                        string sqlCmd = " insert into menugroup (Description,DisplayIndex)  values ('" + menuGroupDescriptionTextBox.Text + "5'  )";
                        DataAccess.ExecuteSQL(sqlCmd);
                        menuGroupDescriptionTextBox.Text = "";
                        //lblMsg.Visible = true;
                        //lblMsg.Text = 
                        MessageBox.Show("Successfully saved");

                    }
                    /*
                    else  //Update 
                    {
                        string sqlUpdateCmd = " update tbl_category set category_name = '" + txtCategoryName.Text + "'   where ID = '" + lblID.Text + "'";
                        DataAccess.ExecuteSQL(sqlUpdateCmd);
                        // lblMsg.Visible = true;
                        // lblMsg.Text = "Successfully Updated";
                        this.Hide();
                        Items.Categories mkc = new Items.Categories();
                        mkc.MdiParent = this.ParentForm;
                        mkc.Show();
                    }
                    */
                }

                this.Close();
                //MdiParent.con
                MdiParent.Refresh();

            }
            catch (Exception exp)
            {
                MessageBox.Show("Sorry\r\n this id already added \n\n " + exp.Message);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void buttonPositionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
