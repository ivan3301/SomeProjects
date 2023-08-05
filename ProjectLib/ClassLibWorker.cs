using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ProjectLib;

namespace ProjectLib
{
    class ClassLibWorker
    {
        DataBase dataBase = new DataBase();

        private void AddBook()
        {
            Form_InfoBook formInfoBook = new Form_InfoBook();
            formInfoBook.Show();
            formInfoBook.getBtnAddShow();
        }
        private void ViewInfo(int selectedId)
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
                    " - ISBN " + dataReader.GetString(12) + ":" + ((dataReader.GetDecimal(13)).ToString()).Replace(",", ".") +
                    "\r\n" + dataReader.GetString(14) + "\r\nББК: " + dataReader.GetString(15) + "\r\nУДК: " +
                    dataReader.GetString(16);
            }
            dataReader.Close();
            dataBase.CloseConnection();

            Form_ViewInfo formVI = new Form_ViewInfo();
            formVI.tbValue = str;
            formVI.Show();
        }
        private void ChangeInfoBook(int idMain)
        {
            Form_InfoBook formInfoBook = new Form_InfoBook();
            formInfoBook.Show();
            formInfoBook.setIdM(idMain);
            formInfoBook.getBtnChangeShow();
        }
        private void DeleteBook(int idMain)
        {
            if (idMain != 0)
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
                            $"WHERE mainTableBook_db.id = '{idMain}'";
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
                        int[] arrNums = { };
                        if (strNums != " ")
                            arrNums = strNums.Split('-').Select(int.Parse).ToArray();
                        //Удаление из главной таблицы, заглавия, полочного индекса
                        string queryDelBook =
                            $"DELETE FROM mainTableBook_db WHERE id = '{idMain}' " +
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
                        MessageBox.Show("Запись удалена!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }
        private void SearchBook(DataGridView dgvBook, RadioButton radBtn_aut, RadioButton radBtn_title, RadioButton radBtn_keyword, TextBox txtBox_search)
        {
            dgvBook.Rows.Clear();
            string query =
                $"SELECT * FROM" +
                $"(SELECT mainTableBook_db.id, authorBook_db.first_author, titleBook_db.title_text, " +
                $"titleBook_db.contin_title, publishingHouse_db.publ_house, publishingHouse_db.year_publ, mainTableBook_db.size " +
                $"FROM mainTableBook_db " +
                $"INNER JOIN authorBook_db ON mainTableBook_db.author = authorBook_db.author " +
                $"INNER JOIN publishingHouse_db ON mainTableBook_db.publishing_house = publishingHouse_db.publishing_house " +
                $"INNER JOIN titleBook_db ON mainTableBook_db.title = titleBook_db.title) a ";
            if (radBtn_aut.Checked)
            {
                string queryAuthor = query + $"WHERE a.first_author LIKE N'{txtBox_search.Text}%'";
                dataBase.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(queryAuthor, dataBase.getConnection());
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                    dgvBook.Rows.Add(Convert.ToString(dataReader.GetInt32(0)), dataReader.GetString(1), dataReader.GetString(2) + " " + dataReader.GetString(3), dataReader.GetString(4), Convert.ToString(dataReader.GetInt32(5)), dataReader.GetString(6));
                dataReader.Close();
                dataBase.CloseConnection();
            }
            else if (radBtn_title.Checked)
            {
                string queryTitle = query + $"WHERE a.title_text LIKE N'{txtBox_search.Text}%'";
                dataBase.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(queryTitle, dataBase.getConnection());
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dgvBook.Rows.Add(Convert.ToString(dataReader.GetInt32(0)), dataReader.GetString(1), dataReader.GetString(2) + " " + dataReader.GetString(3), dataReader.GetString(4), Convert.ToString(dataReader.GetInt32(5)), dataReader.GetString(6));
                }
                dataReader.Close();
                dataBase.CloseConnection();
            }
            else if (radBtn_keyword.Checked)
            {
                string queryWord =
                    $"DECLARE @result varchar(MAX) SELECT @result = keywords " +
                    $"FROM keywords_db " +
                    $"WHERE keywords_value = N'{txtBox_search.Text}' " +
                    $"SELECT id, first_author, title_text, contin_title, publ_house, year_publ, size " +
                    $"FROM (SELECT mainTableBook_db.id, authorBook_db.first_author, titleBook_db.title_text, titleBook_db.contin_title, publishingHouse_db.publ_house, publishingHouse_db.year_publ, mainTableBook_db.size, mainTableBook_db.keywords FROM mainTableBook_db INNER JOIN authorBook_db ON mainTableBook_db.author = authorBook_db.author INNER JOIN publishingHouse_db ON mainTableBook_db.publishing_house = publishingHouse_db.publishing_house INNER JOIN titleBook_db ON mainTableBook_db.title = titleBook_db.title) a " +
                    $"WHERE (a.keywords LIKE '%-'+ @result +'-%') OR (a.keywords LIKE @result + '-%') OR (a.keywords LIKE '%-'+ @result)";
                dataBase.OpenConnection();
                SqlCommand sqlCommand = new SqlCommand(queryWord, dataBase.getConnection());
                SqlDataReader dataReader = sqlCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    dgvBook.Rows.Add(Convert.ToString(dataReader.GetInt32(0)), dataReader.GetString(1), dataReader.GetString(2) + " " + dataReader.GetString(3), dataReader.GetString(4), Convert.ToString(dataReader.GetInt32(5)), dataReader.GetString(6));
                }
                dataReader.Close();
                dataBase.CloseConnection();
            }
            else { };
        }
        //методы для обращения из других классов
        //-----Вызов метода добавления издания
        public void getAddBook()
        {
            AddBook();
        }
        //-----Вызов метода формирования каталожной карточки
        public void getViewInfo(int idMain)
        {
            ViewInfo(idMain);
        }
        //-----Вызов метода исправления информации об издании
        public void getChangeInfoBook(int idMain)
        {
            ChangeInfoBook(idMain);
        }
        //-----Вызов метода удаления издания
        public void getDeleteBook(int idMain)
        {
            DeleteBook(idMain);
        }
        //-----Вызов метода поиска издания
        public void getSearchBook(DataGridView dgvBook, RadioButton radBtn_aut, RadioButton radBtn_title, RadioButton radBtn_keyword, TextBox txtBox_search)
        {
            SearchBook(dgvBook, radBtn_aut, radBtn_title, radBtn_keyword, txtBox_search);
        }
    }
}
