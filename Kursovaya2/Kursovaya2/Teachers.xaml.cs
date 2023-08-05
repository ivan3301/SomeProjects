using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Kursovaya2
{
    /// <summary>
    /// Логика взаимодействия для Teachers.xaml
    /// </summary>
    public partial class Teachers : Window
    {
        public Teacher[] masTeach = new Teacher[] { };
        public Teachers()
        {
            InitializeComponent();
        }

        private void gridT_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int t = 0;
            StreamReader f = new StreamReader("..\\..\\files\\Persons.txt", Encoding.GetEncoding("windows-1251"));
            string st;
            while (!f.EndOfStream)
            {
                st = f.ReadLine();
                string[] s = st.Split(';');
                if (s[0] == "Преподаватель ")
                {
                    i++;
                    Array.Resize(ref masTeach, masTeach.Length + 1);
                    masTeach[t] = new Teacher(s[0], s[1], DateTime.Parse(s[2]), s[3], s[4]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masTeach;
        }

        private void Btn_Click_AddStud(object sender, RoutedEventArgs e)
        {
            AddTeachers form = new AddTeachers();
            form.Show();
        }

        private void Btn_Click_Upd(object sender, RoutedEventArgs e)
        {
            Array.Resize(ref masTeach, 0);
            grid.ItemsSource = null;
            grid.Items.Refresh();
            int i = 0;
            int t = 0;
            StreamReader f = new StreamReader("..\\..\\files\\Persons.txt", Encoding.GetEncoding("windows-1251"));
            string st;
            while (!f.EndOfStream)
            {
                st = f.ReadLine();
                string[] s = st.Split(';');
                if (s[0] == "Преподаватель ")
                {
                    i++;
                    Array.Resize(ref masTeach, masTeach.Length + 1);
                    masTeach[t] = new Teacher(s[0], s[1], DateTime.Parse(s[2]), s[3], s[4]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masTeach;
        }
        private void Btn_Click_TClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_TEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Добавить нового преподавателя";
        }
        private void BtnAdd_TLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnUpd_TEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Обновить таблицу";
        }
        private void BtnUpd_TLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnSave_TEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Сохранить список преподавателей в файл";
        }
        private void BtnSave_TLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnClose_TEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Закрыть окно";
        }
        private void BtnClose_TLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void Btn_Click_Save(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("..\\..\\files\\saves\\Teachers.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                for (int j = 0; j < masTeach.Length; j++)
                {
                    string stroka1 = masTeach[j].status + " ; " + masTeach[j].fio + " ; " + masTeach[j].DOB.ToShortDateString() + " ; " +
                        masTeach[j].rank + " ; " + masTeach[j].kaf;
                    streamWriter.WriteLine(stroka1);
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }
    }
}
