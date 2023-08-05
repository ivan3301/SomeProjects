using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using ProjectLib;

namespace ProjectLib
{
    class ClassAuthorization
    {
        DataBase dataBase = new DataBase();

        private void Authorizatiton(TextBox txtB_login, TextBox txtB_password, Form_Authorization thisForm)
        {
           try
           {
                dataBase.OpenConnection();
                if (txtB_login.Text == "" && txtB_password.Text == "")
                {
                    MessageBox.Show("Вы вошли как читатель!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form_Main formMain = new Form_Main();
                    formMain.BtnHide();
                    formMain.Show();
                    thisForm.Hide();
                }
                else
                {
                    string loginUser = txtB_login.Text;
                    string passwordUser = ClassMD5.encryptedPass(txtB_password.Text);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    DataTable table = new DataTable();

                    string queryLogin = $"SELECT login, password FROM users_db WHERE login = '{loginUser}' AND password = '{passwordUser}'";
                    SqlCommand sqlCommand = new SqlCommand(queryLogin, dataBase.getConnection());

                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(table);

                    if (table.Rows.Count == 1 && loginUser == "adm")
                    {
                        MessageBox.Show("Вы авторизировались как администратор!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form_Admin formAdmin = new Form_Admin();
                        formAdmin.Show();
                        thisForm.Hide();
                    }
                    else
                    {
                        if (table.Rows.Count == 1)
                        {
                            MessageBox.Show("Вы авторизировались как библиотекарь!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Form_Main formMain = new Form_Main();
                            formMain.Show();
                            thisForm.Hide();
                        }
                        else
                            MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dataBase.CloseConnection();
            }
            catch { MessageBox.Show("Нет связи с базой данных!", "Ошибка подключения"); }            
        }
        public void getAuthorizatiton(TextBox txtB_login, TextBox txtB_password, Form_Authorization thisForm)
        {
            Authorizatiton(txtB_login, txtB_password, thisForm);
        }
    }
}
