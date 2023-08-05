using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Kursovaya2
{
    /// <summary>
    /// Логика взаимодействия для GraduateStudents.xaml
    /// </summary>
    public partial class GraduateStudents : Window
    {
        public GraduateStudent[] masGS = new GraduateStudent[] { };
        public GraduateStudents()
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
                if (s[0] == "Аспирант ")
                {
                    i++;
                    Array.Resize(ref masGS, masGS.Length + 1);
                    masGS[t] = new GraduateStudent(s[0], s[1], DateTime.Parse(s[2]), float.Parse(s[3]), s[4]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masGS;
        }

        private void Btn_Click_AddStud(object sender, RoutedEventArgs e)
        {
            AddGS form = new AddGS();
            form.Show();
        }

        private void Btn_Click_Upd(object sender, RoutedEventArgs e)
        {
            Array.Resize(ref masGS, 0);
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
                if (s[0] == "Аспирант ")
                {
                    i++;
                    Array.Resize(ref masGS, masGS.Length + 1);
                    masGS[t] = new GraduateStudent(s[0], s[1], DateTime.Parse(s[2]), float.Parse(s[3]), s[4]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masGS;
        }
        private void Btn_Click_GClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_GEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Добавить нового аспиранта";
        }
        private void BtnAdd_GLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnUpd_GEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Обновить таблицу";
        }
        private void BtnUpd_GLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnSave_GEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Сохранить список аспирантов в файл";
        }
        private void BtnSave_GLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnClose_GEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Закрыть окно";
        }
        private void BtnClose_GLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void Btn_Click_Save(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("..\\..\\files\\saves\\GraduateStudents.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);

            try
            {
                for (int j = 0; j < masGS.Length; j++)
                {
                    string stroka1 = masGS[j].status + " ; " + masGS[j].fio + " ; " + masGS[j].DOB.ToShortDateString() + " ; " +
                        masGS[j].StudTime + " ; " + masGS[j].Topic;
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