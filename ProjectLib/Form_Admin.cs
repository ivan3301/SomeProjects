using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ProjectLib
{
    public partial class Form_Admin : Form
    {      
        ClassAdmin classAdmin = new ClassAdmin();
        AdminMethods admMeth = new AdminMethods();
        private int selectedRow;
        public Form_Admin()
        {
            InitializeComponent();
        }
        //Создание столбцов
        private void createColumns()
        {
            dgvAdmin.Columns.Add("login","Логин");
            dgvAdmin.Columns.Add("password", "Пароль");
            dgvAdmin.Columns.Add("name", "Ф.И.О.");
            dgvAdmin.Columns.Add("IsNew", "Status");
            dgvAdmin.Columns[3].Visible = false;
            dgvAdmin.Columns[0].Width = 120; dgvAdmin.Columns[1].Width = 110; dgvAdmin.Columns[2].Width = 165;
            dgvAdmin.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dgvAdmin.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dgvAdmin.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAdmin.RowHeadersVisible = false;
            dgvAdmin.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dgvAdmin.EnableHeadersVisualStyles = false;
            dgvAdmin.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        }
        //Вывод значений из DB в dgv при открытии формы
        private void Form_Admin_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btn_adduser, "Добавление записи");
            t.SetToolTip(btn_changeuser, "Изменение записи");
            t.SetToolTip(btn_clear, "Очистка полей");
            t.SetToolTip(btn_deluser, "Удаление записи");
            createColumns();
            admMeth.getUpdDgv(dgvAdmin);
        }
        //Заполнение textBox'ов соответствующими данными при выборе записи из dgv
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dgvAdmin.Rows[selectedRow];
                txtB_login.Text = row.Cells[0].Value.ToString();
                txtB_password.Text = row.Cells[1].Value.ToString();
                txtB_name.Text = row.Cells[2].Value.ToString();
            }
        }
        //Удаление учетной записи
        private void btn_deluser_Click(object sender, EventArgs e)
        {
            classAdmin.getDelUser(dgvAdmin);
        }
        //Изменение учетной записи
        private void btn_changeuser_Click(object sender, EventArgs e)
        {
            classAdmin.getChangeUser(dgvAdmin, txtB_login, txtB_password, txtB_name);            
        }
        //Добавление учетной записи
        private void btn_adduser_Click(object sender, EventArgs e)
        {
            classAdmin.getAddUser(txtB_login,txtB_password, txtB_name, dgvAdmin);            
        }
        //Очистка textBox'ов
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txtB_login.Text = "";
            txtB_password.Text = "";
            txtB_name.Text = "";
        }
        //Завершение работы приложения при закрытии формы
        private void Form_Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}