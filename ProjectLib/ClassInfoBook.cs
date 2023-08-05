using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using ProjectLib;

namespace ProjectLib
{
    class ClassInfoBook
    {
        DataBase dataBase = new DataBase();
        Regex patternPrice = new Regex(@"^[0-9]*[.]?[0-9]+$", RegexOptions.Compiled);
        public void getAddBook (DataGridView dgvTitle, DataGridView dgvPublishing, DataGridView dgvIndexShelf,
            DataGridView dgvMain, DataGridView dgvAuthor, DataGridView dgvAuthorMore, DataGridView dgvSubHeading,
            DataGridView dgvKeyWords, DataGridView dgvInvNum, Form_InfoBook formAddBook)
        {
            AddBook(dgvTitle, dgvPublishing, dgvIndexShelf,
            dgvMain, dgvAuthor, dgvAuthorMore, dgvSubHeading,
            dgvKeyWords, dgvInvNum, formAddBook);
        }
        public void getChangeInfoBook(DataGridView dgvTitle, DataGridView dgvPublishing, DataGridView dgvIndexShelf,
            DataGridView dgvMain, DataGridView dgvAuthor, DataGridView dgvAuthorMore, DataGridView dgvSubHeading,
            DataGridView dgvKeyWords, DataGridView dgvInvNum, int idMain, int idAuth, int idTitle, int idPubHouse,
            int idShelf, int[] arrIdMoreAuth, int[] arrIdSubjHead, int[] arrIdKeywords, int[] arrIdInvNum)
        {
            ChangeInfoBook(dgvTitle, dgvPublishing, dgvIndexShelf,
            dgvMain, dgvAuthor, dgvAuthorMore, dgvSubHeading,
            dgvKeyWords, dgvInvNum, idMain, idAuth, idTitle, idPubHouse, idShelf, arrIdMoreAuth, arrIdSubjHead,
            arrIdKeywords, arrIdInvNum);
        }
        private void delNullInDgv(DataGridView dgv, int colDgv)
        {
            for (int i = 0; i < dgv.Rows.Count; ++i)
            {
                if (dgv[colDgv, i].Value == null)
                    if (dgv[0, i].Value.ToString() != "Незн. симв. 0-9" ||
                        dgv[0, i].Value.ToString() != "Номер части" ||
                        dgv[0, i].Value.ToString() != "Год издания" ||
                        dgv[0, i].Value.ToString() != "Количество экземпляров" ||
                        dgv[0, i].Value.ToString() != "Цена 1 экз.")
                        dgv[colDgv, i].Value = " ";
            }
        }
        private void AddBook(DataGridView dgvTitle, DataGridView dgvPublishing, DataGridView dgvIndexShelf,
            DataGridView dgvMain, DataGridView dgvAuthor, DataGridView dgvAuthorMore, DataGridView dgvSubHeading,
            DataGridView dgvKeyWords, DataGridView dgvInvNum, Form_InfoBook formAddBook)
        {
            //Проверка ввода числовых данных
            delNullInDgv(dgvMain, 1);
            delNullInDgv(dgvAuthor, 1);
            delNullInDgv(dgvTitle, 1);
            delNullInDgv(dgvPublishing, 1);
            delNullInDgv(dgvIndexShelf, 1);
            delNullInDgv(dgvAuthorMore, 1);
            delNullInDgv(dgvSubHeading, 1);
            if (int.TryParse(dgvTitle[1, 0].Value.ToString(), out int simv) != true)
                MessageBox.Show("Укажите количество незначимых символов в заглавии");
            else if (int.TryParse(dgvTitle[1, 2].Value.ToString(), out int part) != true)
                MessageBox.Show("Укажите номер части или укажите значение 0");
            else if (int.TryParse(dgvPublishing[1, 2].Value.ToString(), out int yearpub) != true)
                MessageBox.Show("Укажите год издания");
            else if (int.TryParse(dgvIndexShelf[1, 6].Value.ToString(), out int numcop) != true)
                MessageBox.Show("Укажите количество экземпляров или укажите значение 0");
            else
            if (dgvIndexShelf[1, 10].Value == null)
                MessageBox.Show("Укажите цену 1 экземпляра или укажите значение 0");
            else if (patternPrice.IsMatch(dgvIndexShelf[1, 10].Value.ToString()) != true)
                MessageBox.Show("Укажите цену 1 экземпляра или укажите значение 0");
            else
            {
                //-----Ключевые слова
                string bookWords = " ";
                if (dgvKeyWords.Rows.Count > 1)
                {
                    bookWords = "";
                    for (int i = 0; i < dgvKeyWords.Rows.Count - 1; i++)
                    {
                        if (dgvKeyWords[0, i].Value != null)
                        {
                            //Проверка на наличие слова
                            if (checkWord(dgvKeyWords[0, i].Value.ToString()) != 0)
                            {
                                bookWords += checkWord(dgvKeyWords[0, i].Value.ToString()).ToString() + "-";
                            }
                            else
                            {
                                //Добавление нового слова
                                string queryAdd_Words = $"INSERT INTO keywords_db (keywords_value) VALUES (N'{dgvKeyWords[0, i].Value.ToString()}')";
                                dataBase.OpenConnection();
                                SqlCommand sqlCommand1 = new SqlCommand(queryAdd_Words, dataBase.getConnection());
                                sqlCommand1.ExecuteNonQuery();
                                dataBase.CloseConnection();
                                //Взятие индекса добавленного слова
                                string queryLastWord = "SELECT MAX(keywords) FROM keywords_db";
                                dataBase.OpenConnection();
                                SqlCommand sqlCom_lastWord = new SqlCommand(queryLastWord, dataBase.getConnection());
                                sqlCom_lastWord.ExecuteNonQuery();
                                bookWords += sqlCom_lastWord.ExecuteScalar().ToString() + "-";
                                dataBase.CloseConnection();
                            }
                        }
                    }
                    if (bookWords != " ")
                        bookWords = bookWords.Remove(bookWords.Length - 1); //Значение для поля ключевых слов
                        
                    //MessageBox.Show(bookWords);
                }

                //-----Доп авторы
                string bookDopAuthor = "";
                for (int i = 0; i < dgvAuthorMore.Rows.Count; i += 2)
                {
                    if (checkDopAuthor(dgvAuthorMore[1, i].Value.ToString(), dgvAuthorMore[1, i + 1].Value.ToString()) != 0)
                    {
                        bookDopAuthor += checkDopAuthor(dgvAuthorMore[1, i].Value.ToString(),
                            dgvAuthorMore[1, i + 1].Value.ToString()) + "-";

                    }
                    else
                    {
                        //Добавление доп автора
                        string qeuryAdd_DopAuthor = $"INSERT INTO rolesPersons_db (other_auth, role) " +
                            $"VALUES (N'{dgvAuthorMore[1, i].Value.ToString()}', N'{dgvAuthorMore[1, i + 1].Value.ToString()}')";
                        dataBase.OpenConnection();
                        SqlCommand sql_SH_ins = new SqlCommand(qeuryAdd_DopAuthor, dataBase.getConnection());
                        sql_SH_ins.ExecuteNonQuery();
                        dataBase.CloseConnection();
                        //Взятие индекса добавленного доп автора
                        string queryLastDopAuthor = $"SELECT MAX(roles_persons) FROM rolesPersons_db";
                        dataBase.OpenConnection();
                        SqlCommand sqlLast_DA = new SqlCommand(queryLastDopAuthor, dataBase.getConnection());
                        sqlLast_DA.ExecuteNonQuery();
                        bookDopAuthor += sqlLast_DA.ExecuteScalar().ToString() + "-";
                        dataBase.CloseConnection();
                    }
                }
                bookDopAuthor = bookDopAuthor.Remove(bookDopAuthor.Length - 1); //Значение для поля Роль лиц
                //MessageBox.Show(bookDopAuthor);

                //-----Первый автор
                int bookAuthor = 0;
                if (checkAuthor(dgvAuthor[1, 0].Value.ToString(), dgvAuthor[1, 1].Value.ToString(),
                    dgvAuthor[1, 2].Value.ToString(), bookDopAuthor) != 0)
                {
                    bookAuthor = checkAuthor(dgvAuthor[1, 0].Value.ToString(), dgvAuthor[1, 1].Value.ToString(),
                    dgvAuthor[1, 2].Value.ToString(), bookDopAuthor);
                }
                else
                {
                    //Добавление автора
                    string queryAdd_Author = $"INSERT INTO authorBook_db (first_author, dinast_num, titul, roles_persons) " +
                        $"VALUES (N'{dgvAuthor[1, 0].Value.ToString()}', N'{dgvAuthor[1, 1].Value.ToString()}', N'{dgvAuthor[1, 2].Value.ToString()}', '{bookDopAuthor}')";
                    dataBase.OpenConnection();
                    SqlCommand sqlComAuthor = new SqlCommand(queryAdd_Author, dataBase.getConnection());
                    sqlComAuthor.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    //Взятие индекса добавленного автора
                    string querySelect_Author = $"SELECT MAX(author) FROM authorBook_db";
                    dataBase.OpenConnection();
                    SqlCommand sqlLastA = new SqlCommand(querySelect_Author, dataBase.getConnection());
                    sqlLastA.ExecuteNonQuery();
                    bookAuthor = int.Parse(sqlLastA.ExecuteScalar().ToString());
                    dataBase.CloseConnection();
                }
                //MessageBox.Show(bookAuthor.ToString());

                //-----Издательство
                int bookPubHouse = 0;
                if (checkPubHouse(dgvPublishing[1, 0].Value.ToString(), dgvPublishing[1, 1].Value.ToString(),
                    dgvPublishing[1, 2].Value.ToString()) != 0)
                {
                    bookPubHouse = checkPubHouse(dgvPublishing[1, 0].Value.ToString(), dgvPublishing[1, 1].Value.ToString(),
                    dgvPublishing[1, 2].Value.ToString());
                }
                else
                {
                    //Добавление издательства
                    string queryAdd_pubHouse = $"INSERT INTO publishingHouse_db (place_publ, publ_house, year_publ)" +
                        $"VALUES (N'{dgvPublishing[1, 0].Value.ToString()}', N'{dgvPublishing[1, 1].Value.ToString()}', {int.Parse(dgvPublishing[1, 2].Value.ToString())})";
                    dataBase.OpenConnection();
                    SqlCommand sqlpubHouse = new SqlCommand(queryAdd_pubHouse, dataBase.getConnection());
                    sqlpubHouse.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    //Взятие индекса добавленного издания
                    string querySelect_pubHouse = $"SELECT MAX(publishing_house) FROM publishingHouse_db";
                    dataBase.OpenConnection();
                    SqlCommand sqlLastPH = new SqlCommand(querySelect_pubHouse, dataBase.getConnection());
                    sqlLastPH.ExecuteNonQuery();
                    bookPubHouse = int.Parse(sqlLastPH.ExecuteScalar().ToString());
                    dataBase.CloseConnection();
                }
                //MessageBox.Show(bookPubHouse.ToString());

                //-----Тематическая рубрика
                string bookSubjHeading = "";
                for (int i = 0; i < dgvSubHeading.Rows.Count; i += 4)
                {
                    if (checkSubHead(dgvSubHeading[1, i].Value.ToString(), dgvSubHeading[1, i + 1].Value.ToString(),
                        dgvSubHeading[1, i + 2].Value.ToString(), dgvSubHeading[1, i + 3].Value.ToString()) != 0)
                    {
                        bookSubjHeading += checkSubHead(dgvSubHeading[1, i].Value.ToString(), dgvSubHeading[1, i + 1].Value.ToString(),
                        dgvSubHeading[1, i + 2].Value.ToString(), dgvSubHeading[1, i + 3].Value.ToString()) + "-";
                    }
                    else
                    {
                        //Добавление тематической рубрики
                        string queryAdd_subjHeading = $"INSERT INTO subjectHeading_db (heading, subheading, hron_subheading, geo_subheading)" +
                            $"VALUES (N'{dgvSubHeading[1, i].Value.ToString()}', N'{dgvSubHeading[1, i + 1].Value.ToString()}', " +
                            $"N'{dgvSubHeading[1, i + 2].Value.ToString()}', N'{dgvSubHeading[1, i + 3].Value.ToString()}')";
                        dataBase.OpenConnection();
                        SqlCommand sqlsubjHeading = new SqlCommand(queryAdd_subjHeading, dataBase.getConnection());
                        sqlsubjHeading.ExecuteNonQuery();
                        dataBase.CloseConnection();
                        //Взятие индекса добавленной рубрики
                        string querySelect_subjHeading = $"SELECT MAX(subject_heading) FROM subjectHeading_db";
                        dataBase.OpenConnection();
                        SqlCommand sqlLastSH = new SqlCommand(querySelect_subjHeading, dataBase.getConnection());
                        sqlLastSH.ExecuteNonQuery();
                        bookSubjHeading += sqlLastSH.ExecuteScalar().ToString() + "-";
                        dataBase.CloseConnection();
                    }

                }
                bookSubjHeading = bookSubjHeading.Remove(bookSubjHeading.Length - 1); //Значение для поля Тематическиой рубрики
                //MessageBox.Show(bookSubjHeading);

                //-----Заглавие
                int bookTitle = 0;
                //Добавление заглавия
                string queryAdd_titleBook = $"INSERT INTO titleBook_db (nezn_simv, title_text, num_part, name_part, contin_title, responsibility) " +
                    $"VALUES ('{int.Parse(dgvTitle[1, 0].Value.ToString())}', N'{dgvTitle[1, 1].Value.ToString()}', '{int.Parse(dgvTitle[1, 2].Value.ToString())}', " +
                    $"N'{dgvTitle[1, 3].Value.ToString()}', N'{dgvTitle[1, 4].Value.ToString()}', N'{dgvTitle[1, 5].Value.ToString()}')";
                dataBase.OpenConnection();
                SqlCommand sqltitleBook = new SqlCommand(queryAdd_titleBook, dataBase.getConnection());
                sqltitleBook.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Взятие индекса добавленного заглавия
                string querySelect_titleBook = $"SELECT MAX(title) FROM titleBook_db";
                dataBase.OpenConnection();
                SqlCommand sqlLastT = new SqlCommand(querySelect_titleBook, dataBase.getConnection());
                sqlLastT.ExecuteNonQuery();
                bookTitle = int.Parse(sqlLastT.ExecuteScalar().ToString()); //Значение для поля заглавие
                dataBase.CloseConnection();
                //MessageBox.Show(bookTitle.ToString());
                //-----Инвентарные номера
                string bookInvNum = " ";
                //Добавление инвентарного номера
                if (dgvInvNum.Rows.Count > 0)
                {
                    bookInvNum = "";
                    for (int i = 0; i < dgvInvNum.Rows.Count; i++)
                    {
                        if (dgvInvNum[0, i].Value != null)
                        {
                            //Добавление инвентарного номера
                            string queryAdd_InvNum = $"INSERT INTO invNum_db (inv_val) VALUES (N'{dgvInvNum[0, i].Value.ToString()}')";
                            dataBase.OpenConnection();
                            SqlCommand sqlInvNum = new SqlCommand(queryAdd_InvNum, dataBase.getConnection());
                            sqlInvNum.ExecuteNonQuery();
                            dataBase.CloseConnection();
                            //Взятие индекса добавленного инвентарного номера
                            string querySelect_InvNum = $"SELECT MAX(inv_num) FROM invNum_db";
                            dataBase.OpenConnection();
                            SqlCommand sqlLastIN = new SqlCommand(querySelect_InvNum, dataBase.getConnection());
                            sqlLastIN.ExecuteNonQuery();
                            bookInvNum += sqlLastIN.ExecuteScalar().ToString() + "-";
                            dataBase.CloseConnection();
                        }
                    }
                    if (bookWords != " ")
                        bookInvNum = bookInvNum.Remove(bookInvNum.Length - 1); //Значение для поля инвентарный номер                        
                }
                //MessageBox.Show(bookInvNum);

                //-----Полочный индекс
                int bookIndShelf = 0;
                //Добавление полочного индекса            
                string queryAdd_shInd = $"INSERT INTO indexShelf_db (index_shelf, copyright_sign, sigla, registration, type, " +
                    $"publ_type, num_copies, num1, num2, inv_num, reg_num, price) VALUES " +
                    $"(N'{dgvIndexShelf[1, 0].Value.ToString()}', N'{dgvIndexShelf[1, 1].Value.ToString()}', N'{dgvIndexShelf[1, 2].Value.ToString()}', " +
                    $"N'{dgvIndexShelf[1, 3].Value.ToString()}', N'{dgvIndexShelf[1, 4].Value.ToString()}', N'{dgvIndexShelf[1, 5].Value.ToString()}', " +
                    $"'{int.Parse(dgvIndexShelf[1, 6].Value.ToString())}', N'{dgvIndexShelf[1, 7].Value.ToString()}', N'{dgvIndexShelf[1, 8].Value.ToString()}', " +
                    $"'{bookInvNum}', N'{dgvIndexShelf[1, 9].Value.ToString()}', '{dgvIndexShelf[1, 10].Value.ToString()}')";
                dataBase.OpenConnection();
                SqlCommand sqlshInd = new SqlCommand(queryAdd_shInd, dataBase.getConnection());
                sqlshInd.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Взятие индекса добавленного полочного индекса
                dataBase.OpenConnection();
                string querySelect_shInd = "SELECT MAX(id_indShelf) FROM indexShelf_db";
                SqlCommand sqlLastSI = new SqlCommand(querySelect_shInd, dataBase.getConnection());
                sqlLastSI.ExecuteNonQuery();
                bookIndShelf = int.Parse(sqlLastSI.ExecuteScalar().ToString());
                dataBase.CloseConnection();
                //int bookAuthor = 0, bookTitle = 0, bookPubHouse = 0, bookIndShelf = 0;
                //string bookSubjHeading = " ", bookWords = " ";
                //-----Основная таблица
                string queryAdd_Main = $"INSERT INTO mainTableBook_db(cn, special_purpose, author, title, " +
                    $"subject_heading, keywords, publishing_house, edition_info, remarks, " +
                    $"catalog_ind, size, index_bbk, index_udk, index_shelf, isbn, url, " +
                    $"code_land, name_org, creator_code, record_date) " +
                    $"VALUES (N'{dgvMain[1, 0].Value.ToString()}', N'{dgvMain[1, 1].Value.ToString()}', " +
                    $"'{bookAuthor}', '{bookTitle}', '{bookSubjHeading}', " +
                    $"'{bookWords}', '{bookPubHouse}', N'{dgvMain[1, 2].Value.ToString()}', " +
                    $"N'{dgvMain[1, 3].Value.ToString()}', N'{dgvMain[1, 4].Value.ToString()}', N'{dgvMain[1, 5].Value.ToString()}', " +
                    $"N'{dgvMain[1, 6].Value.ToString()}', N'{dgvMain[1, 7].Value.ToString()}', " +
                    $"'{bookIndShelf}', N'{dgvMain[1, 8].Value.ToString()}', N'{dgvMain[1, 9].Value.ToString()}', " +
                    $"N'{dgvMain[1, 10].Value.ToString()}', N'{dgvMain[1, 11].Value.ToString()}', " +
                    $"N'{dgvMain[1, 12].Value.ToString()}', '{dgvMain[1, 13].Value.ToString()}')";
                dataBase.OpenConnection();
                SqlCommand sqlCom = new SqlCommand(queryAdd_Main, dataBase.getConnection());
                if (sqlCom.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Издание добавлено!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formAddBook.Close();
                }
                else
                    MessageBox.Show("Ошибка при добавлении издания!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataBase.CloseConnection();
            }
        }
        private void ChangeInfoBook(DataGridView dgvTitle, DataGridView dgvPublishing, DataGridView dgvIndexShelf,
            DataGridView dgvMain, DataGridView dgvAuthor, DataGridView dgvAuthorMore, DataGridView dgvSubHeading,
            DataGridView dgvKeyWords, DataGridView dgvInvNum, int idMain, int idAuth, int idTitle, int idPubHouse, 
            int idShelf, int[] arrIdMoreAuth, int[] arrIdSubjHead, int[] arrIdKeywords, int[] arrIdInvNum)
        {
            //Проверка ввода числовых данных
            if (int.TryParse(dgvTitle[1, 0].Value.ToString(), out int simv) != true)
                MessageBox.Show("Укажите количество незначимых символов в заглавии");
            else if (int.TryParse(dgvTitle[1, 2].Value.ToString(), out int part) != true)
                MessageBox.Show("Укажите номер части или укажите значение 0");
            else if (int.TryParse(dgvPublishing[1, 2].Value.ToString(), out int yearpub) != true)
                MessageBox.Show("Укажите год издания");
            else if (int.TryParse(dgvIndexShelf[1, 6].Value.ToString(), out int numcop) != true)
                MessageBox.Show("Укажите количество экземпляров или укажите значение 0");
            else
            if (dgvIndexShelf[1, 10].Value == null)
                MessageBox.Show("Укажите цену 1 экземпляра или укажите значение 0");
            else if (patternPrice.IsMatch(dgvIndexShelf[1, 10].Value.ToString()) != true)
                MessageBox.Show("Укажите цену 1 экземпляра или укажите значение 0");
            else
            {
                delNullInDgv(dgvMain, 1);
                delNullInDgv(dgvAuthor, 1);
                delNullInDgv(dgvTitle, 1);
                delNullInDgv(dgvPublishing, 1);
                delNullInDgv(dgvIndexShelf, 1);
                delNullInDgv(dgvAuthorMore, 1);
                delNullInDgv(dgvSubHeading, 1);
                delNullInDgv(dgvKeyWords, 0);
                delNullInDgv(dgvInvNum, 0);

                //Обновление главной таблицы
                string queryUpdMain = $"UPDATE mainTableBook_db " +
                $"SET cn = N'{dgvMain[1, 0].Value.ToString()}', special_purpose = N'{dgvMain[1, 1].Value.ToString()}', " +
                $"edition_info = N'{dgvMain[1, 2].Value.ToString()}', remarks = N'{dgvMain[1, 3].Value.ToString()}', " +
                $"catalog_ind = N'{dgvMain[1, 4].Value.ToString()}', size = N'{dgvMain[1, 5].Value.ToString()}', " +
                $"index_bbk = N'{dgvMain[1, 6].Value.ToString()}', index_udk = N'{dgvMain[1, 7].Value.ToString()}', " +
                $"isbn = N'{dgvMain[1, 8].Value.ToString()}', url = N'{dgvMain[1, 9].Value.ToString()}', " +
                $"code_land = N'{dgvMain[1, 10].Value.ToString()}', name_org = N'{dgvMain[1, 11].Value.ToString()}', " +
                $"creator_code = N'{dgvMain[1, 12].Value.ToString()}'" +
                $"WHERE id = '{idMain}'";
                dataBase.OpenConnection();
                SqlCommand sqlComMain = new SqlCommand(queryUpdMain, dataBase.getConnection());
                sqlComMain.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Обновление таблицы Заглавие
                string queryUpdTitle = $"UPDATE titleBook_db " +
                $"SET nezn_simv = N'{int.Parse(dgvTitle[1, 0].Value.ToString())}', title_text = N'{dgvTitle[1, 1].Value.ToString()}', " +
                $"num_part = N'{int.Parse(dgvTitle[1, 2].Value.ToString())}', name_part = N'{dgvTitle[1, 3].Value.ToString()}', " +
                $"contin_title = N'{dgvTitle[1, 4].Value.ToString()}', responsibility = N'{dgvTitle[1, 5].Value.ToString()}' " +
                $"WHERE title = '{idTitle}'";
                dataBase.OpenConnection();
                SqlCommand sqlComUpdTitle = new SqlCommand(queryUpdTitle, dataBase.getConnection());
                sqlComUpdTitle.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Обновление таблицы Издательство
                string queryUpdPubHouse = $"UPDATE publishingHouse_db " +
                $"SET place_publ = N'{dgvPublishing[1, 0].Value.ToString()}', publ_house = N'{dgvPublishing[1, 1].Value.ToString()}', " +
                $"year_publ = N'{int.Parse(dgvPublishing[1, 2].Value.ToString())}' " +                
                $"WHERE publishing_house = '{idPubHouse}'";
                dataBase.OpenConnection();
                SqlCommand sqlComPubHouse = new SqlCommand(queryUpdPubHouse, dataBase.getConnection());
                sqlComPubHouse.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Обновление таблицы Полочный индекс
                string queryUpdShelf = $"UPDATE indexShelf_db " +
                $"SET index_shelf = N'{dgvIndexShelf[1, 0].Value.ToString()}', copyright_sign = N'{dgvIndexShelf[1, 1].Value.ToString()}', " +
                $"sigla = N'{dgvIndexShelf[1, 2].Value.ToString()}', registration = N'{dgvIndexShelf[1, 3].Value.ToString()}', " +
                $"type = N'{dgvIndexShelf[1, 4].Value.ToString()}', publ_type = N'{dgvIndexShelf[1, 5].Value.ToString()}', " +
                $"num_copies = N'{int.Parse(dgvIndexShelf[1, 6].Value.ToString())}', num1 = N'{dgvIndexShelf[1, 7].Value.ToString()}', " +
                $"num2 = N'{dgvIndexShelf[1, 8].Value.ToString()}', " +
                $"reg_num = N'{dgvIndexShelf[1, 9].Value.ToString()}', price = '{dgvIndexShelf[1, 10].Value.ToString()}' " +
                $"WHERE id_indShelf = '{idShelf}'";
                dataBase.OpenConnection();
                SqlCommand sqlComShelf = new SqlCommand(queryUpdShelf, dataBase.getConnection());
                sqlComShelf.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Обновление таблицы Автор
                string queryUpdAuthor = $"UPDATE authorBook_db " +
                $"SET first_author = N'{dgvAuthor[1, 0].Value.ToString()}', dinast_num = N'{dgvAuthor[1, 1].Value.ToString()}', " +
                $"titul = N'{dgvAuthor[1, 2].Value.ToString()}' " +
                $"WHERE author = '{idAuth}'";
                dataBase.OpenConnection();
                SqlCommand sqlComAuthor = new SqlCommand(queryUpdAuthor, dataBase.getConnection());
                sqlComAuthor.ExecuteNonQuery();
                dataBase.CloseConnection();
                //Обновление таблицы Дополнительные авторы
                int j = 0;
                for (int i = 0; i < arrIdMoreAuth.Length; ++i)
                {
                    string queryUpdMoreAuth = $"UPDATE rolesPersons_db " +
                    $"SET other_auth = N'{dgvAuthorMore[1, j].Value.ToString()}', role = N'{dgvAuthorMore[1, j+1].Value.ToString()}' " +
                    $"WHERE roles_persons = '{arrIdMoreAuth[i]}'";
                    dataBase.OpenConnection();
                    SqlCommand sqlComMoreAuth = new SqlCommand(queryUpdMoreAuth, dataBase.getConnection());
                    sqlComMoreAuth.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    j += 2;
                }
                //Обновление таблицы Ключевые слова
                if (dgvInvNum.Rows.Count > 0)
                    for (int i = 0; i < arrIdKeywords.Length; ++i)
                    {
                        string queryUpdKeywords = $"UPDATE keywords_db " +
                        $"SET keywords_value = N'{dgvKeyWords[0, i].Value.ToString()}' " +
                        $"WHERE keywords = '{arrIdKeywords[i]}'";
                        dataBase.OpenConnection();
                        SqlCommand sqlComKeywords = new SqlCommand(queryUpdKeywords, dataBase.getConnection());
                        sqlComKeywords.ExecuteNonQuery();
                        dataBase.CloseConnection();
                    }
                //Обновление таблицы Инвентарные номера
                if (dgvInvNum.Rows.Count > 0)
                    for (int i = 0; i < arrIdInvNum.Length; ++i)
                    {
                        string queryUpdInvNum = $"UPDATE invNum_db " +
                        $"SET inv_val = N'{dgvInvNum[0, i].Value.ToString()}' " +
                        $"WHERE inv_num = '{arrIdInvNum[i]}'";
                        dataBase.OpenConnection();
                        SqlCommand sqlComInvNum = new SqlCommand(queryUpdInvNum, dataBase.getConnection());
                        sqlComInvNum.ExecuteNonQuery();
                        dataBase.CloseConnection();
                    }
                //Обновление таблицы Тематическая рубрика
                j = 0;
                for (int i = 0; i < arrIdSubjHead.Length; ++i)
                {
                    string queryUpdSubjHead = $"UPDATE subjectHeading_db " +
                    $"SET heading = N'{dgvSubHeading[1, j].Value.ToString()}', subheading = N'{dgvSubHeading[1, j + 1].Value.ToString()}', " +
                    $"hron_subheading = N'{dgvSubHeading[1, j + 2].Value.ToString()}', geo_subheading = N'{dgvSubHeading[1, j + 3].Value.ToString()}' " +
                    $"WHERE subject_heading = '{arrIdSubjHead[i]}'";
                    dataBase.OpenConnection();
                    SqlCommand sqlComSubjHead = new SqlCommand(queryUpdSubjHead, dataBase.getConnection());
                    sqlComSubjHead.ExecuteNonQuery();
                    dataBase.CloseConnection();
                    j += 4;
                }

                MessageBox.Show("Информация обновлена!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Проверка наличия ключевого слова
        private int checkWord(string value_)
        {
            string queryCheck = $"SELECT keywords FROM keywords_db WHERE keywords_value = N'{value_}'";
            return checkData(queryCheck);
        }
        //Проверка наличия доп автора
        private int checkDopAuthor(string value1, string value2)
        {
            string queryCheck = $"SELECT roles_persons FROM rolesPersons_db " +
                $"WHERE other_auth = N'{value1}' AND role = N'{value2}'";
            return checkData(queryCheck);
        }
        //Проверка наличия первого автора
        private int checkAuthor(string value1, string value2, string value3, string value4)
        {
            string queryCheck = $"SELECT author FROM authorBook_db " +
                $"WHERE first_author = N'{value1}' AND dinast_num = N'{value2}' AND titul = N'{value3}' AND roles_persons = N'{value4}'";
            return checkData(queryCheck);
        }
        //Проверка наличия издательства
        private int checkPubHouse(string value1, string value2, string value3)
        {
            string queryCheck = $"SELECT publishing_house FROM publishingHouse_db " +
                $"WHERE place_publ = N'{value1}' AND publ_house = N'{value2}' AND year_publ = {int.Parse(value3)}";
            return checkData(queryCheck);
        }
        //Проверка наличия тематической рубрики
        private int checkSubHead(string value1, string value2, string value3, string value4)
        {
            string queryCheck = $"SELECT subject_heading FROM subjectHeading_db " +
                $"WHERE heading = N'{value1}' AND subheading = N'{value2}' AND " +
                $"hron_subheading = N'{value3}' AND geo_subheading = N'{value4}'";
            return checkData(queryCheck);
        }
        //Выполнение запроса проверки на наличие
        private int checkData(string query)
        {
            int id_ = 0;
            dataBase.OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(query, dataBase.getConnection());
            sqlCommand.ExecuteNonQuery();
            if (sqlCommand.ExecuteScalar() != null)
            {
                id_ = int.Parse(sqlCommand.ExecuteScalar().ToString());
                dataBase.CloseConnection();
                return id_;
            }
            else
            {
                dataBase.CloseConnection();
                return 0;
            }
        }
    }
}
