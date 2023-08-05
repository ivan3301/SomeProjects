using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjectLib
{
    public partial class Form_ViewInfo : Form
    {
        public Form_ViewInfo()
        {
            InitializeComponent();
        }
        public string tbValue
        {
            set { tbInfo.Text = value; }
        }
    }
}
