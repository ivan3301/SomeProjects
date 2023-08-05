using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectLib
{
    public partial class Form_Authorization : Form
    {
        ClassAuthorization classAuthorization = new ClassAuthorization();        
        public Form_Authorization()
        {
            InitializeComponent();
        }
        private void Form_Authorization_Load(object sender, EventArgs e)
        {
            txtB_password.PasswordChar = '*';
            txtB_password.MaxLength = 25;
            txtB_login.MaxLength = 25;
        } 
        private void btn_signin_Click(object sender, EventArgs e)
        {
            classAuthorization.getAuthorizatiton(txtB_login, txtB_password, this);
        }
    }
}
