using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Data.Common;
using System.Xml.Linq;

namespace ProjectLib
{
    public partial class Form_Main : Form
    {
        private int selectedId;
        
        DataBase dataBase = new DataBase();
        ClassLibWorker libwor = new ClassLibWorker();
        ClassReader classReader = new ClassReader();
        public Form_Main()
        {
            InitializeComponent();
        }        
        public void BtnHide()
        {
            classReader.getHideBtn(btn_add, btn_del, btn_edit);
        }
        private void styleDgv(DataGridView dgv)
        {
            for (int i = 0; i < 6; ++i)
                dgv.Columns[i].ReadOnly = true;
            dgv.Columns[0].Width = 35; dgv.Columns[1].Width = 110;
            dgv.Columns[2].Width = 400; dgv.Columns[3].Width = 137;
            dgv.Columns[4].Width = 75; dgv.Columns[5].Width = 68;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            /*foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }*/
        }
        /*private void readRow(DataGridView dgv, IDataRecord dataRecord) //Заполнение таблицы
        {
            dgv.Rows.Add(Convert.ToString(dataRecord.GetInt32(0)), dataRecord.GetString(1), dataRecord.GetString(2) + " " + dataRecord.GetString(3), dataRecord.GetString(4), Convert.ToString(dataRecord.GetInt32(5)), dataRecord.GetString(6));
        }*/
        private void Form_Main_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(btnUpdGrid, "Обновление таблицы");
            t.SetToolTip(btn_add, "Добавление записи");
            t.SetToolTip(btn_view, "Каталожная карточка");
            t.SetToolTip(btn_del, "Удаление записи");
            t.SetToolTip(btn_edit, "Изменение записи");

            dgvBook.Columns.Add("id", "ID");
            dgvBook.Columns.Add("author", "Автор");
            dgvBook.Columns.Add("title", "Заглавие");
            dgvBook.Columns.Add("pubhouse", "Издательство");
            dgvBook.Columns.Add("pubyear", "Год издания");
            dgvBook.Columns.Add("size", "Объем страниц");
            styleDgv(dgvBook);
            string query =
                $"SELECT mainTableBook_db.id, authorBook_db.first_author, titleBook_db.title_text, " +
                $"titleBook_db.contin_title, publishingHouse_db.publ_house, publishingHouse_db.year_publ, mainTableBook_db.size " +
                $"FROM mainTableBook_db " +
                $"INNER JOIN authorBook_db ON mainTableBook_db.author = authorBook_db.author " +
                $"INNER JOIN publishingHouse_db ON mainTableBook_db.publishing_house = publishingHouse_db.publishing_house " +
                $"INNER JOIN titleBook_db ON mainTableBook_db.title = titleBook_db.title";

