using ProjectLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectLib
{
    class ClassAdmin
    {
        DataBase dataBase = new DataBase();
        AdminMethods admMethods = new AdminMethods();
        Regex pattern = new Regex("^[a-zA-Z0-9]*$", RegexOptions.Compiled);

        //-----ДОБАВЛЕНИЕ учетной записи
        private void AddUser(TextBox tbLog, TextBox tbPass, TextBox tbName, DataGridView dgv)
        {
            if (tbLog.Text != "" && tbPass.Text != "" && tbName.Text != "" &&
                tbLog.Text.Length >= 3 && tbLog.Text.Length <= 8 &&
                tbPass.Text.Length >= 3 && tbPass.Text.Length <= 8 &&
                pattern.IsMatch(tbLog.Text) && pattern.IsMatch(tbPass.Text))
            {
                if (admMethods.getCheckUser(tbLog))
                {
                    string loginUser = tbLog.Text;
                    string passwordUser = ClassMD5.encryptedPass(tbPass.Text);
                    string name = tbName.Text;

                    string queryAdd = $"INSERT INTO users_db(login, password, name) VALUES (N'{loginUser}', N'{passwordUser}', N'{name}')";
                    dataBase.OpenConnection();
                    SqlCommand sqlCommand = new SqlCommand(queryAdd, dataBase.getConnection());

                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Аккаунт добавлен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении аккаунта!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    dataBase.CloseConnection();
                    admMethods.getUpdDgv(dgv);
                    tbLog.Text = "";
                    tbPass.Text = "";
                    tbName.Text = "";
                }
                else
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Для логина и пароля допустимы буквы латинского алфавита и цифры!\nДлина логина и пароля от 3 до 8 символов.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
        //-----УДАЛЕНИЕ учетной записи
        private void DelUser(DataGridView dgv)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление записи", MessageBoxButtons.YesNo);
            switch (dialogResult)
            {
                case DialogResult.Yes:
                    //Пометка на удаление
                    admMethods.deleteRow(dgv);
                    //Удаление
                    admMethods.getCheckRowState(dgv);
                    break;
                case DialogResult.No:
                    break;
            }
        }       
        //-----ИЗМЕНЕНИЕ учетной записи
        private void ChangeUser(DataGridView dgv, TextBox tbLog, TextBox tbPass, TextBox tbName)
        {
            int selectedRowIndex = dgv.CurrentCell.RowIndex;
            string loginUser = tbLog.Text;
            string passwordUser = ClassMD5.encryptedPass(tbPass.Text);
            string name = tbName.Text;

            if (dgv.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                if (tbPass.Text != "" && tbName.Text != "" &&
                    tbPass.Text.Length >= 3 && tbPass.Text.Length <= 8 &&
                    pattern.IsMatch(tbPass.Text))
                {
                    AdminMethods.RowState rs = AdminMethods.RowState.Modified;
                    dgv.Rows[selectedRowIndex].SetValues(loginUser, passwordUser, name);
                    dgv.Rows[selectedRowIndex].Cells[3].Value = rs;
                }
                else
                    MessageBox.Show("Для пароля допустимы буквы латинского алфавита и цифры!\nДлина пароля от 3 до 8 символов.\nИзменение логинов запрещено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            admMethods.getCheckRowState(dgv);
            admMethods.getUpdDgv(dgv);
        }
        //-----Вызов метода добавления учетной записи
        public void getAddUser(TextBox tbLog, TextBox tbPass, TextBox tbName, DataGridView dgv)
        {
            AddUser(tbLog, tbPass, tbName, dgv);
        }
        //-----Вызов метода удаления учетной записи
        public void getDelUser(DataGridView dgv)
        {
            DelUser(dgv);
        }
        //-----Вызов метода изменения учетной записи
        public void getChangeUser(DataGridView dgv, TextBox tbLog, TextBox tbPass, TextBox tbName)
        {
            ChangeUser(dgv, tbLog, tbPass, tbName);
        }
    }
}
