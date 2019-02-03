using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop.MenuGroups
{
    public partial class MenuGroupsAll : Form
    {
        public MenuGroupsAll()
        {
            InitializeComponent();
        }

        private void MenuGroupsAll_Load(object sender, EventArgs e)
        {
            var c = GetAll(this, typeof(Button));
            Console.WriteLine(c.ToString());
            MessageBox.Show("Total Controls: " + c.Count());

        }

        public Point initialPos;
        public Point destinationPos;

        public Point DestinationPos { get => destinationPos; set => destinationPos = value; }

        Point? GetRowColIndex(TableLayoutPanel tlp, Point point)
        {
            if (point.X > tlp.Width || point.Y > tlp.Height)
                return null;

            int w = tlp.Width;
            int h = tlp.Height;
            int[] widths = tlp.GetColumnWidths();

            int i;
            for (i = widths.Length - 1; i >= 0 && point.X < w; i--)
                w -= widths[i];
            int col = i + 1;

            int[] heights = tlp.GetRowHeights();
            for (i = heights.Length - 1; i >= 0 && point.Y < h; i--)
                h -= heights[i];

            int row = i + 1;
            //Console.WriteLine("col-->" + col);
            //Console.WriteLine("row-->" + row);
            return new Point(col, row);
        }


        private void drag_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    // get the currernt position of the cell 
                    Console.WriteLine("Trying to get Initial Pos-->" + initialPos.ToString());

                    Control root = (sender) as Button;
                    Console.WriteLine("Right click " + root.Parent.Name.ToString());
                    TableLayoutPanel tbl = root.Parent as TableLayoutPanel;


                    // get destination position of new cell

                    var cellPos = GetRowColIndex(
                        tbl,
                        tbl.PointToClient(Cursor.Position));
                    destinationPos = (Point)cellPos;

                    Console.WriteLine("                                            dest:-> "+ tbl.PointToClient(Cursor.Position).ToString());

                    if (tbl.GetControlFromPosition(destinationPos.X, destinationPos.Y) == null)
                    {
                        

                        root.Dock = DockStyle.Fill;
                        tbl.Controls.Add(root, destinationPos.X, destinationPos.Y);
                        Console.WriteLine("Button " + root.Text + " Moved Successfully");

                    }
                    else
                    {

                        MessageBox.Show("we have " + tbl.GetControlFromPosition(destinationPos.X, destinationPos.Y).ToString() + " here");
                    }

                    Console.WriteLine("Mouse Up at ---->" + cellPos.ToString()+": "+ root.Parent.Name.ToString());
                }


                catch (Exception e1)
                {

                    MessageBox.Show("Can't move outside the table " + e1.Message);
                }
            }


        }

        private void drag_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Control root = (sender) as Button;
                Console.WriteLine("Right click "+root.Parent.Name.ToString());
                TableLayoutPanel tbl = root.Parent as TableLayoutPanel; 

               // Console.WriteLine("what is our parent?"+this.Parent.Parent.Parent.Controls.ToString());

                var cellPos = GetRowColIndex(
                    tbl,
                    tbl.PointToClient(Cursor.Position));
                //tableLayoutPanel1.GetControlFromPosition(destinationPos.X, destinationPos.Y).BackColor = Color.Red;
                // our initial Point 

                Console.WriteLine("Mouse Down on button");
                Console.WriteLine("We are initially at-->" + cellPos.ToString());
                initialPos = (Point)cellPos;
                Console.WriteLine("Set Initail Pos to-----}" + initialPos);

            }

            //if (e.Button == System.Windows.Forms.MouseButtons.Left) { MessageBox.Show("Left click"); }

        }
        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void myButton31_Click(object sender, EventArgs e)
        {
            var c = GetAll(this, typeof(Button));
            Console.WriteLine(c.ToString());
            MessageBox.Show("Total Controls: " + c.Count());
        }

        public  void EnumerateChildren(Control root)
        {
            foreach (Control control in root.Controls)
            {

                Console.WriteLine("Control [{0}] - Parent [{1}]",
                    control.Name, root.Name);


                if (control.Controls != null)
                {
                    EnumerateChildren(control);
                }
            }
        }

        public void FindParent(Control root, Control child)
        {
            foreach (Control control in root.Controls)
            {


               // Console.WriteLine("Control [{0}] - Parent [{1}]",
                //    control.Name, root.Name);
                if (control.Controls != null)
                {
                    FindParent(control,child);
                }

                if (control.Name == child.Name) {
                    Console.WriteLine("--------> found Parent for " +root.Name);
                }


            }
        }

        private void myButton32_Click(object sender, EventArgs e)
        {
             EnumerateChildren(this);
            //FindParent(this, this.Controls["button2"]);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