            dataBase.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.getConnection());
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                dgvBook.Rows.Add(Convert.ToString(dataReader.GetInt32(0)), dataReader.GetString(1), dataReader.GetString(2) + " " + dataReader.GetString(3), dataReader.GetString(4), Convert.ToString(dataReader.GetInt32(5)), dataReader.GetString(6));
            }
            dataReader.Close();
            dataBase.CloseConnection();
            /*dgvBook.Rows.Add("1", "Алиев, В. К.", "Просто компьютер", "СОЛОН-Пресс", "2002", "143 с.");
            dgvBook.Rows.Add("2", "Глинка, Н. Л.", "Задачи и упражнения по общей химии", "Интеграл-Пресс", "2002", "240 с.");
            dgvBook.Rows.Add("3", "Выдрин, И. В.", "Конституционное право России", "Издательство УрГЮА", "2001", "546 с.");
            dgvBook.Rows.Add("4", "Башина, О. Э.", "Общая теория статистики", "Финансы и статистика", "2003", "440 с.");
            dgvBook.Rows.Add("5", "Колчин, С. П.", "Налоги в Российской Федерации", "Юнити", "2002", "254 с.");
            dgvBook.Rows.Add("6", "Новицкий, Н. И.", "Организация производства на предприятиях", "Финансы и статистика", "2003", "390 с.");
            dgvBook.Rows.Add("7", "Власов, Ю. Н.", "Нотариат в Российской Федерации", "Юрайт-М", "2001", "464 с.");
            dgvBook.Rows.Add("8", "Соколов, Я. В.", "История бухгалтерского учета", "Финансы и статистика", "2003", "271 с.");
            dgvBook.Rows.Add("9", "Ансеров, М. А.", "Приспособления для металорежущих станков", "Машиностоение. Ленинградское отделение", "1975", "655 с.");
            dgvBook.Rows.Add("10", "Ермаков, С. М.", "Математическая теория оптимального эксперимента", "Наука", "1987", "319 с.");
            dgvBook.Rows.Add();*/
        }
        private void btnUpdGrid_Click(object sender, EventArgs e)
        {
            dgvBook.Rows.Clear();
            dgvBook.Columns.Clear();
            Form_Main_Load(sender, e);
        }        
        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = e.RowIndex;

            if (selectedRow >= 0)
            {
                DataGridViewRow row = dgvBook.Rows[selectedRow];
                selectedId = int.Parse(row.Cells[0].Value.ToString());
            }
        }
        //////////////////////////////////////////////////////
        private void btn_add_Click(object sender, EventArgs e)
        {
            libwor.getAddBook();
        }
        private void btn_view_Click(object sender, EventArgs e)
        {
            if (selectedId != 0)
                libwor.getViewInfo(selectedId);
            else MessageBox.Show("Выберите запись");
            /*if (selectedId != 0)
            {
                string str = "", queryInfoBook =
                $"SELECT indexShelf_db.index_shelf, mainTableBook_db.cn, indexShelf_db.copyright_sign, " +
                $"authorBook_db.first_author, titleBook_db.title_text, titleBook_db.contin_title, " +
                $"titleBook_db.responsibility, mainTableBook_db.edition_info, publishingHouse_db.place_publ, " +
                $"publishingHouse_db.publ_house, publishingHouse_db.year_publ, mainTableBook_db.size, mainTableBook_db.isbn, " +
                $"indexShelf_db.price, mainTableBook_db.catalog_ind, mainTableBook_db.index_bbk, mainTableBook_db.index_udk " +
                $"FROM mainTableBook_db " +
                $"INNER JOIN indexShelf_db ON mainTableBook_db.index_shelf = indexShelf_db.id_indShelf " +
                $"INNER JOIN authorBook_db ON mainTableBook_db.author = authorBook_db.author " +
                $"INNER JOIN publishingHouse_db ON mainTableBook_db.publishing_house = publishingHouse_db.publishing_house " +
                $"INNER JOIN titleBook_db ON mainTableBook_db.title = titleBook_db.title " +
                $"WHERE mainTableBook_db.id = '{selectedId}'";
                dataBase.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(queryInfoBook, dataBase.getConnection());
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    str = dataReader.GetString(0) + "\r\n" + dataReader.GetString(1) + "\r\n" +
                        dataReader.GetString(2) + "\r\n" + dataReader.GetString(3) + " " +
                        dataReader.GetString(4) + ":" + dataReader.GetString(5) + "/ " +
                        dataReader.GetString(6) + ". - " + dataReader.GetString(7) + " - " +
                        dataReader.GetString(8) + ": " + dataReader.GetString(9) + ", " +
                        Convert.ToString(dataReader.GetInt32(10)) + ". - " + dataReader.GetString(11) +
                        " - ISBN " + dataReader.GetString(12) + ":" + Convert.ToString(dataReader.GetDouble(13)) +
                        "\r\n" + dataReader.GetString(14) + "\r\nББК: " + dataReader.GetString(15) + "\r\nУДК: " +
                        dataReader.GetString(16);
                }
                dataReader.Close();
                dataBase.CloseConnection();

                Form_ViewInfo formVI = new Form_ViewInfo();
                formVI.tbValue = str;
                formVI.Show();
            }
            else MessageBox.Show("Выберите запись");*/
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (selectedId != 0)
                libwor.getChangeInfoBook(selectedId);
            else MessageBox.Show("Выберите запись");
        }
        private void btn_del_Click(object sender, EventArgs e)
        {
            libwor.getDeleteBook(selectedId);
            dgvBook.Rows.Clear();
            dgvBook.Columns.Clear();
            Form_Main_Load(sender, e);
            /*if (selectedId != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить эту запись?", "Удаление записи", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        int idTitle = 0, idShelfInd = 0;
                        string strNums = "", queryExtractId =
                            $"SELECT mainTableBook_db.title, mainTableBook_db.index_shelf, indexShelf_db.inv_num " +
                            $"FROM mainTableBook_db " +
                            $"INNER JOIN titleBook_db ON mainTableBook_db.title = titleBook_db.title " +
                            $"INNER JOIN indexShelf_db ON mainTableBook_db.index_shelf = indexShelf_db.id_indShelf " +
                            $"WHERE mainTableBook_db.id = '{selectedId}'";
                        dataBase.OpenConnection();
                        SqlCommand sqlCommand = new SqlCommand(queryExtractId, dataBase.getConnection());
                        SqlDataReader dataReader = sqlCommand.ExecuteReader();
                        while (dataReader.Read())
                        {
                            idTitle = dataReader.GetInt32(0);
                            idShelfInd = dataReader.GetInt32(1);
                            strNums = dataReader.GetString(2);
                        }
                        dataReader.Close();
                        dataBase.CloseConnection();
                        //MessageBox.Show("Заглавие: " + idTitle.ToString() + "\nПолочный индекс: " + idShelfind.ToString() +
                        //    "\nНомера: " + strNums);
                        int[] arrNums = strNums.Split('-').Select(int.Parse).ToArray();
                        //Удаление из главной таблицы, заглавия, полочного индекса
                        string queryDelBook =
                            $"DELETE FROM mainTableBook_db WHERE id = '{selectedId}' " +
                            $"DELETE FROM titleBook_db WHERE title = '{idTitle}' " +
                            $"DELETE FROM indexShelf_db WHERE id_indShelf = '{idShelfInd}'";
                        dataBase.OpenConnection();
                        SqlCommand sqlCommandDel1 = new SqlCommand(queryDelBook, dataBase.getConnection());
                        sqlCommandDel1.ExecuteNonQuery();
                        dataBase.CloseConnection();
                        //Удаление инвентарных номеров
                        for (int i = 0; i < arrNums.Length; ++i)
                        {
                            string queryDelInvNum = $"DELETE FROM invNum_db WHERE inv_num = '{arrNums[i]}'";
                            dataBase.OpenConnection();
                            SqlCommand sqlCommandDel2 = new SqlCommand(queryDelInvNum, dataBase.getConnection());
                            sqlCommandDel2.ExecuteNonQuery();
                            dataBase.CloseConnection();
                        }                        
                        break;
                    case DialogResult.No:
                        break;
                }
            }*/
        }        
        private void txtBox_search_TextChanged(object sender, EventArgs e)
        {
            libwor.getSearchBook(dgvBook, radBtn_aut, radBtn_title, radBtn_keyword, txtBox_search);
        }                
    }
}
