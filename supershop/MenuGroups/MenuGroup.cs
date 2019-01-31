using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


//using Supershop.DataAccess;

namespace supershop.Ordering
{
    public partial class MenuGroup : Form
    {
        public MenuGroup()
        {
            InitializeComponent();
           // this.Controls.Clear();
        }
        

        private void MenuGroup_Load(object sender, EventArgs e)
        {
            
            // moved this code to activated ....
            /*

            try {
                // connect to db
                // get stuff from menu groups table
                string sql = "select ID," +
                             " Description," +
                             " DisplayIndex," +
                             " Hidden," +
                             " Color," +
                             "PictureLocation," +
                             "ShowCaption" +
                             " from menugroup";
               
                DataTable dt = DataAccess.GetDataTable(sql);

                //get the count of the table

                // start for loop to get rows
                for (int i = 0; i < dt.Rows.Count; i++) {

                    //string btnName = String.Empty;
                    string description = dt.Rows[i][1].ToString();
                    int buttonIndex = Int32.Parse( dt.Rows[i][2].ToString()); // display index value
                    string buttonHidden = dt.Rows[i][3].ToString();
                    string buttonColor = dt.Rows[i][4].ToString(); 
                    string pictureLocation = dt.Rows[i][5].ToString();
                    string showCaption = dt.Rows[i][6].ToString();
                    string btnName = "button" + buttonIndex;

                    ExTag exTag = new ExTag();
                    exTag.Add("description", description);//person is an example. Imagine it's an instance of Person class
                    exTag.Add("buttonIndex", buttonIndex);
                    exTag.Add("buttonColor", buttonColor);
                    exTag.Add("hidden", buttonHidden);
                    exTag.Add("pictureLocation", pictureLocation);
                    exTag.Add("showCaption", showCaption);
                    //get all buttons

                    foreach (Control ctrl in this.gbPage1.Controls) {

                        if (ctrl.Name == btnName && showCaption == "True")
                        {

                            ctrl.Text = description; //dt.Rows[i][1].ToString();
                            ctrl.Tag = exTag;

                        }

                         if (ctrl.Name == btnName && showCaption == "False")
                        {
                            ctrl.Text = ".";
                            ctrl.Font = new Font("Microsoft Sans Serif", 1);
                            ctrl.Tag = exTag;

                        }
                        if ( ctrl.Name == btnName && description=="") 
                        {
                            ctrl.Tag = null;
                            MenuGroupEditor mgeNew = new MenuGroupEditor();
                            mgeNew.ShowDialog();

                        }

                    }//end foreach


                } // end for ROWS

                

                string p = (dt.Rows.Count.ToString());
               
            }


            catch(Exception e1) {
                label1.Text = e1.Message;

            }

            */
           

        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // might want to delete this
        private void myGroupButton2_Click(object sender, EventArgs e)
        {
           
           

        }

        
        private void button_click_menuGroupEditor(object sender, EventArgs e)
        {
            MyButton clickedButton = (MyButton)sender;
            //clickedButton.BackColor = MyButton.BackgroundColor("#C00A27");
            // MessageBox.Show("position here is " + clickedButton.Position);
            string _position = clickedButton.Position;
            

            using (MenuGroupEditor mge = new MenuGroupEditor())
            {
                //MessageBox.Show(myGroupButton2.Text);

                ExTag exTag = (ExTag)(clickedButton.Tag);

                 //MessageBox.Show("index is 156-->"+_position.ToString());
                //todo: add try catch 
                mge.ButtonPosition = _position;

                
                if ( exTag !=null)
                {
                    mge.GroupID = exTag.Get("id").ToString();
                    mge.GroupDescription = exTag.Get("description").ToString();
                    mge.GroupPictureLocation = exTag.Get("pictureLocation").ToString();
                    mge.GroupIndexLocation = exTag.Get("displayIndex").ToString(); // from database

                    try { 
                        if ( String.IsNullOrEmpty(mge.ButtonColor = exTag.Get("buttonColor").ToString()) )
                        {

                             mge.ButtonColor = "##6AAAEA";
                        }
                        

                    }
                    catch (Exception e3)
                    {
                        MessageBox.Show("Line 164->" + e3.Message);

                    }
                   


                    MessageBox.Show("position is -->" + _position.ToString());
                    //mge.GroupButtonLocation = exTag.Get("positionIndex").ToString();    // gets the ( i ) of the button from the loop
                    // MessageBox.Show("hey->"+exTag.Get("showCaption").ToString());

                    /*
                    if (mge.ShowCaption == Int32.Parse(exTag.Get("showCaption").ToString()) == 0)
                    {

                        mge.ShowCaption = 0;
                        // this.Text = "";
                    }
                    else
                    {
                        mge.ShowCaption = 1;
                    }
                    */
                    
                } // end if !null

                else
                {
                    // adding a new button 
                    MessageBox.Show("we should add new button here at -->" + _position);
                    
                    mge.GroupID = "nothing here yet";
                    mge.GroupPictureLocation = "";
                   
                
                    MessageBox.Show("position here is -->" + _position.ToString());
                    // disable position text box 
                    
                }
                MessageBox.Show("do we get here? position-->" + _position.ToString());
                mge.MdiParent = this.ParentForm;
                mge.ShowDialog();
                                
               // MessageBox.Show("bool-->"+ exTag.Get("showCaption").ToString());

            }


        }

        private void MenuGroup_Activated(object sender, EventArgs e)
        {
            
            
            try
            {
                // connect to db
                // get stuff from menu groups table and display to our form
                string sql = "select ID," +
                             " Description," +
                             " DisplayIndex," +
                             " Hidden," +
                             " Color," +
                             "PictureLocation," +
                             "ShowCaption" +
                             " from menugroup";

                DataTable dt = DataAccess.GetDataTable(sql);

                //get the count of the table

                // start for loop to get rows from database, and then display 
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                   // MessageBox.Show("starting loop");
                    string id = dt.Rows[i][0].ToString();
                    string description = dt.Rows[i][1].ToString();

                    int displayIndex=1;
                    Int32.TryParse(dt.Rows[i][2].ToString(), out displayIndex);
                    int buttonHidden;
                    Int32.TryParse(dt.Rows[i][3].ToString(), out buttonHidden);
                    string showCaption = dt.Rows[i][6].ToString();

                    string buttonColor = dt.Rows[i][4].ToString();
                    string pictureLocation = dt.Rows[i][5].ToString();
                    string btnName = "myButton" + displayIndex.ToString(); //to concatenate 
                    Console.WriteLine("btnName--->"+btnName);
                    // int buttonHidden = Int32.Parse(dt.Rows[i][3].ToString());
                    
                    // MessageBox.Show("buttonHidden "+ buttonHidden);
                    //int showCaption = Int32.Parse(dt.Rows[i][6].ToString());


                    // MessageBox.Show("desc-->"+description + " --buttonHidden->"+buttonHidden);
                    //  int positionIndex = i+1;    // to send with button once clicked on so it could be saved there 

                    // add to the tags dictionary those properties
                    ExTag exTag = new ExTag();
                    exTag.Add("id", id);
                    exTag.Add("description", description);
                    exTag.Add("displayIndex", displayIndex);

                    try {
                        if (!string.IsNullOrEmpty(buttonColor))
                        {
                            exTag.Add("buttonColor", buttonColor);

                        }
                        else
                        {
                            buttonColor = "#6AAAEA";
                            exTag.Add("buttonColor", buttonColor);

                        }
                    }
                    catch( Exception e2 ) 
                    {

                        MessageBox.Show("Error line 264--> " + e2.Message);
                
                
                }  
                    
                    
                    
                    exTag.Add("hidden", buttonHidden);
                    exTag.Add("pictureLocation", pictureLocation);
                    exTag.Add("showCaption", showCaption);

                    Console.WriteLine("show caption --->" + showCaption );
                    
                    // exTag.Add("positionIndex", positionIndex);

                    //get all buttons

                    foreach (Control ctrl in this.gbPage1.Controls)
                    {
                        //MessageBox.Show(ctrl.Name);

                        //todo check when the form has an index that is out of range !!

                        if (ctrl.Name == btnName && buttonHidden == 1)
                        {
                            ctrl.Text = "hide button!!";    // replace this text with a dot 
                            ctrl.Font = new Font("Microsoft Sans Serif", 10);
                            ctrl.Tag = null;

                        }

                        else if (ctrl.Name == btnName && showCaption == "1" && buttonHidden == 0)
                        {

                            ctrl.Text = description;
                            ctrl.Font = new Font("Microsoft Sans Serif", 12);
                            ctrl.Tag = exTag;
                            
                            ctrl.BackColor = System.Drawing.ColorTranslator.FromHtml(buttonColor);

                        }

                        else if (ctrl.Name == btnName &&  showCaption == "0" && buttonHidden == 0)
                        {
                            ctrl.Text = "hide caption";    // replace this text with a dot 
                            ctrl.Font = new Font("Microsoft Sans Serif", 1);
                            ctrl.Tag = exTag;

                        }

                       // else { ctrl.Tag = null; }
                                                


                        /*
                         
                     if (showCaption == "0") {
                            ctrl.Text = ".";
                            ctrl.Font = new Font("Microsoft Sans Serif", 1);
                            ctrl.Tag = exTag;
                        }
                       

                        if (ctrl.Name == btnName && showCaption == 0)
                        {
                            ctrl.Text = ".";
                            ctrl.Font = new Font("Microsoft Sans Serif", 1);
                            //ctrl.Tag = exTag;

                        }
                        if (ctrl.Name == btnName && description == "")
                        {
                            ctrl.Tag = null;
                            MessageBox.Show("line 299 ?? I dont get here?");

                            MenuGroupEditor mgeNew = new MenuGroupEditor();
                            mgeNew.ShowDialog();

                        }

                        else
                        {
                            //MessageBox.Show("we are probably here? ");
                            Console.WriteLine("stuck at 307");
    
                        }
                         * */



                    }//end foreach


                } // end for ROWS

                this.Refresh();

            }

         

            catch (Exception e1)
            {
                label1.Text = " is it?----->>>"+e1.Message;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbPage1_Enter(object sender, EventArgs e)
        {

        }
    }
}
