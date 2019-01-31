using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supershop
{
    public class MyGroupButton : Button
    {
        public string description;

        public string Description { get { return description; } set { description = value; } }
    }
}
