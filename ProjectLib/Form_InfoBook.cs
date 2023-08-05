using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ProjectLib
{
    public partial class Form_InfoBook : Form
    {
        private int idMain;
        public void setIdM (int _id)
        {
            idMain = _id; 
        }
        DataBase dataBase = new DataBase();
        ClassInfoBook classInfoBook = new ClassInfoBook();
        int idAuth = 0, idTitle = 0, idPubHouse = 0, idShelf = 0;
        private string idSubjHead = "", idKeywords = "", idMoreAuth = "", idInvNum = "";
        private int[] arrIdMoreAuth, arrIdSubjHead, arrIdKeywords, arrIdInvNum;
        
        public Form_InfoBook()
        {
            InitializeComponent();
        }
        
        private void styleDgv(DataGridView dgv)
        {
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].ReadOnly = false;
            dgv.Columns[0].Width = 205;
            dgv.Columns[1].Width = 180;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[0].DefaultCellStyle.BackColor = Color.LightGray;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void styleDgv2(DataGridView dgv)
        {
            dgv.Columns[0].ReadOnly = false;
            dgv.Columns[0].Width = 190;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.RowHeadersVisible = false;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        private void createDgvMain()
        {
            dgvMain.Columns.Add("field","Поле");
            dgvMain.Columns.Add("value", "Значение");
            dgvMain.Rows.Add("Идент-ный номер", " ");
            dgvMain.Rows.Add("Целевое назначение", " ");
            dgvMain.Rows.Add("Сведения об издан.", " ");
            dgvMain.Rows.Add("Примечания", " ");
            dgvMain.Rows.Add("Каталожные инд.", " ");
            dgvMain.Rows.Add("Объем", " ");
            dgvMain.Rows.Add("Индекс ББК", " ");
            dgvMain.Rows.Add("Индекс УДК", " ");
            dgvMain.Rows.Add("ISBN", " ");
            dgvMain.Rows.Add("URL", " ");
            dgvMain.Rows.Add("Код языка", " ");
            dgvMain.Rows.Add("Название организации", " ");
            dgvMain.Rows.Add("Код создателя", " ");            
            dgvMain.Rows.Add("Дата записи", " ");
            dgvMain[1,13].Style.BackColor = Color.LightGray;
            styleDgv(dgvMain);
        }
        private void createDgvAuthor()
        {
            dgvAuthor.Columns.Add("field", "Поле");
            dgvAuthor.Columns.Add("value", "Значение");
            dgvAuthor.Rows.Add("Первый автор ФИО", " ");
            dgvAuthor.Rows.Add("Династ. номер", " ");
            dgvAuthor.Rows.Add("Титул (зван.)", " ");
            styleDgv(dgvAuthor);
        }
        private void createDgvTitle()
        {
            dgvTitle.Columns.Add("field", "Поле");
            dgvTitle.Columns.Add("value", "Значение");
            dgvTitle.Rows.Add("Незн. симв. 0-9", " ");
            dgvTitle.Rows.Add("Заглавие", " ");
            dgvTitle.Rows.Add("Номер части", " ");
            dgvTitle.Rows.Add("Название части", " ");
            dgvTitle.Rows.Add("Продолж. загл.", " ");
            dgvTitle.Rows.Add("Ответственность", " ");
            styleDgv(dgvTitle);
        }        
        private void createDgvAuthorMore()
        {
            dgvAuthorMore.Columns.Add("field", "Поле");
            dgvAuthorMore.Columns.Add("value", "Значение");
            dgvAuthorMore.Rows.Add("Другие авт. ФИО", " ");
            dgvAuthorMore.Rows.Add("Роль лиц", " ");
            styleDgv(dgvAuthorMore);
        }
        private void createDgvIndexShelf()
        {
            dgvIndexShelf.Columns.Add("field", "Поле");
            dgvIndexShelf.Columns.Add("value", "Значение");
            dgvIndexShelf.Rows.Add("Полочный индекс", " ");
            dgvIndexShelf.Rows.Add("Авторский знак", " ");
            dgvIndexShelf.Rows.Add("Сигла хранения", " ");
            dgvIndexShelf.Rows.Add("Принятие на учет", " ");
            dgvIndexShelf.Rows.Add("Тип лит-ры", " ");
            dgvIndexShelf.Rows.Add("Вид издания", " ");
            dgvIndexShelf.Rows.Add("Количество экз.", " ");
            dgvIndexShelf.Rows.Add("Номер мн.экз.изд.", " ");
            dgvIndexShelf.Rows.Add("Номер изд. ЮУрГУ", " ");
            dgvIndexShelf.Rows.Add("Рег.N собст.изд.", " ");
            dgvIndexShelf.Rows.Add("Цена 1 экз.", " ");
            styleDgv(dgvIndexShelf);
        }
        private void dgvIndexShelf_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIndexShelf[1, 6].Value != null && idMain == 0)
            {
                dgvInvNum.Rows.Clear();
                dgvInvNum.Refresh();
                try
                {
                    int k = int.Parse(dgvIndexShelf[1, 6].Value.ToString());
                    for (int i = 0; i < k; ++i)
                    {
                        dgvInvNum.Rows.Add("");
                    }
                }
                catch
                {
                    MessageBox.Show("В таблице Полочный индекс у поля Количество экземпляров\nневерное значение!\nИспользуйте числовое значение или повторите попытку.", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void createDgvPublishing()
        {
            dgvPublishing.Columns.Add("field", "Поле");
            dgvPublishing.Columns.Add("value", "Значение");
            dgvPublishing.Rows.Add("Место издания", " ");
            dgvPublishing.Rows.Add("Издательство", " ");
            dgvPublishing.Rows.Add("Год издания", " ");
            styleDgv(dgvPublishing);
        }
        private void createDgvSubHeading()
        {
            dgvSubHeading.Columns.Add("field", "Поле");
            dgvSubHeading.Columns.Add("value", "Значение");
            dgvSubHeading.Rows.Add("Тематич. рубрика", " ");
            dgvSubHeading.Rows.Add("Подрубрика", " ");
            dgvSubHeading.Rows.Add("Хрон. подруб.", " ");
            dgvSubHeading.Rows.Add("Гео. подруб.", " ");
            styleDgv(dgvSubHeading);
        }
        private void createDgvWordDgvInvNum()
        {
            dgvKeyWords.Columns.Add("value", "Ключевые слова");
            dgvInvNum.Columns.Add("value", "Инвент. номер");
            styleDgv2(dgvKeyWords);
            styleDgv2(dgvInvNum);
        }
        private void Form_AddBook_Load(object sender, EventArgs e)
        {
            createDgvMain();
            createDgvAuthor();
            createDgvTitle();
            createDgvAuthorMore();
            createDgvIndexShelf();
            createDgvPublishing();
            createDgvSubHeading();
            createDgvWordDgvInvNum();
        }
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        private void btnAddRowAuth_Click(object sender, EventArgs e)
        {
            dgvAuthorMore.Rows.Add("Другие авт. ФИО", " ");
            dgvAuthorMore.Rows.Add("Роль лиц", " ");
        }
        private void btnDelRowAuth_Click(object sender, EventArgs e)
        {
            if (dgvAuthorMore.Rows.Count > 2)
                for (int i = 0; i < 2; i++)
                    dgvAuthorMore.Rows.RemoveAt(dgvAuthorMore.Rows.Count - 1);
        }
        private void btnAddRowHeading_Click(object sender, EventArgs e)
        {
            dgvSubHeading.Rows.Add("Тематич. рубрика", " ");
            dgvSubHeading.Rows.Add("Подрубрика", " ");
            dgvSubHeading.Rows.Add("Хрон. подруб.", " ");
            dgvSubHeading.Rows.Add("Гео. подруб.", " ");
        }
        private void btnDelRowHeading_Click(object sender, EventArgs e)
        {
            if (dgvSubHeading.Rows.Count > 4)
                for (int i = 0; i < 4; i++)
                    dgvSubHeading.Rows.RemoveAt(dgvSubHeading.Rows.Count - 1);
        }
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        private void btn_addShow()
        {
            btnAdd.Visible = true;
            btnChange.Visible = false;
            dgvMain[1, 13].ReadOnly = true;
            dgvIndexShelf[1,6].ReadOnly = false;
            btnAddRowAuth.Visible = true;
            btnDelRowAuth.Visible = true;
            btnAddRowHeading.Visible = true;
            btnDelRowHeading.Visible = true;
            dgvMain[1, 0].Value = "200312N00001";
            dgvMain[1, 1].Value = "пр";
            dgvMain[1, 11].Value = "Библиотека филиала ФГАОУ ВО \"ЮУрГУ (НИУ)\" в г. Златоуст";
            dgvMain[1, 12].Value = "0";
            dgvMain[1, 13].Value = "2023-06-09";//DateTime.Now.ToString("yyyy-MM-dd");
            dgvTitle[1, 0].Value = "0";
            dgvTitle[1, 2].Value = "0";
            dgvIndexShelf[1, 2].Value = "Злат., отд. 1";
            dgvIndexShelf[1, 5].Value = "Книги";
            dgvIndexShelf[1, 6].Value = "0";
            dgvIndexShelf[1, 10].Value = "0";
            dgvPublishing[1, 2].Value = "2000";
            dgvKeyWords.AllowUserToAddRows = true;
        }        
        private void btn_changeShow()
        {
            btnChange.Visible = true;
            btnAdd.Visible = false;
            dgvMain[1,13].ReadOnly = true;
            dgvIndexShelf[1,6].ReadOnly = true;
            btnAddRowAuth.Visible = false;
            btnDelRowAuth.Visible = false;
            btnAddRowHeading.Visible = false;
            btnDelRowHeading.Visible = false;
            dgvKeyWords.AllowUserToAddRows = false;
            fillTables(idMain);
        }
        //get 
        public void getBtnAddShow()
        {
            btn_addShow();
        }
        public void getBtnChangeShow()
        {
            btn_changeShow();
        }
        //Заполнение таблиц
        private void fillTables(int idMain)
        {
            //Заполнение Главной таблицы
            string queryMain = $"SELECT cn, special_purpose, edition_info, remarks, catalog_ind, size, " +
                $"index_bbk, index_udk, isbn, mainTableBook_db.url, code_land, name_org, creator_code, record_date, " +
                $"author, title, publishing_house, index_shelf, subject_heading, keywords " +
                $"FROM mainTableBook_db WHERE id = {idMain}";
            dataBase.OpenConnection();
            SqlCommand sqlComMain = new SqlCommand(queryMain, dataBase.getConnection());
            SqlDataReader readMain = sqlComMain.ExecuteReader();
            while (readMain.Read())
            {
                for (int i = 0; i <= 12; ++i)
                    dgvMain[1, i].Value = readMain.GetString(i);
                dgvMain[1, 13].Value = (readMain.GetDateTime(13)).ToString("yyyy-MM-dd");
                idAuth = readMain.GetInt32(14); //id записи таблицы Автор
                idTitle = readMain.GetInt32(15); //id записи таблицы Заглавие
                idPubHouse = readMain.GetInt32(16); //id записи таблицы Издательство
                idShelf = readMain.GetInt32(17); //id записи таблицы Полочный индекс
                idSubjHead = readMain.GetString(18); //id записи таблицы Тем. рубрика
                idKeywords = readMain.GetString(19); //id записи таблицы Ключевые слова
            }
            readMain.Close();
            dataBase.CloseConnection();
            //Заполнение таблицы Автор
            string queryAuth = $"SELECT first_author, dinast_num, titul, roles_persons " +
                $"FROM authorBook_db WHERE author = {idAuth}";
            dataBase.OpenConnection();
            SqlCommand sqlComAuth = new SqlCommand(queryAuth, dataBase.getConnection());
            SqlDataReader readAuth = sqlComAuth.ExecuteReader();
            while (readAuth.Read())
            {
                for (int i = 0; i <= 2; ++i)
                    dgvAuthor[1, i].Value = readAuth.GetString(i);
                idMoreAuth = readAuth.GetString(3); //id записей таблицы Доп. авторы
            }
            readAuth.Close();
            dataBase.CloseConnection();            
            //Заполнение таблицы Заглавие
            string queryTitle = $"SELECT nezn_simv, title_text, num_part, name_part, contin_title, responsibility " +
                $"FROM titleBook_db WHERE title = {idTitle}";
            dataBase.OpenConnection();
            SqlCommand sqlComTitle = new SqlCommand(queryTitle, dataBase.getConnection());
            SqlDataReader readTitle = sqlComTitle.ExecuteReader();
            while (readTitle.Read())
            {
                dgvTitle[1, 0].Value = (readTitle.GetInt32(0)).ToString();
                dgvTitle[1, 1].Value = readTitle.GetString(1);
                dgvTitle[1, 2].Value = (readTitle.GetInt32(2)).ToString();
                dgvTitle[1, 3].Value = readTitle.GetString(3);
                dgvTitle[1, 4].Value = readTitle.GetString(4);
                dgvTitle[1, 5].Value = readTitle.GetString(5);
            }
            readTitle.Close();
            dataBase.CloseConnection();
            //Заполнение таблицы Издательство
            string queryPubHouse = $"SELECT place_publ, publ_house, year_publ " +
                $"FROM publishingHouse_db WHERE publishing_house = {idPubHouse}";
            dataBase.OpenConnection();
            SqlCommand sqlComPHouse = new SqlCommand(queryPubHouse, dataBase.getConnection());
            SqlDataReader readPHouse = sqlComPHouse.ExecuteReader();
            while (readPHouse.Read())
            {
                dgvPublishing[1, 0].Value = readPHouse.GetString(0);
                dgvPublishing[1, 1].Value = readPHouse.GetString(1);
                dgvPublishing[1, 2].Value = (readPHouse.GetInt32(2)).ToString();
            }
            readPHouse.Close();
            dataBase.CloseConnection();
            //Заполнение таблицы Полочный индекс
            string queryShelf = $"SELECT index_shelf, copyright_sign, sigla, registration, type, publ_type, " +
                $"num_copies, num1, num2, reg_num, price, inv_num " +
                $"FROM indexShelf_db WHERE id_indShelf = {idShelf}";
            dataBase.OpenConnection();
            SqlCommand sqlComShelf = new SqlCommand(queryShelf, dataBase.getConnection());
            SqlDataReader readShelf = sqlComShelf.ExecuteReader();
            while (readShelf.Read())
            {
                for (int i = 0; i <= 5; ++i)
                {
                    dgvIndexShelf[1, i].Value = readShelf.GetString(i);
                }
                dgvIndexShelf[1, 6].Value = (readShelf.GetInt32(6)).ToString();
                dgvIndexShelf[1, 7].Value = readShelf.GetString(7);
                dgvIndexShelf[1, 8].Value = readShelf.GetString(8);
                dgvIndexShelf[1, 9].Value = readShelf.GetString(9);
                dgvIndexShelf[1, 10].Value = ((readShelf.GetDecimal(10)).ToString()).Replace(",", ".");
                idInvNum = readShelf.GetString(11); //id записей таблицы Инв. номера
            }
            readShelf.Close();
            dataBase.CloseConnection();
            //Заполнение таблицы Доп. авторы
            arrIdMoreAuth = idMoreAuth.Split('-').Select(int.Parse).ToArray();
            int j = 0;
            for (int i = 0; i < arrIdMoreAuth.Length; ++i)
            {
                string queryMoreAuth = $"SELECT other_auth, role " +
                $"FROM rolesPersons_db WHERE roles_persons = {arrIdMoreAuth[i]}";
                
                dataBase.OpenConnection();
                SqlCommand sqlComMoreAuth = new SqlCommand(queryMoreAuth, dataBase.getConnection());
                SqlDataReader readMoreAuth = sqlComMoreAuth.ExecuteReader();
                while (readMoreAuth.Read())
                {                    
                    dgvAuthorMore[1, j].Value = readMoreAuth.GetString(0);
                    dgvAuthorMore[1, j+1].Value = readMoreAuth.GetString(1);
                    if (i != arrIdMoreAuth.Length - 1)
                    {
                        dgvAuthorMore.Rows.Add("Другие авт. ФИО", " ");
                        dgvAuthorMore.Rows.Add("Роль лиц", " ");
                    }                    
                    j += 2;
                }
                readMoreAuth.Close();
                dataBase.CloseConnection();
            }
            //Заполнение таблицы Тем. рубрика
            arrIdSubjHead = idSubjHead.Split('-').Select(int.Parse).ToArray();
            j = 0;
            for (int i = 0; i < arrIdSubjHead.Length; ++i)
            {
                string querySubjHead = $"SELECT heading, subheading, hron_subheading, geo_subheading " +
                $"FROM subjectHeading_db WHERE subject_heading = {arrIdSubjHead[i]}";

                dataBase.OpenConnection();
                SqlCommand sqlComSubjHead = new SqlCommand(querySubjHead, dataBase.getConnection());
                SqlDataReader readSubjHead = sqlComSubjHead.ExecuteReader();
                while (readSubjHead.Read())
                {
                    dgvSubHeading[1, j].Value = readSubjHead.GetString(0);
                    dgvSubHeading[1, j + 1].Value = readSubjHead.GetString(1);
                    dgvSubHeading[1, j + 2].Value = readSubjHead.GetString(2);
                    dgvSubHeading[1, j + 3].Value = readSubjHead.GetString(3);
                    if (i != arrIdSubjHead.Length - 1)
                    {
                        dgvSubHeading.Rows.Add("Тематич. рубрика", " ");
                        dgvSubHeading.Rows.Add("Подрубрика", " ");
                        dgvSubHeading.Rows.Add("Хрон. подруб.", " ");
                        dgvSubHeading.Rows.Add("Гео. подруб.", " ");
                    }
                    j += 4;
                }
                readSubjHead.Close();
                dataBase.CloseConnection();
            }
            //Заполнение таблицы Ключевые слова
            if (idKeywords != " ")
            {
                arrIdKeywords = idKeywords.Split('-').Select(int.Parse).ToArray();
                for (int i = 0; i < arrIdKeywords.Length; ++i)
                {
                    dgvKeyWords.Rows.Add("");
                    string queryKeywords = $"SELECT keywords_value " +
                    $"FROM keywords_db WHERE keywords = {arrIdKeywords[i]}";

                    dataBase.OpenConnection();
                    SqlCommand sqlComKeywords = new SqlCommand(queryKeywords, dataBase.getConnection());
                    sqlComKeywords.ExecuteNonQuery();
                    dgvKeyWords[0, i].Value = sqlComKeywords.ExecuteScalar().ToString();
                    dataBase.CloseConnection();
                }
            }
            //Заполнение таблицы Инвентарные номера
            if (idInvNum != " ")
            {
                arrIdInvNum = idInvNum.Split('-').Select(int.Parse).ToArray();
                for (int i = 0; i < arrIdInvNum.Length; ++i)
                {
                    dgvInvNum.Rows.Add("");
                    string queryInvNum = $"SELECT inv_val " +
                    $"FROM invNum_db WHERE inv_num = {arrIdInvNum[i]}";

                    dataBase.OpenConnection();
                    SqlCommand sqlComInvNum = new SqlCommand(queryInvNum, dataBase.getConnection());
                    sqlComInvNum.ExecuteNonQuery();
                    dgvInvNum[0, i].Value = sqlComInvNum.ExecuteScalar().ToString();
                    dataBase.CloseConnection();
                }
            }
        }
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        //////////////////////////////////////
        private void btnAdd_Click(object sender, EventArgs e)
        {
            classInfoBook.getAddBook(dgvTitle, dgvPublishing, dgvIndexShelf,
            dgvMain, dgvAuthor, dgvAuthorMore, dgvSubHeading,
            dgvKeyWords, dgvInvNum, this);
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            classInfoBook.getChangeInfoBook(dgvTitle, dgvPublishing, dgvIndexShelf,
            dgvMain, dgvAuthor, dgvAuthorMore, dgvSubHeading,
            dgvKeyWords, dgvInvNum, idMain, idAuth, idTitle, idPubHouse, idShelf, arrIdMoreAuth, arrIdSubjHead,
            arrIdKeywords, arrIdInvNum);
        }
    }
}