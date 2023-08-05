using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectLib
{
    class AdminMethods
    {
        DataBase dataBase = new DataBase();
        public enum RowState //Состояния записей
        {
            Deleted,
            New,
            Existed,
            Modified,
            ModifiedNew
        }
        private void updDataGridView(DataGridView dgv) //Обновление таблицы
        {
            dgv.Rows.Clear();

            string queryUpd = $"SELECT * FROM users_db";
            dataBase.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(queryUpd, dataBase.getConnection());
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                readRow(dgv, dataReader);
            }
            dataReader.Close();
            dataBase.CloseConnection();
        }
        private void readRow(DataGridView dgv, IDataRecord dataRecord) //Заполнение таблицы
        {
            dgv.Rows.Add(dataRecord.GetString(0), dataRecord.GetString(1), dataRecord.GetString(2), RowState.ModifiedNew);
        }
        private Boolean checkUser(TextBox tbLog) //Проверка на соответствие по логину при добавлении
        {
            string loginUser = tbLog.Text;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();

            string queryCheck = $"SELECT login FROM users_db WHERE login = N'{loginUser}'";

            SqlCommand sqlCommand = new SqlCommand(queryCheck, dataBase.getConnection());

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(dataTable);

            if (dataTable.Rows.Count > 0)
                return false;
            else
                return true;
        }        
        private void checkRowState(DataGridView dgv) //Проверка состояния
        {
            dataBase.OpenConnection();
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                RowState rowState = (RowState)dgv.Rows[i].Cells[3].Value;
                if (rowState == RowState.Deleted)
                {
                    string login = dgv.Rows[i].Cells[0].Value.ToString();
                    if (login == "adm")
                        MessageBox.Show("Данную запись удалить нельзя!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        string queryDel = $"DELETE FROM users_db where login = N'{login}'";
                        SqlCommand sqlCommand = new SqlCommand(queryDel, dataBase.getConnection());
                        sqlCommand.ExecuteNonQuery();
                        dgv.Rows[i].Visible = false;
                    }
                }

                if (rowState == RowState.Modified)
                {
                    string login = dgv.Rows[i].Cells[0].Value.ToString();
                    string password = dgv.Rows[i].Cells[1].Value.ToString();
                    string name = dgv.Rows[i].Cells[2].Value.ToString();
                    string queryChange = $"UPDATE users_db SET password = N'{password}', name = N'{name}' WHERE login = N'{login}'";
                    SqlCommand sqlCommand = new SqlCommand(queryChange, dataBase.getConnection());
                    if (sqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Данные успешно изменены!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Возможно, вы пытались изменить логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dataBase.CloseConnection();
        }
        public void deleteRow(DataGridView dgv) //Пометка на удаление
        {
            int ind = dgv.CurrentCell.RowIndex;
            dgv.Rows[ind].Cells[3].Value = RowState.Deleted;
        }
        //Доступ для вызова методов
        public void getUpdDgv(DataGridView dgv)
        {
            updDataGridView(dgv);
        }
        public Boolean getCheckUser(TextBox tbLog)
        {
            return checkUser(tbLog);
        }
        public void getCheckRowState(DataGridView dgv)
        {
            checkRowState(dgv);
        }
    }
}
